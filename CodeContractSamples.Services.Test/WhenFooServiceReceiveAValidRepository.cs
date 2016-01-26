using CodeContractSamples.Infrastructure;
using NUnit.Framework;

namespace CodeContractSamples.Services.Test
{
  [TestFixture]
  public class WhenFooServiceReceiveAValidRepository
  {
    [Test]
    public void A_new_instance_is_created()
    {
      // arrange
      var repository = new FooRepository();

      // act
      var service = new FooService(repository);

      // assert
      Assert.IsInstanceOf<FooService>(service);
    }
  }
}
