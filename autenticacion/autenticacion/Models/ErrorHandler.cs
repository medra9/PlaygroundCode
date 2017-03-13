using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace autenticacion.Models
{
    public class ErrorHandler : HandleErrorAttribute
    {
        public ILog Logger { get; set; }
        public override void OnException(ExceptionContext filterContext)
        {
            Log(filterContext.Exception);
            base.OnException(filterContext);
        }

        public void Log(Exception ex)
        {
            this.Logger = LogManager.GetLogger(Assembly.GetExecutingAssembly().GetTypes().First());
            log4net.Config.XmlConfigurator.Configure();
            this.Logger.Info(string.Format("{0} | {1}", ex.StackTrace, ex.Message));
        }

        public void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0}- controller:{1} action:{2}", methodName,
                                                                        controllerName,
                                                                        actionName);
            this.Logger = LogManager.GetLogger(Assembly.GetExecutingAssembly().GetTypes().First());
            log4net.Config.XmlConfigurator.Configure();
            this.Logger.Info(message);
        }

    }
}