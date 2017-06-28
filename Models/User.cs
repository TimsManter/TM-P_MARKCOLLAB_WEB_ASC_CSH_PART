using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MarkCollab.Models
{
  public class User : IdentityUser
  {
    public string Name { get; set; }
    public List<Document> Documents { get; set; }
  }
}