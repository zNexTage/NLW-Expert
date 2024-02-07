using Microsoft.EntityFrameworkCore;
using RocketseatAuction.API.Entities;

namespace RocketseatAuction.API.Repositories;

public class RocketseatAuctionDbContext : DbContext
{
    // public RocketseatAuctionDbContext(DbContextOptions<RocketseatAuctionDbContext> options) : base(options)
    // {
    //     
    // }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=D:\\MeusProjetos\\RocketseatAuction\\leilaoDbNLW.db");
    }

    public DbSet<Auction> Auctions { get; set; }
}