using BlazorApp4.Client.Pages;
using BlazorApp4.Components;
using BlazorApp4.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies"; // Set the default scheme (e.g., cookie authentication)
    options.DefaultChallengeScheme = "Cookies"; // Set the default challenge scheme
})
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/Login";
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
});
builder.Services.AddSingleton<UserService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
// Add authorization middleware
app.UseAuthorization();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BlazorApp4.Client._Imports).Assembly);

app.Run();
