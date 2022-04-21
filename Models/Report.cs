using Google.Cloud.Firestore;

namespace us_mod_ms.Models;

[FirestoreData]
public class Report {
  public string? id { get; set; }
  [FirestoreProperty]
  public string? reporter { get; set; }
  [FirestoreProperty]
  public string? cause { get; set; }
  [FirestoreProperty]
  public string? status { get; set; }
  [FirestoreProperty]
  public string? idMessage { get; set; }
  [FirestoreProperty]
  public string? idStream { get; set; }
  [FirestoreProperty]
  public string? assignedModerator { get; set; }
}
