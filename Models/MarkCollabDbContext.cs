using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MarkCollab.Models {
  public class MarkCollabDbContext : IdentityDbContext<User, Role, int> {
    public DbSet<Document> Documents { get; set; }
    public DbSet<Token> Tokens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
      optionsBuilder.UseSqlite("Data Source=markcollab.db");
    }
  }
}