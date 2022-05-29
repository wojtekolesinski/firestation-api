using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FireStationAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FireStationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public ActionsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet("{idAction:int}")]
        public async Task<IActionResult> Get(int idAction)
        {
            return Ok(await _dbService.getActionByIdAsync(idAction));
        }
    }
}
