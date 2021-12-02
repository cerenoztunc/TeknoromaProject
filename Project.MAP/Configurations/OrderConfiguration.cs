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
    public class OrderConfiguration:BaseConfiguration<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            //builder.Property(x => x.Freight).HasColumnType("money");
            builder.ToTable("Orders");
            builder.HasOne(o => o.AppUser).WithMany(au => au.Orders).HasForeignKey(o => o.AppUserId);
            builder.HasOne(o => o.Customer).WithMany(c => c.Orders).HasForeignKey(o => o.CustomerId);
            //builder.HasMany<OrderDetail>().WithOne().HasForeignKey(x => x.OrderId).IsRequired();

        }
    }
}
