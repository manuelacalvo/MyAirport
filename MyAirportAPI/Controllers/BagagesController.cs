using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MCSP.MyAirport.EF;


namespace MyAirportAPI
{
    /// <summary>
    /// Objet bagagesController comprenant les routes de l'objet Bagage
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BagagesController : ControllerBase
    {
        private readonly MyAirportContext _context;

        /// <summary>
        /// Constructeur de l'objet BagagesController
        /// </summary>
        public BagagesController(MyAirportContext context)
        {
            _context = context;
        }

        
        /// <summary>
        /// Selectionne les bagages de manière asynchrone
        /// GET: api/Bagages
        /// </summary>
        /// <returns>Un objet Task qui contient un Action Result qui lui même contient une liste de bagage</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Bagage>>> GetBagages()
        {
            return await _context.Bagages.ToListAsync();
        }

        
        /// <summary>
        /// Selectionne le bagage choisi de manière asynchrone
        /// GET: api/Bagages/5
        /// </summary>
        /// <param name="id">Id du bagage a afficher</param>
        /// <returns>Un objet Task qui contient un Action Result qui lui même contient un bagage</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Bagage>> GetBagage(int id)
        {
            var bagage = await _context.Bagages.FindAsync(id);

            if (bagage == null)
            {
                return NotFound();
            }

            return bagage;
        }


        /// <summary>
        /// Permet de modifier l'objet bagage choisi
        /// PUT: api/Bagages/5
        /// </summary>
        /// <param name="id">Identifiant du bagage a modifier</param>
        /// <param name="bagage">Nouvelles valeurs a remplacer du bagage</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutBagage(int id, Bagage bagage)
        {
            if (id != bagage.BagageId)
            {
                return BadRequest();
            }

            _context.Entry(bagage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BagageExists(id))
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
        /// Ajout d'un bagage
        /// POST: api/Bagages
        /// </summary>
        /// <param name="bagage">Bagage que l'on veut créer</param>
        /// <returns>Bagage</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Bagage>> PostBagage(Bagage bagage)
        {
            _context.Bagages.Add(bagage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBagage", new { id = bagage.BagageId }, bagage);
        }


        /// <summary>
        /// Suppression d'un bagage
        /// DELETE: api/Bagages/5
        /// </summary>
        /// <param name="id">Id du bagage a supprimer</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Bagage>> DeleteBagage(int id)
        {
            var bagage = await _context.Bagages.FindAsync(id);
            if (bagage == null)
            {
                return NotFound();
            }

            _context.Bagages.Remove(bagage);
            await _context.SaveChangesAsync();

            return bagage;
        }

        private bool BagageExists(int id)
        {
            return _context.Bagages.Any(e => e.BagageId == id);
        }
    }
}
