using Autofac;
using Juno.AI.DataAccess.Abstract;
using Juno.AI.DataAccess.Concrete;
using Juno.Data.DataProvider;
using Juno.Data.PostgreSQL;

namespace Juno.AI.Ioc
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataProvider>().As<IRelationalDbProvider>();
            builder.RegisterType<PromptDal>().As<IPromptDal>();
            builder.RegisterType<VisualDal>().As<IVisualDal>();
        }
    }
}