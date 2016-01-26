using System;
using System.Linq;
using CodeContractSamples.Core;

namespace CodeContractSamples.Infrastructure
{
  /// <summary>
  /// Implementation for <see cref="IFooRepository"/>
  /// </summary>
  public class FooRepository : IFooRepository
  {
    public const string Guid1 = "C858F76C-98CB-4F47-8C6E-F59496E47E79";
    public const string Guid2 = "354ADFA0-F643-4D73-B86A-D902F59D5CAB";
    public const string Guid3 = "C1752F61-1C25-48D4-8F5D-85D7AF326624";

    #region Vars
    
    /// <summary>
    /// Mock data
    /// </summary>
    private static readonly Foo[] Foos = {
      new Foo(Guid.Parse(Guid1)) {
        Name = "John"
      }, 
      new Foo(Guid.Parse(Guid2)){
        Name = "James"
      }, 
      new Foo(Guid.Parse(Guid3)){
        Name = "Paul"
      }
    }; 

    #endregion

    #region Apis

    public Foo GetById(Guid id)
    {
      return Foos.FirstOrDefault(f => f.Id == id);
    }

    #endregion
  }
}
