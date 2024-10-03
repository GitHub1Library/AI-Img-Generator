using AI_Img_Generator.Components;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add Razor Pages and Interactive Server Components
builder.Services.AddRazorPages();  // Add this line
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


// This line will ensure that any requests to the root ("/") or "/home" show the Home component
app.MapRazorPages(); 

app.UseAntiforgery(); 


app.MapBlazorHub();
// Map Razor components
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();