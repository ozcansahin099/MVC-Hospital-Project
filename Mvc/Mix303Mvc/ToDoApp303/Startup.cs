using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ToDoApp303.Startup))]
namespace ToDoApp303
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
