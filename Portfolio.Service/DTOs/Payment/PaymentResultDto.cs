namespace Portfolio.Service.DTOs.Payment;

public class PaymentResultDto
{
    public long Id { get; set; }
    public int Sum { get; set; }
    public string FromCard { get; set; }
    public string ToCard { get; set; }
}