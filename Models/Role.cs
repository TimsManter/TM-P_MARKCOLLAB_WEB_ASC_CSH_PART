using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MarkCollab.Models
{
  public class Role : IdentityRole<int>
  {
  }
}