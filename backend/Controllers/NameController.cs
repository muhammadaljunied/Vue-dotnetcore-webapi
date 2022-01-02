using Microsoft.AspNetCore.Mvc;
using backend.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using backend.Services;
using backend.Contracts;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/getName")]
    public class NameController : Controller
    {
        private readonly ILogger<NameController> _logger;
        private readonly INameService _service;

        public NameController(ILogger<NameController> logger, INameService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public Name Get()
        {
            Name name = _service.Get();
                
            _logger.LogInformation($"/GetName responded with the value {name}");
            return name;
        }
    }
}
