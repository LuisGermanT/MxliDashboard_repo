using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace MxliDashboard
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            DevExpress.XtraReports.Web.ASPxWebDocumentViewer.StaticInitialize();
        }

        //Erick Z. - 02/12/2021
        //As per last auditory in our IIS Server many applications were not using HTTPS
        protected void Application_BeginRequest()
        {
            // Ensure any request is returned over SSL/TLS in production
            if (!Request.IsLocal && !Context.Request.IsSecureConnection)
            {
                var redirect = Context.Request.Url.ToString().ToLower(CultureInfo.CurrentCulture).Replace("http:", "https:");
                Response.Redirect(redirect);
            }
        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs.

            // Get last error from the server
            Exception exc = Server.GetLastError();
            var code = (exc is HttpException) ? (exc as HttpException).GetHttpCode() : 500;

            if (exc is HttpUnhandledException)
            {
                if (exc.InnerException != null)
                {
                    exc = new Exception(exc.InnerException.Message);
                    Server.Transfer("Errors.aspx?handler=Application_Error%20-%20Global.asax",
                        true);
                }
            }
        }
    }
}