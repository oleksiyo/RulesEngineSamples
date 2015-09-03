using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Ninject;
using RulesEngine;

namespace RulesEngineSamples
{
    public interface IValidator
    {
        Result Validate(object obj);
    }

    public class Result
    {
        public bool Success { get; set; }
        public string Error { get; set; }
    }

    public class Validator : IValidator
    {
        readonly Engine rulesEngine = new Engine();
        private readonly ValidationReport report;

        public Validator()
        {
            InitRuleEngine();
            report = new ValidationReport(rulesEngine);
        }

        public IEnumerable<IValidationDefinition> GetModules()
        {
            IKernel kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var modules = kernel.GetAll<IValidationDefinition>().ToList();
            return modules;
        }

        private void InitRuleEngine()
        {
            var modules = GetModules();
            modules.ToList().ForEach(m => m.Define(rulesEngine));
        }

        public Result Validate(object obj)
        {
            var errors = "";
            var valid = report.Validate(obj);
            
            if (!valid)
                errors = report.GetErrorMessages(obj).Aggregate((i, j) => i + ", " + j);
              
            return new Result
            {
                Success = rulesEngine.Validate(obj),
                Error = errors
            };
        }
    }
}