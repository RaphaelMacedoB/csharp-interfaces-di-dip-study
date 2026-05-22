# C# Interfaces, DI & Dependency Inversion — Study Project

A small **educational** console application in **C# / .NET** that practices **interfaces**, **manual dependency injection**, and the **Dependency Inversion Principle (DIP)**. The sample domain processes a contract into monthly installments and applies payment fees through pluggable services, without coupling business logic to a specific payment provider.

> This repository is for **learning only**. It is not production software.

## What you will practice

- Defining **contracts** with interfaces (`IPaymentService`, `IProcessContractService`)
- **Injecting** concrete implementations via constructors (manual DI in `Program.cs`)
- **DIP**: high-level code depends on abstractions, not on `PaypallService` directly
- Separating **entities**, **services**, and the **application entry point**

## How it works

1. The user enters contract number, date, total value, and installment count.
2. `ProcessContractService` generates monthly installments from the contract date.
3. For each installment, `PaypallService` calculates the amount with fees.
4. The contract prints all installments to the console.

## Project structure

```
├── Entities/
│   ├── Contract.cs
│   └── Installment.cs
├── Interfaces/
│   ├── IPaymentService.cs
│   └── IProcessContractService.cs
├── Services/
│   ├── PaypallService.cs
│   └── ProcessContractService.cs
├── Program.cs
└── Interfaces.csproj
```

## Requirements

- [.NET SDK 10](https://dotnet.microsoft.com/download) (or a compatible SDK for `net10.0`)

## Run

From the repository root:

```bash
dotnet run
```

Example input:

```
Number: 8012
Date (dd/MM/yyyy): 25/12/2018
Contract value: 600
Enter number of installments: 3
```

Example output:

```
Installments:
25/01/2019 - 206.04
25/02/2019 - 208.08
25/03/2019 - 210.12
```

## Payment fee rules (current implementation)

`PaypallService` applies, on top of the base installment amount:

- **1% per month** multiplied by the installment index
- An additional **2%** on the resulting amount

To add another provider (e.g. bank transfer), implement `IPaymentService` and pass it to `ProcessContractService` — no changes required inside the installment generator.

## Tech stack

- C# / .NET 10
- Console application

## License

Educational use — feel free to study, fork, and adapt.
