using RulesEngine;

namespace RulesEngineSamples
{
    public class PersonValidator: IValidationDefinition
    {
        private const string emptyName = "Name should not be empty";

        public void Define(Engine rules)
        {
            rules.For<Person>()
                .Setup(p=>p.Name)
                    .MustNotBeNullOrEmpty()
                    .WithMessage(emptyName);
        }
    }
}
