using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBRW.Api.Data;
using SBRW.Data;
using SBRW.Data.Entities;

namespace SBRW.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        private readonly ServiceDbContext _context;

        public ServersController(ServiceDbContext context)
        {
            _context = context;
        }

        // GET: api/Servers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServerInfo>>> GetServers()
        {
            return await _context.Servers.Include(s => s.Stats)
                .AsQueryable()
                .Select(ServerInfo.Projection)
                .ToListAsync();
        }

        // GET: api/Servers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Server>> GetServer(int id)
        {
            var server = await _context.Servers.FindAsync(id);

            if (server == null)
            {
                return NotFound();
            }

            return server;
        }
    }
}
