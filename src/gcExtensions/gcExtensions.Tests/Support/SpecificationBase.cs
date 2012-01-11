using System.Linq;
using NUnit.Framework;

namespace gcExtensions.Tests
{
    public class SpecificationBase
    {
        [SetUp]
        public void Setup()
        {
            Given();
            When();
        }
        protected virtual void Given()
        { }
        protected virtual void When()
        { }
    }
}