using System;
using System.Collections.Generic;

namespace MarkCollab.Models
{
  public class User
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Document> Documents { get; set; }
  }
}