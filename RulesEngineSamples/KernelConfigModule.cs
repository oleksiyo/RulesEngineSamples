using Ninject.Modules;

namespace RulesEngineSamples
{
    public class KernelConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IValidationDefinition>().To<PersonValidator>();
        }
    }
}
