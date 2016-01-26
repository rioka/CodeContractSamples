using System;
using NUnit.Framework;

namespace CodeContractSamples.Infrastructure.Test
{
  [TestFixture]
  public class WhenGetByIdReceiveAnEmptyGuid
  {
    [Test]
    [ExpectedException(typeof(ArgumentException))]
    public void An_ArgumentException_is_raised()
    {
      // arrange
      var repo = new FooRepository();

      // act
      var foo = repo.GetById(Guid.Empty);
    }
  }
}
