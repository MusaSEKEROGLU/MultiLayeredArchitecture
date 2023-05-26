using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MultiLayered.Core.Models;

namespace MultiLayered.Respository.Configurations
{
    public class TeamFeatureConfiguration : IEntityTypeConfiguration<TeamFeature>
    {
        public void Configure(EntityTypeBuilder<TeamFeature> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.ToTable("TeamFeatures");

            //tablo ilişkileri
            builder.HasOne(x => x.Team).WithOne(x => x.TeamFeature).HasForeignKey<TeamFeature>(x => x.TeamId);
        }
    }
}
