// See https://aka.ms/new-console-template for more information
using DataManager.Utils;
using DataManager.Database;
const string CONNECTION_NAME = "PaymentRegistry";

try
{
    Console.WriteLine("Hello, World!");
    // initializating the test DB Context
    PaymentContext context = new PaymentContext(ConfigurationHelper.ParseConnectionString(CONNECTION_NAME));
    //initializing the DB context for DatabaseHelper
    DatabaseHelper.InitializeContext(CONNECTION_NAME);
    // Update DB with Migrations and Seed
    DatabaseHelper.UpdateAndSeed();
    // Save changes to DB (transaction) - OBLIGATORY
    DatabaseHelper.SaveChanges();
    // Select payment with max CustomId
    // using MaxBy()
    //var payment = context.PaymentItems.MaxBy(p => p.CustomId); - MaxBy is not supported by EF Core (at least for SQL Server)
    // testing workaround LINQ to Objects query
    var mustBeSamePayment = context.PaymentItems.OrderByDescending(p => Convert.ToInt32(p.CustomId)).FirstOrDefault();

    
} catch(Exception e){
    Console.WriteLine("ERROR: \nMSG:" + e.Message + "\nTRACE: " + e.StackTrace + "\nINNER: " + e.InnerException);
}
