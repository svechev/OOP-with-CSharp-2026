using ServiceReference1;

// snippet
ISomeService soapServiceChannel =
new SomeServiceClient(SomeServiceClient
             .EndpointConfiguration
             .BasicHttpBinding_ISomeService_soap);
var response = await soapServiceChannel.GetMahiroAsync(new GetMahiroRequest()
{
    Body = new GetMahiroRequestBody()
});
Console.WriteLine(response.Body.GetMahiroResult);
