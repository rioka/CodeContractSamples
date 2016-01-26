using System;
using System.Diagnostics.Contracts;

namespace CodeContractSamples.Core
{
  [ContractClass(typeof(FooServiceContract))]
  public interface IFooService
  {
    void Execute(Guid id);
  }

  /// <summary>
  /// Defines contracts for all implementation of <see cref="IFooService"/>
  /// </summary>
  [ContractClassFor(typeof(IFooService))]
  public abstract class FooServiceContract : IFooService
  {
    void IFooService.Execute(Guid id)
    {
      Contract.Requires<ArgumentException>(id != Guid.Empty, "id");
    }
  }
}
