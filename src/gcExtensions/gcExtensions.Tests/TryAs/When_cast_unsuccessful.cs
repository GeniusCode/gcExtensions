using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace gcExtensions.Tests.TryAs
{
    [TestFixture]
    public class When_cast_unsuccessful : SpecificationBase
    {
        private object _something;
        private bool _casted;
        private bool _run;

        protected override void Given()
        {
            _something = "Hello, World";
        }

        protected override void When()
        {
            _casted = _something.TryAs<IDisposable>(i => _run = true);
        }

        [Then]
        public void delegate_should_not_have_run()
        {
            _run.Should().BeFalse();
        }

        [Then]
        public void should_return_false()
        {
            _casted.Should().BeFalse();
        }

    }
}
