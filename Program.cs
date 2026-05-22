using Interfaces.Entities;
using Interfaces.Interfaces;
using Interfaces.Services;
using System.Globalization;

Console.WriteLine("Enter contract data");
Console.Write("Number: ");
int number = int.Parse(Console.ReadLine() ?? "0");
Console.Write("Date (dd/MM/yyyy): ");
DateTime date = DateTime.ParseExact(
    Console.ReadLine() ?? "",
    "dd/MM/yyyy",
    CultureInfo.InvariantCulture);
Console.Write("Contract value: ");
double contractValue = double.Parse(Console.ReadLine() ?? "0", CultureInfo.InvariantCulture);
Console.Write("Enter number of installments: ");
int numberOfInstallments = int.Parse(Console.ReadLine() ?? "0");

IProcessContractService processContractService = new ProcessContractService(new PaypallService());

Contract contract = new Contract(number, date, contractValue, numberOfInstallments, processContractService);

Console.WriteLine("Installments:");
contract.ListInstallments();