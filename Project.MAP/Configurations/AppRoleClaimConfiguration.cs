using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.MAP.Configurations
{
    public class AppRoleClaimConfiguration:BaseConfiguration<AppRoleClaim>
    {
        public override void Configure(EntityTypeBuilder<AppRoleClaim> builder)
        {
            base.Configure(builder);
            // Primary key
            builder.HasKey(rc => rc.Id);

            // Maps to the AspNetRoleClaims table
            builder.ToTable("AppRoleClaims");
        }
    }
}
