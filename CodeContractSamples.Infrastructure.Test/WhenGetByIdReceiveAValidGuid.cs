using System;
using NUnit.Framework;

namespace CodeContractSamples.Infrastructure.Test
{
  [TestFixture]
  public class WhenGetByIdReceiveAValidGuid
    {
      [Test]
      public void A_foo_is_returned_if_we_found_a_matching_id()
      {
        // arrange
        var repo = new FooRepository();

        // act
        var foo = repo.GetById(Guid.Parse(FooRepository.Guid1));

        // assert
        Assert.IsNotNull(foo);
        Assert.AreEqual(FooRepository.Guid1.ToLower(), foo.Id.ToString().ToLower());
      }

      [Test]
      public void Null_is_returned_if_a_match_does_not_exist()
      {
        // arrange
        var repo = new FooRepository();

        // act
        var foo = repo.GetById(Guid.NewGuid());

        // assert
        Assert.IsNull(foo);
      }
    }
}
