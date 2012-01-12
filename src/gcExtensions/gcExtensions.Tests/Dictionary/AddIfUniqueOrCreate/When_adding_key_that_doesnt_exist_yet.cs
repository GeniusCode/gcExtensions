using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace gcExtensions.Tests.Dictionary.AddIfUniqueOrCreate
{
    [TestFixture]
    public class When_adding_key_that_doesnt_exist_yet_with_false_predicate : SpecificationBase
    {
        private IDictionary<int, string> _dictionary;
        private int _originalDictionaryCount;
        bool _returnValue;

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
            _returnValue = _dictionary.AddIfUniqueOrReplace("Gregory", 5,()=> false);
        }

        [Then]
        public void dictionary_item_should_be_added()
        {
            _dictionary.Count.Should().Be(_originalDictionaryCount + 1);
        }

        [Then]
        public void new_dictionary_key_should_exist()
        {
            _dictionary.ContainsKey(5).Should().BeTrue();
        }

        [Then]
        public void dictionary_value_of_new_key_should_be_correct()
        {
            _dictionary[5].Should().Be("Gregory");
        }

        [Then]
        public void should_return_true()
        {
            _returnValue.Should().BeTrue();
        }
    }
}
