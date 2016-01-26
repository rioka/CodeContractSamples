using System;
using System.Diagnostics.Contracts;

namespace CodeContractSamples.Core
{
  [ContractClass(typeof(FooRepositoryContract))]
  public interface IFooRepository
  {
    Foo GetById(Guid id);
  }

  /// <summary>
  /// Defines contracts for all implementation of <see cref="IFooRepository"/>
  /// </summary>
  [ContractClassFor(typeof(IFooRepository))]
  public abstract class FooRepositoryContract : IFooRepository
  {
    Foo IFooRepository.GetById(Guid id)
    {
      Contract.Requires<ArgumentException>(id != Guid.Empty, "id");

      return default(Foo);
    }
  }
}
