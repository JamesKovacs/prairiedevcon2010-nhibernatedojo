using System;
using System.Linq;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Linq;

namespace NhConsoleDemo
{
    class Program
    {
        private static Configuration cfg;
        private static ISessionFactory sessionFactory;

        static void Main() {
            cfg = new Configuration();
            cfg.Configure();

            sessionFactory = cfg.BuildSessionFactory();
            using(var session = sessionFactory.OpenSession())
            using(var tx = session.BeginTransaction())
            {
                var query = from author in session.Linq<Author>()
                            where author.LastName.StartsWith("K")
                            select author;
                foreach(var author in query) {
                    Console.WriteLine("{0} {1}", author.FirstName, author.LastName);
                }
                var james = new Author("172-32-1177", "James", "Kovacs", "403-397-3177", false);
                session.Save(james);
                session.Update(james);
                session.SaveOrUpdate(james);
                tx.Commit();
            }
            Console.WriteLine("Press <ENTER> to exit...");
            Console.ReadLine();
        }
    }
}
