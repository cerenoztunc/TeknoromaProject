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
    public class OrderDetailConfiguration:BaseConfiguration<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            base.Configure(builder);
            builder.HasKey(x => new { x.ProductId, x.OrderId });
            builder.Ignore(x => x.Id);
            builder.ToTable("OrderDetails");
            builder.Property(x => x.UnitPrice).HasColumnType("money");
        }
    }
}
