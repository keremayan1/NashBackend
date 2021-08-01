using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Utilities.IoC;
using Core.Utilities.Mail;
using Core.Utilities.ReCaptcha;
using Core.Utilities.ReCaptcha.GoogleReCaptcha;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<Stopwatch>();
            services.AddSingleton<IRecaptchaValidator, GoogleReChaptcaValidator>();
            services.AddSingleton<IEmailConfiguration, EmailConfiguration>();
            services.AddSingleton<IMailService, MailManager>();
        }
    }
}
