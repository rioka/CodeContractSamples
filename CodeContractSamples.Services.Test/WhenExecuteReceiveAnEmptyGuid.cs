using System;
using CodeContractSamples.Infrastructure;
using NUnit.Framework;

namespace CodeContractSamples.Services.Test
{
  [TestFixture]
  public class WhenExecuteReceiveAnEmptyGuid
  {
    [Test]
    [ExpectedException(typeof(ArgumentException))]
    public void An_ArgumentException_is_raised()
    {
      // arrange
      var repo = new FooRepository();
      var service = new FooService(repo);

      // act
      service.Execute(Guid.Empty);
    }
  }
}
