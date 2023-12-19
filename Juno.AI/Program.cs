using Autofac;
using Autofac.Extensions.DependencyInjection;
using Juno.AI.Ioc;
using Juno.Core.DependencyResolver;
using Juno.Core.Helper;
using Juno.Core.Middlewares;

var builder = WebApplication.CreateBuilder(args);

if (builder.Environment.IsProduction())
{
    builder.Configuration["ConnectionStrings:DefaultConnectionString"] = StringHelper.GetEnvironmentVariableWithDecrypt("ConnectionStringsDefaultConnectionString");
    builder.Configuration["ConnectionStrings:RedisConnectionString"] = StringHelper.GetEnvironmentVariableWithDecrypt("ConnectionStringsRedisConnectionString");
    builder.Configuration["AmazonCredential:AccessId"] = StringHelper.GetEnvironmentVariableWithDecrypt("AmazonCredentialAccessId");
    builder.Configuration["AmazonCredential:SecretKey"] = StringHelper.GetEnvironmentVariableWithDecrypt("AmazonCredentialSecretKey");
    builder.Configuration["AmazonCredential:OpenAiSecretKey"] = StringHelper.GetEnvironmentVariableWithDecrypt("OpenAiSecretKey");
}


builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDependencyResolvers(new CoreModule[] { new CoreModule(builder.Configuration) });
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuiler =>
{
    containerBuiler.RegisterModule(new AdapterModule());
    containerBuiler.RegisterModule(new DataAccessModule());
    containerBuiler.RegisterModule(new BusinessModule());
});
builder.Services.AddAWSLambdaHosting(LambdaEventSource.ApplicationLoadBalancer);

var app = builder.Build();

app.UseCustomExceptionHandler(builder.Configuration);
app.UseTransactionMiddleware();
//app.UseTenantEndDateControlMiddleware(builder.Configuration);

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
