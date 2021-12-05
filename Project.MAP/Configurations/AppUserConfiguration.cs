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
    public class AppUserConfiguration : BaseConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder);
            //Primary key
            builder.HasKey(x => x.Id);
            //About
            builder.Property(x => x.Picture).IsRequired();
            builder.Property(x => x.Picture).HasMaxLength(250);
            builder.Property(x => x.FirstName).HasMaxLength(30);
            builder.Property(x => x.LastName).HasMaxLength(30);

            builder.ToTable("AppUsers");

            //builder.HasOne(au => au.AppRole).WithMany(ar => ar.AppUsers).HasForeignKey(au=>au.AppRoleId);
        }
    }
}
