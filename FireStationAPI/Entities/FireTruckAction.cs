namespace FireStationAPI.Entities;

public class FireTruckAction
{
    public int IdFiretruck { get; set; }
    public int IdAction { get; set; }
    public DateTime AssignmentDate { get; set; }

    public virtual FireTruck IdFiretruckNavigation { get; set; }
    public virtual Action IdActionNavigation { get; set; }
}