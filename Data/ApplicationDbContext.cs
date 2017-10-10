using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using fantasyFootball.Models;

namespace fantasyFootball.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<FantasyTeamModel> FantasyTeams {get;set;}
        public DbSet<PlayersModel> FantasyPlayers {get;set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<fantasyFootball.Models.FantasyTeamModel> FantasyTeamModel { get; set; }

        public DbSet<fantasyFootball.Models.PlayersModel> PlayersModel { get; set; }
    }
}
