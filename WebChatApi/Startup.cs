using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Owin;
using Persistencia.Contextos;
using System.Web.Http;
using WebChatApi.App_Start;

namespace WebChatApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var httpConfig = new HttpConfiguration();
            app.UseWebApi(httpConfig);
            StructuremapWebApi.Start();
            var seeder=new Seeder();
            seeder.Seed();

        }
       
      
    }
    
}