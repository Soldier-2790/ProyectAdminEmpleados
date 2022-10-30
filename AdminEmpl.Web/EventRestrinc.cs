using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;

namespace AdminEmpl.Web
{
    public class EventRestrinc : IRouteConstraint
    {
        //Esta clase implementa restricciones de ruteo para las direcciones que consulten personal con el ID
        public bool Match(HttpContext httpContext, IRouter route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
        {
            //Obteniendo el id sí el residuo de la división entre 2 del id es 0 mostrará la info y dejará visualizar pero sí es lo contrario no mostrará nada
            int id;
            if (Int32.TryParse(values["id"].ToString(), out id))
            {
                if (id % 2 == 0)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
