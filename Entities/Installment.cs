namespace Interfaces.Entities;

public class Installment
{
    public DateTime DueDate { get; private set; }
    public double Amount { get; private set; }

    public Installment(DateTime dueDate, double amount)
    {
        DueDate = dueDate;
        Amount = amount;
    }

    public override string ToString()
    {
        return $"{DueDate:dd/MM/yyyy} - {Amount:F2}";
    }
}