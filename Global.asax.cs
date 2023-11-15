using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace ChatGnocchiPastaTransformer
{
    public class Global : System.Web.HttpApplication
    {
        public static readonly MarkovChainBot bot = new MarkovChainBot();

        protected void Application_Start(object sender, EventArgs e)
        {
            bot.Train(Server.MapPath("~/combined.txt"));

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}