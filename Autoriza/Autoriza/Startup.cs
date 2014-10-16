using System;
using Autoriza.Jobs;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.OwinHost;
using Owin;

[assembly: OwinStartupAttribute(typeof(Autoriza.Startup))]
namespace Autoriza
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            app.UseNinjectMiddleware(GetKernel);

            ConfigureHangFire(app);
        }
        
        private void ConfigureHangFire(IAppBuilder app)
        {
            app.UseHangfire(config =>
            {
                config.UseSqlServerStorage(
                    @"Data Source=G1711MAX\sqlexpress;Password=chapado;User ID=sa;Initial Catalog=autoriza;Application Name=Autoriza;");
                config.UseServer();
                config.UseNinjectActivator(GetKernel());
            });

            // RecurringJob.AddOrUpdate<VerificaSistemaOnline>(online => online.Verifica(), Cron.Minutely);
        }

        private IKernel GetKernel()
        {
            Bootstrapper bootstrapper = new Bootstrapper();

            return bootstrapper.Kernel;
        }

    }
}
