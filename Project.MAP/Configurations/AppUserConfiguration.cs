using Microsoft.AspNetCore.Identity;
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

            builder.HasMany<AppUserClaim>().WithOne().HasForeignKey(uc => uc.UserId).IsRequired();
            builder.HasMany<AppUserLogin>().WithOne().HasForeignKey(ul => ul.UserId).IsRequired();
            builder.HasMany<AppUserToken>().WithOne().HasForeignKey(ut => ut.UserId).IsRequired();
            builder.HasMany<AppUserRole>().WithOne().HasForeignKey(ur => ur.UserId).IsRequired();

            var managerUser = new AppUser
            {
                Id = 1,
                UserName = "ManagerUser",
                NormalizedUserName = "MANAGERUSER",
                Email = "manageruser@gmail.com",
                NormalizedEmail = "MANAGERUSER@GMAIL.COM",
                PhoneNumber = "05555555555",
                Picture = "/picture/profile.jpg",
                FirstName = "Manager",
                LastName = "User",
                BirthDate = DateTime.Now,
                Gender = 0,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            managerUser.PasswordHash = CreatePasswordHash(managerUser, "12qw");
            var branchManagerUser = new AppUser
            {
                Id = 2,
                UserName = "BranchManagerUser",
                NormalizedUserName = "BRANCHMANAGERUSER",
                Email = "branchmanageruser@gmail.com",
                NormalizedEmail = "BRANCHMANAGERUSER@GMAIL.COM",
                PhoneNumber = "05555555555",
                Picture = "/picture/profile.jpg",
                FirstName = "BranchManager",
                LastName = "User",
                BirthDate = DateTime.Now,
                Gender = 0,
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            branchManagerUser.PasswordHash = CreatePasswordHash(branchManagerUser, "12qw");
            builder.HasData(managerUser, branchManagerUser);
        }
        private string CreatePasswordHash(AppUser user, string password)
        {
            var passwordHasher = new PasswordHasher<AppUser>();
            return passwordHasher.HashPassword(user, password);
        }
    }
}
