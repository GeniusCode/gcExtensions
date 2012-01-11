using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace gcExtensions.Tests.Dictionary
{
    [TestFixture]
    public class When_getting_a_value_for_an_existing_key : SpecificationBase
    {
        private IDictionary<int, string> _dictionary;
        string _value;
        private int _originalDictionaryCount;
        private bool _wasCreated;


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
            _originalDictionaryCount = _dictionary.Count;
        }

        protected override void When()
        {
            _value = _dictionary.GetOrCreateValue(0, () => "unkown", out _wasCreated);
        }

        [Then]
        public void value_should_match_dictionary()
        {
            _value.Should().BeEquivalentTo("George");
        }

        [Then]
        public void dictionary_count_should_be_unchanged()
        {
            _originalDictionaryCount.Should().Be(_dictionary.Count);
        }

        [Then]
        public void wascreated_variable_should_be_false()
        {
            _wasCreated.Should().BeFalse();
        }

    }
}
