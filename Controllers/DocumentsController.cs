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
    public async Task<IActionResult> GetAllAsync() {
      return Ok(await _context.Documents.ToListAsync());
    }

    [HttpGet("{id}", Name="GetSingleDoc")]
    public async Task<IActionResult> GetSingleAsync(int id) {
      var doc = await _context.Documents.SingleOrDefaultAsync(d => d.Id == id);
      if (doc == null) return NotFound();
      else return Ok(doc);

    }

    [HttpPost("{title}")]
    public async Task<IActionResult> AddNewAsync(string title) {
      var doc = new Document(title);
      _context.Documents.Add(doc);
      if (await _context.SaveChangesAsync() > 0) {
        return Created(Url.Action("GetSingleAsync", new {id = doc.Id}), doc);
      }
      else return BadRequest();
    }

    [HttpPatch("{id}/content")]
    [Consumes("text/plain")]
    public async Task<IActionResult> UpdateContentAsync(int id, [FromBody]string content) {
      var doc = await _context.Documents.SingleAsync(d => d.Id == id);
      if (doc == null) return NotFound();
      if (content == null) return BadRequest();
      doc.Content = content;
      await _context.SaveChangesAsync();
      return await GetSingleAsync(id);
    }

    [HttpPatch("{id}/title")]
    [Consumes("text/plain")]
    public async Task<IActionResult> UpdateTitleAsync(int id, [FromBody]string title) {
      var doc = await _context.Documents.SingleAsync(d => d.Id == id);
      if (doc == null) return NotFound();
      if (title == null) return BadRequest();
      doc.Title = title;
      await _context.SaveChangesAsync();
      return await GetSingleAsync(id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id) {
      var doc = await _context.Documents.SingleOrDefaultAsync(d => d.Id == id);
      if (doc == null) return NotFound();
      _context.Documents.Remove(doc);
      await _context.SaveChangesAsync();
      return NoContent();
    }

    [HttpGet("test")]
    public IActionResult Test() {
      string res = Url.Action("GetSingleAsync", new {id = 2});
      return Ok(res);
    }
  }
}