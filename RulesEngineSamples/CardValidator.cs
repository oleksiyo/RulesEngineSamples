using RulesEngine;

namespace RulesEngineSamples
{
    public class CardValidator : IValidationDefinition
    {
        public void Define(Engine rules)
        {
            rules.For<Card>()
                .Setup(p => p.CardNumber)
                    .MustNotBeNullOrEmpty().WithMessage("Card number should be not empty")
                .Setup(c => c.Person).MustNotBeNull().CallValidate();
        }
    }
}