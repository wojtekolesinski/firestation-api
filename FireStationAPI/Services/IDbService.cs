using FireStationAPI.Dto;
using FireStationAPI.Responses;

namespace FireStationAPI.Services;

public interface IDbService
{
    Task<Response<ActionDto>> GetActionByIdAsync(int idAction);
    Task<Response<object>> AddFiretruckToActionAsync(AddFiretruckToActionDto dto);
}