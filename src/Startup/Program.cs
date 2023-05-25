using Api;
using Core.Extensions;
using ExceptionCatcherMiddleware.Extensions;
using Serilog;
using Startup.Extensions;
using Startup.Properties;

var builder = WebApplication.CreateBuilder(args);
IServiceCollection services = builder.Services;
var parameters = new ParametersProvider(builder.Configuration);

services.AddAll(parameters.SqlServer);
services.AddConfiguredExceptionCatcherMiddleware();
services.AddConfiguredSerilog(builder.Configuration, parameters.Seq);

services.AddControllers().AddApplicationPart(typeof(TestNotesController).Assembly);
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

WebApplication app = builder.Build();

await app.ConfigureDb();

app.UseSerilogRequestLogging();
app.UseExceptionCatcherMiddleware();

app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();

app.Run();
