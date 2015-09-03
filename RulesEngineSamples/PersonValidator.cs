using RulesEngine;

namespace RulesEngineSamples
{
    public class PersonValidator: IValidationDefinition
    {
        private const string emptyName = "Name should not be empty";
        private const string emptyNumber = "Person number should not be empty";
        private const string numberOnlyDigits = "Person number should contain only digits";

        public void Define(Engine rules)
        {
            rules.For<Person>()
                .Setup(p=>p.Name)
                    .MustNotBeNullOrEmpty().WithMessage(emptyName)
                .Setup(p=>p.Number)
                    .MustNotBeNullOrEmpty().WithMessage(emptyNumber)
                    .MustMatchRegex(@"^[0-9]*$").WithMessage(numberOnlyDigits);
        }
    }
}