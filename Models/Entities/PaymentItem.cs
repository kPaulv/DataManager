namespace DataManager.Models.Entities;

public class PaymentItem
{
    public PaymentItem()
    {
        CustomId = "";
    }
    public int Id { get; set; }
    public string CustomId { get; set; }
    public DateTime CustomDate { get; set; }
    public DateTime PayDateTime { get; set; }
    public DateTime UsedDate { get; set; }
    public long TransactionId { get; set; }
    public int Agent { get; set; }
    public int ServiceNo { get; set; }
}