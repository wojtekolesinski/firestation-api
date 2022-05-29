using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FireStationAPI.Entities.Configurations;

public class FireTruckEfConfiguration : IEntityTypeConfiguration<FireTruck>
{
    public void Configure(EntityTypeBuilder<FireTruck> builder)
    {
        builder.HasKey(e => e.IdFiretruck).HasName("Firetruck_pk");
        builder.Property(e => e.IdFiretruck).UseIdentityColumn();

        builder.Property(e => e.OperationNumber).IsRequired().HasMaxLength(10);
        builder.Property(e => e.SpecialEquipment).IsRequired();

        builder.HasData(
            new FireTruck {IdFiretruck = 1, OperationNumber = "51", SpecialEquipment = true},
            new FireTruck {IdFiretruck = 2, OperationNumber = "10", SpecialEquipment = false},
            new FireTruck {IdFiretruck = 3, OperationNumber = "104", SpecialEquipment = false},
            new FireTruck {IdFiretruck = 4, OperationNumber = "321", SpecialEquipment = true},
            new FireTruck {IdFiretruck = 5, OperationNumber = "161", SpecialEquipment = false},
            new FireTruck {IdFiretruck = 6, OperationNumber = "571", SpecialEquipment = true}
        );

        builder.ToTable("FireTruck");
    }
}