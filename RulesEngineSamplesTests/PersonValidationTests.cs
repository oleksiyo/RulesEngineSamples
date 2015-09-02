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
        private readonly PersonValidator validator;
        readonly Engine engine = new Engine();
        private ValidationReport report;
        public PersonValidationTests()
        {         
            validator = new PersonValidator();
            validator.Define(engine);
            report = new ValidationReport(engine);
        }


        [Fact]
        public void should_implement_interface_IValidationDefinition()
        {
            validator.Should().BeAssignableTo<IValidationDefinition>();
        }

        [Theory, NSubData]
        public void name_should_be_not_empty(Person person)
        {
            person.Name = "";
            
            var result = report.Validate(person);
            var errorMsg = report.GetErrorMessages(person);

            result.Should().BeFalse();
            errorMsg.First().Should().Be("Name should not be empty");
        }


    }
}
