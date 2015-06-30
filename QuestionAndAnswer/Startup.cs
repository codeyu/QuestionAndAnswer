using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuestionAndAnswer.Startup))]
namespace QuestionAndAnswer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
