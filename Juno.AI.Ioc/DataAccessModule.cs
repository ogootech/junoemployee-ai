using Autofac;
using Juno.AI.DataAccess.Abstract;
using Juno.AI.DataAccess.Concrete;

namespace Juno.AI.Ioc
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PromptDal>().As<IPromptDal>();
            builder.RegisterType<VisualDal>().As<IVisualDal>();
        }
    }
}