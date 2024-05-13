using BL.Handler.NoteHandler.NoteValidators;
using BL.Interfaces;
using BL.Services;
using DAL.Interface;
using DAL.Models;
using DAL.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using notesApi.Profiler;

namespace notesApi;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration Configuration)
    {
        this.Configuration = Configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        var connection = Configuration.GetConnectionString("ConnectionToNotesDb");
        services.AddDbContext<NotesContext>(options => options.UseSqlServer(connection));

        services.AddAutoMapper(typeof(AutoMapperProfiler));

        //Dependincy injection обязан ижектить все используемые сервисы
        services.AddScoped<INoteRepository, NoteRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IServiceNote, NoteService>();
        services.AddScoped<IServiceUser, UserService>();

        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssemblyContaining<ChangeColorRequestValidator>();
        services.AddFluentValidationClientsideAdapters();

        services.AddAuthentication();
        services.AddControllers().AddNewtonsoftJson();

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseDeveloperExceptionPage();

        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}
