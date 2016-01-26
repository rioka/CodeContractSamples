using System;
using System.Diagnostics.Contracts;
using CodeContractSamples.Core;

namespace CodeContractSamples.Services
{
  /// <summary>
  /// Implementation for <see cref="IFooService"/>
  /// </summary>
  public class FooService : IFooService
  {
    #region Vars
    
    private readonly IFooRepository _repository;
		 
	  #endregion

    #region Constructors

    public FooService(IFooRepository repository)
    {
      Contract.Requires<ArgumentNullException>(repository != null);
      _repository = repository;
    }

    #endregion

    #region Apis

    public void Execute(Guid id)
    {
      var foo = _repository.GetById(id);
      if (foo != null)
      {
        Console.WriteLine("Got '{0}'", foo.Name);
      }
      else
      {
        Console.WriteLine("No foo found for id '{0}'", id);
      }
    }

    #endregion
  }
}
