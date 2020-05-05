using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using recolocacao.Dominio.Entidades;
using recolocacao.Dominio.Handlers.Usuario;
using recolocacao.Dominio.Repositories;
using recolocacao.Infra.Context;
using recolocacao.Infra.Repositories;

namespace recolocacao.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEntityFrameworkNpgsql()
                        .AddDbContext<DataContext>(opt => 
                            opt.UseNpgsql(Configuration.GetConnectionString("connectionString")));

            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<CriarUsuarioHandler, CriarUsuarioHandler>();

            //"connectionString": "Host=localhost;Port=5432;Username=postgres;Password=PRO2010nim;Database=recolocacaodb;"


        }

        public ParametrosPagamento ObterPagto(int cdTributo, decimal vlTribPgoEstAlte)
        {
            return new ParametrosPagamentoBuilder()
                            .ComTributo(cdTributo)
                            .ComValor(vlTribPgoEstAlte)
                            .Build();
        }

        Dim pgtoBuilder As New ParametrosPagamentoBuilder()

        With pgtoBuilder
            .ComTributo(cdTributo)
            .ComValor(vlTribPgoEstAlte)
        End With

        Return pgtoBuilder.Build()

    End Function

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

           app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());            

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
