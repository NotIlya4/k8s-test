using Api;
using ExceptionCatcherMiddleware.Extensions;
using Serilog;
using Startup.Extensions;
using Startup.Properties;

var builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
var parameters = new ParametersProvider(builder.Configuration);

services.AddConfiguredExceptionCatcherMiddleware();
services.AddConfiguredSerilog(builder.Configuration, parameters.Seq);

services.AddControllers().AddApplicationPart(typeof(TestController).Assembly);
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

WebApplication app = builder.Build();

app.UseSerilogRequestLogging();
app.UseExceptionCatcherMiddleware();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
