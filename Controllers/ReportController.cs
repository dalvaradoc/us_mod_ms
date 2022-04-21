using us_mod_ms.Models;
using us_mod_ms.Services;
using Microsoft.AspNetCore.Mvc;

namespace us_mod_ms.Controllers;

[ApiController]
[Route("[controller]")]
public class ReportController : ControllerBase {

  [HttpGet("{id}")]
  public ActionResult<Report> Get(string id){
    Report report = ReportService.Get(id);
    if (report == null){
      return NotFound();
    }
    return report;
  }

   [HttpGet("unchecked")]
  public ActionResult<List<Report>> GetUnchecked(){
    List<Report> ret = ReportService.GetUnchecked();
    if(!ret.Any()){
      return NotFound();
    }
    return ret;
  }

  [HttpPost]
  public IActionResult Create(Report report){
    ReportService.Add(report);
    return CreatedAtAction(nameof(Create), new {report});
  }

  [HttpPut("{id}")]
  public IActionResult Update(string id, Report report){
    if (report.status == null || report.assignedModerator == null){
      return BadRequest();
    }
    Report oldReport = ReportService.Get(id);
    if (oldReport == null){
      return NotFound();
    }
    ReportService.Update(id, report);
    return NoContent();
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(string id){
    if (ReportService.Get(id) == null){
      return NotFound();
    }
    ReportService.Delete(id);
    return NoContent();
  }
}