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
    public class AppUserRoleConfiguration:BaseConfiguration<AppUserRole>
    {
        public override void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            base.Configure(builder);
            // Primary key
            builder.HasKey(r => new { r.UserId, r.RoleId });
            
            builder.ToTable("AppUserRoles");

            builder.HasData(
                new AppUserRole
                {
                    UserId = 1,
                    RoleId = 1
                },
                new AppUserRole
                {
                    UserId = 2,
                    RoleId = 2
                }
                );
        }
    }
}
