using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using OdataTestNhibernate;
using OdataTestNhibernate.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddNHibernate();
builder.Services.AddControllers().AddOData(opt => opt.EnableQueryFeatures().AddRouteComponents("odata", GetEdmModel()));

var app = builder.Build();
 
app.UseODataRouteDebug();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();

IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<School>("School");

    return builder.GetEdmModel();
}