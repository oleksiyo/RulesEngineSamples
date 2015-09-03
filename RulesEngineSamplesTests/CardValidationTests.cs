using FluentAssertions;
using RulesEngineSamples;
using Xunit.Extensions;

namespace RulesEngineSamplesTests
{
    public class CardValidationTests
    {
        private readonly Validator validator;

        public CardValidationTests()
        {
            validator = new Validator();
        }

        [Theory, NSubData]
        public void should_be_not_valid_if_card_number_is_empty(Card card)
        {
            card.CardNumber = "";
            card.Person.Number = "123";

            var result = validator.Validate(card);
            
            result.Success.Should().BeFalse();
            result.Error.Should().Be("Card number should be not empty");
        }

        [Theory, NSubData]
        public void should_be_not_valid_if_person_is_null(Card card)
        {
            card.Person = null;

            var result = validator.Validate(card);

            result.Success.Should().BeFalse();
        }

        [Theory, NSubData]
        public void should_be_not_valid_if_person_number_contains_not_only_digits(Card card)
        {
            var result = validator.Validate(card);
            
            result.Success.Should().BeFalse();
            result.Error.Should().Be("Person number should contain only digits");
        }
    }
}