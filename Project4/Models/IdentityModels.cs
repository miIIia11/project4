using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

namespace Project4.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public Guid QuanNgucID { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim("QuanNgucID", QuanNgucID.ToString()));
            userIdentity.AddClaims(claims);
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("NhaTu", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<AnXa> AnXa { get; set; }
        public virtual DbSet<Benh> Benh { get; set; }
        public virtual DbSet<CheDoNghiPhepCuaQuanNguc> CheDoNghiPhepCuaQuanNguc { get; set; }
        public virtual DbSet<Khu> Khu { get; set; }
        public virtual DbSet<LaoDongCongIch> LaoDongCongIch { get; set; }
        public virtual DbSet<PhamNhan> PhamNhan { get; set; }
        public virtual DbSet<PhongGiam> PhongGiam { get; set; }
        public virtual DbSet<QuanLyBenhTat> QuanLyBenhTat { get; set; }
        public virtual DbSet<QuanNguc> QuanNguc { get; set; }
        public virtual DbSet<ThamGui> ThamGui { get; set; }
        public virtual DbSet<BanGiaoPhamNhan> BanGiaoPhamNhan { get; set; }
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}