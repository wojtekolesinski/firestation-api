using FireStationAPI.Dto;
using FireStationAPI.Responses;
using FireStationAPI.Services;
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
            var response = await _dbService.GetActionByIdAsync(idAction);
            if (response.StatusCode == StatusCodes.Status404NotFound)
            {
                return NotFound(response.Message);
            }

            return Ok(response.Result);
        }

        [HttpPost("add-firetruck/")]
        public async Task<IActionResult> AddFiretruck(AddFiretruckToActionDto dto)
        {
            Response<object> response = await _dbService.AddFiretruckToActionAsync(dto);
            return response.StatusCode switch
            {
                StatusCodes.Status404NotFound => NotFound(response.Message),
                StatusCodes.Status400BadRequest => BadRequest(response.Message),
                _ => Created("", dto)
            };
        }
    }
}
