using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MarkCollab.Models
{
  public class User : IdentityUser
  {
    public List<Document> Documents { get; set; }
  }
}