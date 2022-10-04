using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ServicioWebAutoss.Models;
namespace ServicioWebAutoss
{
    /// <summary>
    /// Descripción breve de AutosDBWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class AutosDBWebService : System.Web.Services.WebService
    {
        #region PROIEDADES
        DBpruebaConexion conexion = new DBpruebaConexion();
        #endregion

        #region  
        [WebMethod]
        public List<Auto> ObtenerAutos()
        {
            try
            {
                var consulta = (from c in conexion.Autos select c).ToList();
                return consulta;
            }
            catch(Exception )
            {
                List<Auto> listaVacia = new List<Auto>();
                return listaVacia;
            }
            
        }
        #endregion

    }
}
