﻿using System.Configuration;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Website.Models
{
    public class DatabaseContext : IdentityDbContext<User>
    {
        public DatabaseContext()
            : base(ConfigurationManager.AppSettings["CurrentConnectionString"])
        {
            
        }

        public DbSet<InviteKey> InviteKeys { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        public DbSet<LunchPoll> LunchPolls { get; set; }
        public DbSet<LunchOption> LunchOptions { get; set; }
        public DbSet<LunchVote> LunchVotes { get; set; }
    }
}