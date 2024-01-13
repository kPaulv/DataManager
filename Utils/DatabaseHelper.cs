namespace DataManager.Utils;

using DataManager.Database;
using DataManager.Models.Entities;
using Microsoft.EntityFrameworkCore;

public class DatabaseHelper{
    private static PaymentContext _context = new PaymentContext();

    public static void InitializeContext(string connectionStringName) {
        _context = new PaymentContext(ConfigurationHelper.ParseConnectionString(connectionStringName));
    }

    public static void UpdateAndSeed(){
        // update DB if needed
        _context.Database.Migrate();

        // if DB table PaymentItems is empty, seed it
        if(_context.PaymentItems.Count() == 0) {
            Seed();
        }
    }

    private static void Seed(){
        // TODO: use list and change _context.Table.Add() to AddRange()
        //var payments = new List<PaymentItem>();
        
        var dbSettings = ConfigurationHelper.ParseDbSettings();
        if(dbSettings != null) {
            int seedingAmount = dbSettings.SeedingAmount;
            int customId = dbSettings.InitialCustomId;
            DateTime date = dbSettings.InitialDate;

            for (int i = 0; i < seedingAmount; i++)
            {
                _context.PaymentItems.Add(CreateSeedingPayment(customId, date));
                customId += 2;
                date.AddDays(1);
            }
        }
    }

    private static PaymentItem CreateSeedingPayment(int customId, DateTime date) {
        Random random = new Random();

        return new PaymentItem
        {
            CustomId = customId.ToString(),
            CustomDate = date,
            PayDateTime = date.AddMinutes(10),
            UsedDate = date.AddMinutes(15),
            TransactionId = random.NextInt64(),
            Agent = random.Next(10),
            ServiceNo = random.Next(71)
        };
    }

    public static void SaveChanges() {
        _context.SaveChanges();
    }
}