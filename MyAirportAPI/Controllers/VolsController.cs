using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MCSP.MyAirport.EF;

namespace MyAirportAPI.Controllers
{
    /// <summary>
    /// Objet volsController comprenant les routes de l'objet Vol
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class VolsController : ControllerBase
    {
        private readonly MyAirportContext _context;

        /// <summary>
        /// Constructeur de l'objet volsController
        /// </summary>
        public VolsController(MyAirportContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Selectionne les vols de manière asynchrone
        /// GET: api/Vols
        /// </summary>
        /// <response code="200">Retourne le vol demandé</response> 
        /// <returns>Un objet Task qui contient un Action Result qui lui même contient une liste de vols</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Vol>>> GetVols()
        {
            return await _context.Vols.ToListAsync();
        }


        /// <summary>
        /// Selectionne le vol choisi de manière asynchrone
        /// GET: api/Vols/5?bool displayBagages
        /// </summary>
        /// <param name="id">Id du vol a afficher</param>
        /// <param name="displayBagages">Afficher info des bagages ou non</param>
        /// <response code="200">Retourne le vol demandé</response>
        /// <response code="404">Si le vol n'est pas trouvé</response> 
        /// <returns>Un objet Task qui contient un Action Result qui lui même contient un vol</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Vol>> GetVol(int id,
            [FromQuery] bool displayBagages = false)
        {
            Vol vol;
            if (displayBagages)
            {
                vol = await _context.Vols.Include(v => v.Bagages).FirstAsync(v => v.VolId == id);
            }
            else
                vol = await _context.Vols.FindAsync(id); 

            if (vol == null)
            {
                return NotFound();
            }

            

                return vol;
        
        
        }

        /// <summary>
        /// Permet de modifier l'objet vol choisi
        /// PUT: api/Vols/5
        /// </summary>
        /// <param name="id">Identifiant du vol a modifier</param>
        /// <param name="vol">Nouvelles valeurs a remplacer du vol</param>
        /// <response code="204">Si le vol a bien était modifié</response>
        /// <response code="400">Si un problème apparait</response>
        /// <response code="404">Si le vol n'est pas trouvé</response> 
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutVol(int id, Vol vol)
        {
            if (id != vol.VolId)
            {
                return BadRequest();
            }

            _context.Entry(vol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        /// <summary>
        /// Ajout d'un vol
        /// POST: api/Vols
        /// </summary>
        /// <param name="vol">Vol que l'on veut créer</param>
        /// <response code="201">Retourne le vol créé</response>
        /// <returns>Vol</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Vol>> PostVol(Vol vol)
        {
            _context.Vols.Add(vol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVol", new { id = vol.VolId }, vol);
        }

        /// <summary>
        /// Suppression d'un vol
        /// DELETE: api/Vols/5
        /// </summary>
        /// <param name="id">Id du vol a supprimer</param>
        /// <response code="204">Le vol a bien était supprimé</response>
        /// <response code="404">Le vol n'a pas était trouvé</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Vol>> DeleteVol(int id)
        {
            var vol = await _context.Vols.FindAsync(id);
            if (vol == null)
            {
                return NotFound();
            }

            _context.Vols.Remove(vol);
            await _context.SaveChangesAsync();

            return vol;
        }

        private bool VolExists(int id)
        {
            return _context.Vols.Any(e => e.VolId == id);
        }
    }
}
