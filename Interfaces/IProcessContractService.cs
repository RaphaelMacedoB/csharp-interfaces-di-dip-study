using Interfaces.Entities;

namespace Interfaces.Interfaces;

public interface IProcessContractService
{
    public List<Installment> GenerateInstallments(Contract contract, int numberOfInstallments);
}