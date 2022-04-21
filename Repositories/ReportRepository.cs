using Google.Cloud.Firestore;
using us_mod_ms.Models;

namespace us_mod_ms.Repositories;

public static class ReportRepository {
  static string projectId = "us-mod-ms-188e4";

  static FirestoreDb db = FirestoreDb.Create(projectId);

  static CollectionReference collection = db.Collection("reports");
  
  async public static void Add(Report report){
    DocumentReference document = await collection.AddAsync(report);
  }

  async public static Task<Report> getReportById (string id) {
    DocumentSnapshot snapshot = await collection.Document(id).GetSnapshotAsync();
    Report report = snapshot.ConvertTo<Report>();
    report.id = snapshot.Id;
    return report;
  }

  async public static Task<List<Report>> getUncheckedReports (){
    Query query = collection.WhereEqualTo("status", "unchecked");
    QuerySnapshot querySnapshot = await query.GetSnapshotAsync();
    List<Report> ret = new List<Report>();
    foreach (DocumentSnapshot queryResult in querySnapshot.Documents){
      // ret.Add(queryResult.ConvertTo<Report>());
      Report report = queryResult.ConvertTo<Report>();
      report.id = queryResult.Id;
      ret.Add(report);
    }
    return ret;
  }

  async public static void Update(string id, Report report){
    Dictionary<FieldPath, object> updates = new Dictionary<FieldPath, object>
    {
        { new FieldPath("status"), report.status },
        { new FieldPath("assignedModerator"), report.assignedModerator }
    };

    await collection.Document(id).UpdateAsync(updates);
  }

  async public static void Delete(string id){
    await collection.Document(id).DeleteAsync();
  }
}