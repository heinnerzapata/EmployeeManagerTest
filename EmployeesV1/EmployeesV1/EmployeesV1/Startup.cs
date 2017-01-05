using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmployeesV1.Startup))]
namespace EmployeesV1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
           
        }
    }
}
