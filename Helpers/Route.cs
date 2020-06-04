using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RutasCheck.Helpers
{
    public static class Route
    {
        public static string IsActive(this HtmlHelper html, 
            string controlls, 
            string actions,
            string cssClass)
        {
            string currentAction = html.ViewContext.RouteData.Values["action"] as string;
            string currentController = html.ViewContext.RouteData.Values["controller"] as string;

            IEnumerable<string> acceptedControls = controlls.Trim().Split(',').Distinct().ToArray();
            IEnumerable<string> aceptedActions = actions.Trim().Split(',').Distinct().ToArray();

            return acceptedControls.Contains(currentController) && aceptedActions.Contains(currentAction) ? cssClass:String.Empty;
        }
    }
}
