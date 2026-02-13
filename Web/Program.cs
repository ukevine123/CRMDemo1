using Application.Services;
using Application.Services.Customers;
using Application.Services.Campaigns;
using Application.Services.SupportTickets;
using Application.Services.Identities;
using Infrastructure.DependencyInjection;
using Web.Components;
using MudBlazor.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Add mudservices
    builder.Services.AddMudServices();

    // Register Application Services
builder.Services.AddScoped<ICustomerService, CustomerService>();

   // Register Application Services
builder.Services.AddScoped<ICampaignService, CampaignService>();

  // Register Application Services
builder.Services.AddScoped<ISupportTicketService, SupportTicketService>();

  // Register Application Services
builder.Services.AddScoped<IIdentityService, IdentityService>();


// Dependendy Injection for Infrastructure Layer
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

//Add authentication

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
