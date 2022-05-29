using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FireStationAPI.Entities.Configurations;

public class FireTruckActionEfConfiguration : IEntityTypeConfiguration<FireTruckAction>
{
    public void Configure(EntityTypeBuilder<FireTruckAction> builder)
    {
        builder.HasKey(e => new {e.IdAction, e.IdFiretruck}).HasName("FireTruck_Action_pk");

        builder.Property(e => e.IdAction).ValueGeneratedNever();
        builder.Property(e => e.IdFiretruck).ValueGeneratedNever();
        builder.Property(e => e.AssignmentDate).IsRequired();

        builder.HasOne(e => e.IdActionNavigation)
            .WithMany(e => e.FireTruckActions)
            .HasForeignKey(e => e.IdAction)
            .HasConstraintName("FiretruckAction_Action")
            .OnDelete(DeleteBehavior.ClientSetNull);
        
        builder.HasOne(e => e.IdFiretruckNavigation)
            .WithMany(e => e.FireTruckActions)
            .HasForeignKey(e => e.IdFiretruck)
            .HasConstraintName("FiretruckAction_Firetruck")
            .OnDelete(DeleteBehavior.ClientSetNull);

        builder.HasData(
            new FireTruckAction {IdFiretruck = 1, IdAction = 1, AssignmentDate = DateTime.Today.AddDays(-100)},    
            new FireTruckAction {IdFiretruck = 4, IdAction = 1, AssignmentDate = DateTime.Today.AddDays(-100)},    
            new FireTruckAction {IdFiretruck = 6, IdAction = 2, AssignmentDate = DateTime.Today.AddDays(-10)},    
            new FireTruckAction {IdFiretruck = 2, IdAction = 3, AssignmentDate = DateTime.Today},   
            new FireTruckAction {IdFiretruck = 3, IdAction = 3, AssignmentDate = DateTime.Today},  
            new FireTruckAction {IdFiretruck = 5, IdAction = 3, AssignmentDate = DateTime.Today},   
            new FireTruckAction {IdFiretruck = 1, IdAction = 4, AssignmentDate = DateTime.Today},   
            new FireTruckAction {IdFiretruck = 5, IdAction = 4, AssignmentDate = DateTime.Today.AddDays(-5).AddHours(4)}   
        );
        
        builder.ToTable("FireTruck_Action");
    }
}