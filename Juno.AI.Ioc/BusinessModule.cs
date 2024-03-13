using Autofac;
using Juno.AI.Business.Abstract;
using Juno.AI.Business.Concrete;

namespace Juno.AI.Ioc
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PromptService>().As<IPromptService>();
            builder.RegisterType<PromptHistoryService>().As<IPromptHistoryService>();
            builder.RegisterType<VisualService>().As<IVisualService>();
        }
    }
}