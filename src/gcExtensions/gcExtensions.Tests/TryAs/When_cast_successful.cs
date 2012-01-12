using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace gcExtensions.Tests.TryAs
{
    [TestFixture]
    public class When_cast_successful : SpecificationBase
    {
        private object _something;
        private int _stringLength;
        private bool _casted;

        protected override void Given()
        {
            _something = "Hello, World";
        }

        protected override void When()
        {
            _casted =  _something.TryAs<string>(s => _stringLength = s.Length);
        }

        [Then]
        public void lambda_should_have_been_exectued()
        {
            _stringLength.Should().Be(12);
        }

        [Then] public void should_return_true()
        {
            _casted.Should().BeTrue();
        }

    }
}