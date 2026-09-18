using SoapCore;
using TradeSOAPService.Business_logic;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSoapCore();
builder.
Services.AddSingleton<IOrderWService, TradeProducts>();

var app = builder.Build();

app.UseRouting();

_ = app.UseEndpoints(static endpoints =>
{
    endpoints.UseSoapEndpoint<IOrderWService>("/Service.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
});
app.Run();

