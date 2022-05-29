using FireStationAPI.Dto;

namespace FireStationAPI.Services;

public interface IDbService
{
    Task<ActionDto> getActionByIdAsync(int idAction);
}