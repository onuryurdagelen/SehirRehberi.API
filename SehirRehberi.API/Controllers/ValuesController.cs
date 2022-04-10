using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SehirRehberi.API.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SehirRehberi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private DataContext _context;

        public ValuesController(DataContext context)
        {
            _context = context;
        }

        //GET api/values
        [HttpGet]
        public async Task<ActionResult> GetValues()
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }
        //GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetValueById(int id)
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            if (value !=null)
            {
                return Ok(value);
            }
            return BadRequest("VALUE NOT FOUND!!!");
        }
    }
}
