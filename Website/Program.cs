using Blazored.LocalStorage;
using Hesketh.MecatolArchives.API.Client.Extensions;
using Hesketh.MecatolArchives.Website.Components;
using Hesketh.MecatolArchives.Website.Services;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddTransient<IPreferenceStore, CookiePreferenceStore>();

var apiUrl = builder.Configuration.GetValue<string>("APIUrl");
if (string.IsNullOrEmpty(apiUrl))
    throw new InvalidOperationException("No APIUrl was specified");
builder.Services.AddClients(new Uri(apiUrl));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();