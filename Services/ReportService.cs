using us_mod_ms.Models;
using us_mod_ms.Repositories;

namespace us_mod_ms.Services;

public static class ReportService {
  static ReportService(){}

  public static void Add(Report report){
    ReportRepository.Add(report);
  }

  public static Report Get(string id){
    return ReportRepository.getReportById(id).Result;
  }

  public static List<Report> GetUnchecked(){
    return ReportRepository.getUncheckedReports().Result;
  }

  public static void Update(string id, Report report){
    ReportRepository.Update(id, report);
  }

  public static void Delete(string id){
    ReportRepository.Delete(id);
  }
}