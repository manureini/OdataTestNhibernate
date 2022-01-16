using Microsoft.Extensions.DependencyInjection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Reflection;

namespace OdataTestNhibernate
{
    public static class Extensions
    {
        public static void AddNHibernate(this IServiceCollection pServiceCollection)
        {
            pServiceCollection.AddSingleton<ISessionFactory>((provider) =>
            {
                var cfg = new Configuration();
                cfg.Configure(@"hibernate.cfg.xml");

                cfg.AddAssembly(Assembly.GetExecutingAssembly());

                RunSchemaUpdate(cfg);

                return cfg.BuildSessionFactory();
            });

            pServiceCollection.AddScoped<ISession>((provider) =>
            {
                ISessionFactory factory = provider.GetService<ISessionFactory>();
                return factory.OpenSession();
            });
        }

        public static void RunSchemaUpdate(this Configuration cfg)
        {
            var update = new SchemaUpdate(cfg);
            update.Execute(true, true);

            if (update.Exceptions.Count > 0)
            {
                foreach (var exception in update.Exceptions)
                {
                    Console.WriteLine(exception);
                    throw exception;
                }
            }
        }
    }
}
