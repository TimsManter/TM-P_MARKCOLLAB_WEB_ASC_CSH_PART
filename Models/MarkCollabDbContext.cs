using System;
using Microsoft.EntityFrameworkCore;

namespace MarkCollab.Models {
  public class MarkCollabDbContext : DbContext {
    public DbSet<User> Users { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<Token> Tokens { get; set; }
  }
}