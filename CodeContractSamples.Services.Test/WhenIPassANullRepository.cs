using System;
using NUnit.Framework;

namespace CodeContractSamples.Services.Test
{
  [TestFixture]
  public class WhenIPassANullRepository
  {
    [Test]
    [ExpectedException(typeof(ArgumentNullException))]
    public void An_ArgumentNullException_is_raised()
    {
      // act
      var service = new FooService(null);
    }
  }
}
