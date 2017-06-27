using System;

namespace MarkCollab.Models {
  public class Token {
    public string Key { get; set; }
    public string[] Scopes { get; set; }
  }
}