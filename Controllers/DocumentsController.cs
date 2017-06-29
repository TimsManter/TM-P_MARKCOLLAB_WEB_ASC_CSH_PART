using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarkCollab.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarkCollab.Controllers {
  [Route("api/docs")]
  public class DocumentsController : Controller {
    private MarkCollabDbContext _context;
    public DocumentsController(MarkCollabDbContext context) {
      _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Document>> GetAllAsync() {
      return await _context.Documents.ToListAsync();
    }

    [HttpGet]
    public async Task<IActionResult> GetSingleAsync() {
      var doc = await _context.Documents.SingleOrDefaultAsync();
      if (doc == null) return NotFound();
      else return Ok(doc);

    }

    [HttpPost("{title}")]
    public async Task<IActionResult> AddNewAsync(string title) {
      var doc = new Document(title);
      _context.Documents.Add(doc);
      if (await _context.SaveChangesAsync() > 0) {
        return Created(Url.ToString(), doc);
      }
      else return BadRequest();
    }

    [HttpPatch("{id}/content")]
    public async Task<IActionResult> UpdateContentAsync(int id, [FromBody]string content) {
      var doc = await _context.Documents.SingleAsync(d => d.Id == id);
      if (doc == null) return NotFound();
      if (content == null) return BadRequest();
      doc.Content = content;
      await _context.SaveChangesAsync();
      return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id) {
      var doc = await _context.Documents.SingleOrDefaultAsync(d => d.Id == id);
      if (doc == null) return NotFound();
      _context.Documents.Remove(doc);
      await _context.SaveChangesAsync();
      return NoContent();
    }
  }
}