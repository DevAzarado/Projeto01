using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
        {
            var cliente = await _context.Clientes.AsNoTracking().ToListAsync();
            return Ok(cliente);
        }
    }
}