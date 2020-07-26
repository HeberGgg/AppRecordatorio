using API.Models;
using API.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordatorioController : ControllerBase
    {
        private readonly RecordatorioContext context;

        public RecordatorioController(RecordatorioContext contexto)
        {
            context = contexto;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recordatorio>>> GetRecordatorioItems()
        {
            return await context.Recordatorio.ToListAsync();
        }

   
        //Peticion tipo get id: un colo registro api/Departamento/4
        [HttpGet("{id}")]
        public async Task<ActionResult<Recordatorio>> GetRecordatorioItem(int id)
        {
            var RecordatorioItem = await context.Recordatorio.FindAsync(id);

            if(RecordatorioItem == null)
            {
                return NotFound();
            }

           return RecordatorioItem; 
        }

        [HttpPost]
        public async Task<ActionResult<Recordatorio>> PostRecordatorioItems(Recordatorio item) 
        {
            context.Recordatorio.Add(item);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRecordatorioItem), new { id = item.ID}, item);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecordatorioItem(int id, Recordatorio item)
        {
            if(id != item.ID)
           {
                return BadRequest();
            }
        
            context.Entry(item).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent(); 
        }        

        //Peticion Delete para borrar
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecordatorioItem(int id)
        {
            var RecordatorioItem = await context.Recordatorio.FindAsync(id);

            if(RecordatorioItem == null)
            {
                return NotFound();
            }

            context.Recordatorio.Remove(RecordatorioItem);
            await context.SaveChangesAsync();

            return NoContent();
        }


      
    }
}