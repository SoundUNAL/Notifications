using MongoDB.Driver;
using NotificationsMS.Models;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Extensions.DependencyInjection;
using Amazon.Util.Internal.PlatformServices;
using Microsoft.Extensions.Options;
using NotificationsMS.Services;
using Microsoft.Extensions.Configuration;

internal class Program
{
    


    public void ConfigureServices(IServiceCollection services)
    {
        
        
    }
    private static void Main(string[] args)
    {

        //Create InfoNotificationDB.InsertOne(infoNotification);
        //Read List<InfoNotification> lst = InfoNotificationDB.Find(d=>true).ToList();
        //Update InfoNotificationDB.ReplaceOne(d => d.Id == "65efdc15fd36aac4c556e0a9", infoNotification);
        //Delete InfoNotificationDB.DeleteOne(d => d.Id == "65efdc15fd36aac4c556e0a9");

        

        
        var builder = WebApplication.CreateBuilder(args);

        var configuration = builder.Configuration;

        // Add services to the container.
        builder.Services.AddRazorPages();

        builder.Services.AddSingleton<IConfiguration>(configuration);

        builder.Services.Configure<NotiSettings>
            (configuration.GetSection(nameof(NotiSettings)));
        builder.Services.Configure<DistributionSettings>
            (configuration.GetSection("DistributionSettings"));
        builder.Services.AddSingleton<INotiSettings>(d => d.GetRequiredService<IOptions<NotiSettings>>().Value);
       
        builder.Services.AddSingleton<IDistributionNotification>(d=>d.GetRequiredService<IOptions<DistributionSettings>>().Value);

        builder.Services.AddSingleton<DistributionNotiService>();
        builder.Services.AddSingleton<NotificationService>();
        builder.Services.AddControllers();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapRazorPages();

        app.MapControllers();

        app.Run();
        
    }
}