namespace FireStationAPI.Entities;

public class FireTruck
{
    public int IdFiretruck { get; set; }
    public string OperationNumber { get; set; }
    public bool SpecialEquipment { get; set; }

    public virtual ICollection<FireTruckAction> FireTruckActions { get; set; }

    public FireTruck()
    {
        FireTruckActions = new HashSet<FireTruckAction>();
    }
}