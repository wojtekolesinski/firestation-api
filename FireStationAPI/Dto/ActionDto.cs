using FireStationAPI.Entities;

namespace FireStationAPI.Dto;

public class ActionDto
{
    public int IdAction { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime? EndTime { get; set; }
    public bool NeedSpecialEquipment { get; set; }

    public IEnumerable<FireTruckDto> Firetrucks { get; set; }
}