using System.Linq;
using FluentAssertions;
using RulesEngineSamples;
using Xunit;
using Xunit.Extensions;

namespace RulesEngineSamplesTests
{
    public class ValidatorTests
    {
        private readonly Validator validator;
        public ValidatorTests()
        {
            validator = new Validator();
        }

        [Fact]
        public void should_implement_interface_IValidator()
        {
            validator.Should().BeAssignableTo<IValidator>();
        }

        [Fact]
        public void should_get_all_modules()
        {
            var modules = validator.GetModules();

            modules.Count().Should().BeGreaterOrEqualTo(1);
        }

       [Theory, NSubData]
        public void should_be_valid(Person person)
       {
          var result = validator.Validate(person);
           result.Success.Should().BeTrue();
       }

       [Theory, NSubData]
       public void should_be_not_valid(Person person)
       {
           person.Name = "";
           var result = validator.Validate(person);
           result.Success.Should().BeFalse();
           result.Error.Should().Be("Name should not be empty");
       }
    }
}
