using Interfaces.Interfaces;

namespace Interfaces.Entities;

public class Contract
{
    public int Number { get; set; }
    public DateTime Date { get; set; }
    public double TotalValue { get; set; }
    public int NumberOfInstallments { get; set; }
    private List<Installment> _installments = [];

    public Contract(int number, DateTime date, double totalValue, int numberOfInstallments, IProcessContractService processContractService)
    {
        if (numberOfInstallments <= 0)
        {
            throw new ArgumentException("Number of installments must be greater than zero.", nameof(numberOfInstallments));
        }
        Number = number;
        Date = date;
        TotalValue = totalValue;
        NumberOfInstallments = numberOfInstallments;
        _installments = processContractService.GenerateInstallments(this, NumberOfInstallments);
    }

    public void ListInstallments()
    {
        foreach (Installment installment in _installments)
        {
            Console.WriteLine(installment);
        }
    }

    public double ContractValuePerMonth => TotalValue / NumberOfInstallments;
}