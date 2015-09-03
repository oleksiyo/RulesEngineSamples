using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Ninject;
using RulesEngine;
using RulesEngineSamples;
using Xunit;
using Xunit.Extensions;

namespace RulesEngineSamplesTests
{
    public class PersonValidationTests
    {
        private readonly PersonValidator personValidator;
        private readonly Validator validator;
        readonly Engine engine = new Engine();
        private ValidationReport report;
        public PersonValidationTests()
        {
            personValidator = new PersonValidator();
            validator = new Validator();
           // personValidator.Define(engine);
            report = new ValidationReport(engine);
        }


        [Fact]
        public void should_implement_interface_IValidationDefinition()
        {
            personValidator.Should().BeAssignableTo<IValidationDefinition>();
        }

        [Theory, NSubData]
        public void name_should_be_not_empty(Person person)
        {
            person.Number = "123";
            person.Name = "";

            var result = validator.Validate(person);

            result.Success.Should().BeFalse();
            result.Error.Should().Be("Name should not be empty");
        }


        [Theory, NSubData]
        public void person_number_should_be_not_empty(Person person)
        {
            person.Number = "";

            var result = validator.Validate(person);

            result.Success.Should().BeFalse();
            result.Error.Should().Be("Person number should not be empty");
        }

        [Theory, NSubData]
        public void should_be_valid_if_person_number_contain_only_digits(Person person)
        {
            person.Number = "12345";

            var result = validator.Validate(person);

            result.Success.Should().BeTrue();
            result.Error.Should().Be("");
        }

        [Theory, NSubData]
        public void should_be_not_valid_if_person_number_contain_not_only_digits(Person person)
        {
            person.Number = "12345A";

            var result = validator.Validate(person);

            result.Success.Should().BeFalse();
            result.Error.Should().Be("Person number should contain only digits");
        }
    }
}
