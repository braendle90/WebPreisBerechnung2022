﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using WebPreisBerechnungAuB.Models;

namespace WebPreisBerechnungAuB.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ArticleTextil> ArticleTextil { get; set; }
        public DbSet<ArticelMain> ArticelMain { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Logo> Logos { get; set; }
        public DbSet<ExtraCharge> ExtraCharge { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<OrderPositionLogo> OrderPositionLogos { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<PositionLogo> PositionLogos { get; set; }
        public DbSet<Textil> Textils { get; set; }
        public DbSet<TextilColor> TextilColors { get; set; }
        public DbSet<LogoExtraCharge> LogoExtraCharge { get; set; }
        public DbSet<ExtraChargeList> ExtraChargeList { get; set; }

        //Price Data

        public DbSet<File> Files { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<RangeTable> RangeTable { get; set; }
        public DbSet<ApplicationTransfer> ApplicationTransfer { get; set; }
        public DbSet<PriceTable> PriceTable { get; set; }
        public DbSet<PriceTableTransfer> PriceTableTransfer { get; set; }
        public DbSet<RangeSurfaceSize> RangeSurfaceSizes { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        public DbSet<StockFileHistory> StockFileHistories { get; set; }

    }
}
