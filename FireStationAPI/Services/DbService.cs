using FireStationAPI.Data;
using FireStationAPI.Dto;
using FireStationAPI.Entities;
using FireStationAPI.Responses;
using Microsoft.EntityFrameworkCore;

namespace FireStationAPI.Services;

public class DbService : IDbService
{
    private readonly FirestationContext _context;

    public DbService(FirestationContext context)
    {
        _context = context;
    }

    public async Task<Response<ActionDto>> GetActionByIdAsync(int idAction)
    {
        var response = new Response<ActionDto>();
        var actionFromDb = await _context.Actions.SingleOrDefaultAsync(e => e.IdAction == idAction);
        if (actionFromDb == null)
        {
            response.StatusCode = StatusCodes.Status404NotFound;
            response.Message = $"Action with id {idAction} does not exist";
            return response;
        }

        var actionDto = await _context.Actions.Where(e => e.IdAction == idAction)
            .Include(e => e.FireTruckActions)
            .ThenInclude(fta => fta.IdFiretruckNavigation).Select(a => new ActionDto
            {
                IdAction = a.IdAction,
                StartTime = a.StartTime,
                EndTime = a.EndTime,
                NeedSpecialEquipment = a.NeedSpecialEquipment,
                Firetrucks = a.FireTruckActions
                    .OrderByDescending(fta => fta.AssignmentDate)
                    .Select(fta => new FireTruckDto
                    {
                        IdFiretruck = fta.IdFiretruck,
                        OperationNumber = fta.IdFiretruckNavigation.OperationNumber,
                        SpecialEquipment = fta.IdFiretruckNavigation.SpecialEquipment
                    })
            }).SingleAsync();
        
        response.StatusCode = StatusCodes.Status200OK;
        response.Result = actionDto;
        return response;
    }

    public async Task<Response<object>> AddFiretruckToActionAsync(AddFiretruckToActionDto dto)
    {
        var response = new Response<object>();
        var actionFromDb = await _context.Actions
            .SingleOrDefaultAsync(ft => ft.IdAction == dto.IdAction);
        var firetruckFromDb = await _context.FireTrucks
            .SingleOrDefaultAsync(ft => ft.IdFiretruck == dto.IdFiretruck);

        if (actionFromDb == null)
        {
            response.Message = $"Action with id {dto.IdAction} does not exist";
            response.StatusCode = StatusCodes.Status404NotFound;
            return response;
        }
        
        if (firetruckFromDb == null)
        {
            response.Message = $"Firetruck with id {dto.IdFiretruck} does not exist";
            response.StatusCode = StatusCodes.Status404NotFound;
            return response;
        }

        if (await _context.FireTruckActions
                .SingleOrDefaultAsync(fta => fta.IdAction == dto.IdAction
                                             && fta.IdFiretruck == dto.IdFiretruck) != null)
        {
            response.Message = $"Firetruck with id {dto.IdFiretruck} already assigned to this action";
            response.StatusCode = StatusCodes.Status400BadRequest;
            return response;
        }

        if (await _context.FireTruckActions
                .Where(ft => ft.IdAction == dto.IdAction)
                .CountAsync() >= 3)
        {
            response.Message = "Cannot assign more than 3 firetrucks to a single action";
            response.StatusCode = StatusCodes.Status400BadRequest;
            return response;
        }

        if (actionFromDb.NeedSpecialEquipment && !firetruckFromDb.SpecialEquipment)
        {
            response.Message = "This action needs special equipment";
            response.StatusCode = StatusCodes.Status400BadRequest;
            return response;
        }

        if (actionFromDb.EndTime != null)
        {
            response.Message = "Action already finished";
            response.StatusCode = StatusCodes.Status400BadRequest;
            return response;
        }

        await _context.FireTruckActions.AddAsync(new FireTruckAction
        {
            IdAction = actionFromDb.IdAction,
            IdFiretruck = firetruckFromDb.IdFiretruck,
            AssignmentDate = DateTime.Now
        });

        await _context.SaveChangesAsync();
        response.StatusCode = StatusCodes.Status201Created;
        return response;
    }
}