using FireStationAPI.Data;
using FireStationAPI.Dto;
using Microsoft.EntityFrameworkCore;

namespace FireStationAPI.Services;

public class DbService : IDbService
{
    private readonly FirestationContext _context;

    public DbService(FirestationContext context)
    {
        _context = context;
    }

    public async Task<ActionDto> getActionByIdAsync(int idAction)
    {
        // TODO: check if action exists, wrap result in response class
        var actionFromDb = await _context.Actions.Where(e => e.IdAction == idAction)
            .Include(e => e.FireTruckActions)
            .ThenInclude(fta => fta.IdFiretruckNavigation).Select(a => new ActionDto
            {
                IdAction = a.IdAction,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                NeedSpecialEquipment = a.NeedSpecialEquipment,
                Firetrucks = a.FireTruckActions.Select(fta => new FireTruckDto
                {
                    IdFiretruck = fta.IdFiretruck,
                    OperationNumber = fta.IdFiretruckNavigation.OperationNumber,
                    SpecialEquipment = fta.IdFiretruckNavigation.SpecialEquipment
                })
            }).FirstAsync();
        return actionFromDb;
    }
}