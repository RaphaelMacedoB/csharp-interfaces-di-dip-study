using Interfaces.Entities;
using Interfaces.Interfaces;

namespace Interfaces.Services;

public class ProcessContractService : IProcessContractService
{
  private IPaymentService _paymentService;

  public ProcessContractService(IPaymentService paymentService)
  {
    _paymentService = paymentService;
  }
  public List<Installment> GenerateInstallments(Contract contract, int numberOfInstallments)
  {
    List<Installment> installments = [];
    for (int i = 1; i <= numberOfInstallments; i++)
    {
      DateTime date = contract.Date.AddMonths(i);
      double amount = _paymentService.Payment(
        contract.ContractValuePerMonth,
        i
      );
      Installment installment = new Installment(date, amount);
      installments.Add(installment);
    }
    return installments;
  }
}