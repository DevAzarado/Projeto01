using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using DEVAZARADO.Data;
using DEVAZARADO.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEVAZARADO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        public readonly DataContext _context;

        public ClienteController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> Get()
        {
            await Task.Delay(1000);
            var cliente = await _context.Clientes.AsNoTracking().ToListAsync();
            return Ok(cliente);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Cliente>> GetById(int id)
        {
            var model = await _context.Clientes.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (model is null) return NotFound();
            return Ok(new { sucess = true, ismodel = model });
        }
        [HttpPost]
        public async Task<ActionResult<Cliente>> Post([FromBody] Cliente model)
        {
            if (!ModelState.IsValid) return NotFound();

            await _context.Clientes.AddAsync(model);
            await _context.SaveChangesAsync();

            return Ok(new { sucess = true, ismodel = model });
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Cliente>> Put(int? id, [FromBody] Cliente model)
        {
            if (id != model.Id) return NotFound();

            if (id is null) return NotFound();

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente is null) return NotFound();

            //  _context.Entry(cliente).State = EntityState.Modified;
            _context.Entry(cliente).CurrentValues.SetValues(model);
            await _context.SaveChangesAsync();

            return Ok(new { sucess = true, ismodel = model });
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Cliente>> Delete(int id)
        {
            var model = await _context.Clientes.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (model is null) return NotFound();
            return Ok(new { sucess = true, ismodel = model });
        }

        [HttpGet("{page:int}/{pageSize:int}")]
        public async Task<IActionResult> GetListOfCustomer(int page = 0, int pageSize = 2)
        {
            await Task.Delay(1000);
            var cliente = await _context.Clientes
                .OrderByDescending(x => x.Id)
              .Skip(page)
            .Take(pageSize)
            .ToListAsync();
            return Ok(cliente);
        }



    }
}





