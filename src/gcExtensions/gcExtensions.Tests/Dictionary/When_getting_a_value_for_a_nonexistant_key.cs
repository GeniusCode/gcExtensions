using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace gcExtensions.Tests.Dictionary
{
    [TestFixture]
    public class When_getting_a_value_for_a_nonexistant_key : SpecificationBase
    {
        private IDictionary<int, string> _dictionary;
        string _value;
        private bool _wasCreated;
        private int originalDictionaryCount;

        protected override void Given()
        {

            _dictionary = new Dictionary<int, string>
                              {
                                  {0, "George"}, 
                                  {1, "Paul"}, 
                                  {2, "Peter"}, 
                                  {3, "Henry"}, 
                                  {4, "Thomas"}
                              };

            originalDictionaryCount = _dictionary.Count;
        }

        protected override void When()
        {
            _value = _dictionary.GetOrCreateValue(5, () => "unknown", out _wasCreated);
        }

        [Then]
        public void value_should_match_lambda_output()
        {
            _value.Should().BeEquivalentTo("unknown");
        }

        [Then]
        public void value_should_have_been_added_to_dictionary()
        {
            _dictionary.Count.Should().Be(originalDictionaryCount + 1);
        }

        [Then]
        public void wascreated_variable_should_be_true()
        {
            _wasCreated.Should().BeTrue();
        }

        [Then]
        public void dictionary_should_contain_new_key()
        {
            _dictionary.ContainsKey(5).Should().BeTrue();
        }

        [Then]
        public void new_value_should_be_inside_the_dictionary()
        {
            _dictionary[5].Should().Be("unknown");

        }



    }
}