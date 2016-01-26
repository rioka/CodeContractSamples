using System;

namespace CodeContractSamples.Core
{
  public class Foo
  {
    public Guid Id { get; private set; }
    public string Name { get; set; }

    public Foo(Guid id)
    {
      Id = id;
    }
  }
}
