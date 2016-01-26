using System;
using CodeContractSamples.Core;
using CodeContractSamples.Infrastructure;
using CodeContractSamples.Services;

namespace CodeContractSamples.App
{
  /// <summary>
  /// Sample application testing contracts
  /// </summary>
  class Program
  {
    static void Main(string[] args)
    {
      var guid1 = Guid.Parse(FooRepository.Guid1);
      var repo = CreateRepository();

      repo.CheckEmptyGuid();
      repo.CheckMissingGuid();
      repo.CheckValidGuid(guid1);

      CreateServiceWithNullRepository();

      var service = CreateServiceWithValidRepository(repo);
      service.CheckEmptyGuid();
      service.CheckValidGuid(guid1);
      service.CheckMissingGuid();
    }

    #region Internals
    
    private static IFooRepository CreateRepository()
    {
      Console.WriteLine("Trying to create an instance of {0} service", typeof(FooRepository).Name);
      return new FooRepository();
    }

    private static IFooService CreateServiceWithValidRepository(IFooRepository repo)
    {
      Console.WriteLine("Trying to create an instance of {0} service", typeof(FooService).Name);
      return new FooService(repo);
    }

    private static void CreateServiceWithNullRepository()
    {
      Console.WriteLine("Trying to create an instance of {0} service with a null repository", typeof(FooService).Name);
      try
      {
        var service = new FooService(null);
      }
      catch (ArgumentNullException ane)
      {
        Console.WriteLine("\tGot an ArgumentNullException: " + ane.Message);
      }
    }

    #endregion
  }

  #region Extension methods
  
  public static class Extensions
  {
    #region IFooRepository
    
    public static void CheckValidGuid(this IFooRepository repo, Guid guid)
    {
      Console.WriteLine("Trying to get an existing foo");
      var foo = repo.GetById(guid);
      Console.WriteLine("\tGot '{0}'", foo.Name);
    }

    public static void CheckMissingGuid(this IFooRepository repo)
    {
      Console.WriteLine("Trying to get a missing foo");
      var foo = repo.GetById(Guid.NewGuid());
      Console.WriteLine("\tFoo is null {0}", foo == null);
    }

    public static void CheckEmptyGuid(this IFooRepository repo)
    {
      Console.WriteLine("Trying to get a foo with by an empty id");
      try
      {
        repo.GetById(Guid.Empty);
      }
      catch (ArgumentException ae)
      {
        Console.WriteLine("\tGot an ArgumentException: " + ae.Message);
      }
    }

    #endregion

    #region IFooService

    public static void CheckEmptyGuid(this IFooService service)
    {
      Console.WriteLine("Trying to process a foo with by an empty id");
      try
      {
        service.Execute(Guid.Empty);
      }
      catch (ArgumentException ae)
      {
        Console.WriteLine("\tGot an ArgumentException: " + ae.Message);
      }
    }

    public static void CheckValidGuid(this IFooService service, Guid guid)
    {
      Console.WriteLine("Trying to process an existing foo");
      service.Execute(guid);
    }

    public static void CheckMissingGuid(this IFooService service)
    {
      Console.WriteLine("Trying to process a missing foo");
      service.Execute(Guid.NewGuid());
    }

    #endregion

  }

  #endregion
}
