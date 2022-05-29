using System.Reflection;
using FireStationAPI.Entities;
using FireStationAPI.Entities.Configurations;
using Microsoft.EntityFrameworkCore;
using Action = FireStationAPI.Entities.Action;


namespace FireStationAPI.Data;

public class FirestationContext : DbContext
{
    public virtual DbSet<Action> Actions { get; set; }
    public virtual DbSet<FireTruck> FireTrucks { get; set; }
    public virtual DbSet<FireTruckAction> FireTruckActions { get; set; }

    protected FirestationContext()
    { }

    public FirestationContext(DbContextOptions options) : base(options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ActionEfConfiguration).GetTypeInfo().Assembly
        );
    }
}