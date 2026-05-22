using Interfaces.Interfaces;

namespace Interfaces.Services;

public class PaypallService : IPaymentService
{
    public double Payment(double amount, int month)
    {
        double totalPayment = amount;
        totalPayment += amount * 0.01 * month;
        totalPayment += totalPayment * 0.02;
        return totalPayment;
    }
}