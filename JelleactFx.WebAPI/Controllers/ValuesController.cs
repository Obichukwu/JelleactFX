using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JelleactFx.Domain;
using JelleactFx.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JelleactFx.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(DataContext context,ILogger<ValuesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Value>> Get()
        {
            var values = await _context.Values.ToArrayAsync();
            return values;
        }

        [HttpGet("{id}")]
        public async Task<Value> Get(int id)
        {
            var value = await _context.Values.SingleOrDefaultAsync(el => el.Id == id);
            return value;
        }
    }
}
