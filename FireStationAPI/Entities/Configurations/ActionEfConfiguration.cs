using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FireStationAPI.Entities.Configurations;

public class ActionEfConfiguration : IEntityTypeConfiguration<Action>
{
    public void Configure(EntityTypeBuilder<Action> builder)
    {
        builder.HasKey(e => e.IdAction).HasName("Action_pk");
        builder.Property(e => e.IdAction).UseIdentityColumn();

        builder.Property(e => e.StartTime).IsRequired();
        builder.Property(e => e.NeedSpecialEquipment).IsRequired();

        builder.HasData(
            new Action {IdAction = 1, StartTime = DateTime.Today.AddDays(-100), EndTime = DateTime.Today.AddDays(-99), NeedSpecialEquipment = true},
            new Action {IdAction = 2, StartTime = DateTime.Now.AddDays(-10), EndTime = DateTime.Now.AddDays(-10).AddHours(10), NeedSpecialEquipment = true},
            new Action {IdAction = 3, StartTime = DateTime.Today, NeedSpecialEquipment = false},
            new Action {IdAction = 4, StartTime = DateTime.Today.AddDays(-5).AddHours(4), EndTime = DateTime.Today.AddDays(-4), NeedSpecialEquipment = false}
        );

        builder.ToTable("Action");
    }
}