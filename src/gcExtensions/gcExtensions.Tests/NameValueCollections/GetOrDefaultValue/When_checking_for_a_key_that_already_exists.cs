using System.Collections.Specialized;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace gcExtensions.Tests.NameValueCollections.GetOrDefaultValue
{
    [TestFixture]
    public class When_checking_for_a_key_that_already_exists : SpecificationBase
    {
        private readonly NameValueCollection _nvc = new NameValueCollection();
        private string _value;

        protected override void Given()
        {
            _nvc.Add("Breakfast", "Cereal");
            _nvc.Add("Lunch", "Sandwich");
            _nvc.Add("Supper", "Roast Beef");
        }

        protected override void When()
        {
            _value = _nvc.GetOrDefaultValue("Breakfast", "no");
        }

        [Then]
        public void value_returned_should_be_from_collection()
        {
            _value.Should().Be("Cereal");
        }
    }
}