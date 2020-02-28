using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DbTestController : ControllerBase
    {
        private readonly ILogger<DbTestController> _logger;
        private readonly TestDbContext _context;

        public DbTestController(ILogger<DbTestController> logger, TestDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet]
        public ActionResult<Test> Get()
        {
            return _context.Test.First();
        }
    }
}