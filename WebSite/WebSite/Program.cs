using Microsoft.AspNetCore.ResponseCompression;
using System.Net;
using WebSite.HttpLifecycle;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
    options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "text/javascript" });
});

builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 443;
});

builder.Services.AddHsts(options =>
{
    options.IncludeSubDomains = true;
    options.MaxAge = TimeSpan.FromDays(365);
});

builder.Services.AddControllersWithViews();



var app = builder.Build();

app.Use(async (context, next) =>
{
    context.Response.Headers.Remove("Server");

    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Add("X-Frame-Options", "deny");
    context.Response.Headers.Add("Referrer-Policy", "no-referrer");
    context.Response.Headers.Add("X-Xss-Protection", "1; mode=block");
    context.Response.Headers.Add("X-Permitted-Cross-Domain-Policies", "none");
    context.Response.Headers.Add("Permissions-Policy", "accelerometer=(), camera=(), geolocation=(), gyroscope=(), magnetometer=(), microphone=(), payment=(), usb=()");

    await next();
});

app.UseStatusCodePages(context =>
{
    int statusCode = context.HttpContext.Response.StatusCode;

    // Non mi piace dover fare il redirect alla pagina degli errori per un not allowed
    if (statusCode != (int)HttpStatusCode.MethodNotAllowed)
    {
        context.HttpContext.Response.Redirect($"/error/{statusCode}");
    }

    return Task.CompletedTask;
});

app.UseHttpsRedirection();
app.UseHsts();
app.UseResponseCompression();

app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = context =>
    {
        // Posso cachare per sempre tutti i contenuti statici perché sono versionati, così li scarica solo se sono realmente nuovi (immutable)
        context.Context.Response.Headers.Append("Cache-Control", "public, max-age=31536000, immutable");
    },
    ContentTypeProvider = CustomMiddlewares.GenerateStaticFilesContentProvider()
});

app.UseRouting();
app.UseDefaultFiles();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
