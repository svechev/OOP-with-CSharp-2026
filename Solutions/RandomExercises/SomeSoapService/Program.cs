using SomeSoapService.Business_Logic;
using SoapCore;

// snippet
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSoapCore();
builder.Services.AddScoped<ISomeService, SomeService>();

var app = builder.Build();

app.UseRouting();

_ = app.UseEndpoints(static endpoints =>
{
    endpoints.UseSoapEndpoint<ISomeService>("/SomeService.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
});
app.Run();
