using Autofac;
using Autofac.Extensions.DependencyInjection;
using Juno.AI.Ioc;
using Juno.Core.DependencyResolver;
using Juno.Core.Helper;
using Juno.Core.Middlewares;

var builder = WebApplication.CreateBuilder(args);


if (builder.Environment.IsProduction())
{
    builder.Configuration["OpenAiSecretKey"] = Environment.GetEnvironmentVariable("OpenAiSecretKey");
    builder.Configuration["ConnectionStrings:DefaultConnectionString"] = StringHelper.GetEnvironmentVariableWithDecrypt("ConnectionStringsDefaultConnectionString");
    builder.Configuration["ConnectionStrings:RedisConnectionString"] = StringHelper.GetEnvironmentVariableWithDecrypt("ConnectionStringsRedisConnectionString");
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

builder.Services.AddHealthChecks();



var app = builder.Build();

app.UseCustomExceptionHandler(builder.Configuration);
app.UseTransactionMiddleware();
//app.UseTenantEndDateControlMiddleware(builder.Configuration);
app.UseSecurityMiddleware();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.UseHealthChecks("/ai/health");
app.UseHealthChecks("/ai-test/health");
app.UseHealthChecks("/ai-prod/health");

app.Run();



