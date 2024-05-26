using System.Reflection;
using TransactionService.Application.Contracts.Commands;

namespace TransactionService.Application;

public static class Assemblies
{
    public static readonly Assembly Application = typeof(InternalCommandBase).Assembly;
}