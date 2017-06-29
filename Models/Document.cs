using System;

namespace MarkCollab.Models {
  public class Document {
    public Document(string title) {
      Title = title;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public User Author { get; set; }
  }
}