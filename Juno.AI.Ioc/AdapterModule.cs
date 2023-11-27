using Autofac;
using Juno.OpenAI.Adapter.Abstract;
using Juno.OpenAI.Adapter.Concrete;

namespace Juno.AI.Ioc
{
    public class AdapterModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ChatGPTAdapter>().As<IChatGPTAdapter>();
            builder.RegisterType<DallEAdapter>().As<IDallEAdapter>();
        }
    }
}
