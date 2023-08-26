namespace Portfolio.Service.DTOs.Payment;

public class PaymentCreationDto
{
    public int Sum { get; set; }
    public string FromCard { get; set; }
    public string ToCard { get; set; }
}
