using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace gcExtensions.Tests.Dictionary.AddIfUniqueOrCreate
{
    [TestFixture]
    public class When_trying_to_add_key_that_already_exists_with_true_predicate : SpecificationBase
    {
        private IDictionary<int, string> _dictionary;
        private int _originalDictionaryCount;
        private bool _returnValue;

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
            _returnValue = _dictionary.AddIfUniqueOrReplace("Gregory", 1,()=> true);
        }

        [Then]
        public void dictionary_count_should_not_have_changed()
        {
            _dictionary.Count.Should().Be(_originalDictionaryCount);
        }

        [Then]
        public void dictionary_value_of_new_key_should_be_correct()
        {
            _dictionary[1].Should().Be("Gregory");
        }

        [Then]
        public void should_return_true()
        {
            _returnValue.Should().BeTrue();
        }
    }




}