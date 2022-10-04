using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using serviceweb.AutosNet.Models;
namespace serviceweb.AutosNet
{
    /// <summary>
    /// Descripción breve de AutossWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class AutossWebService : System.Web.Services.WebService
    {

        DBCursoConexion conexion = new DBCursoConexion();
        #region AUTOS
        [WebMethod (Description ="Devuelve la lista de Autos")]
        public List<Auto> todo_los_Autos()
        {
            try
            {
                var prueba = (from c in conexion.Autos select c).ToList();
                return prueba;
            }
            catch (Exception)
            {
                List<Auto> listavacia = new List<Auto>();
                return listavacia;
            }
        }


        [WebMethod (Description ="Agrega mas autos ala base de datos")]
        public bool insertaAuto(string marca, string modelo, string color, string año, int precio)
        {
            try
            {
                Auto Agrega = new Auto();
                Agrega.id = Guid.NewGuid();
                Agrega.marca = marca;
                Agrega.modelo = modelo;
                Agrega.color = color;
                Agrega.ano = año;
                Agrega.precio = precio;
                conexion.Autos.Add(Agrega);
                conexion.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        [WebMethod (Description ="Metodo que modifica datos de la base de daos")]
        public bool modificaAuto(string id, string marca, string modelo, string año)
        {
            try
            {
                var idi = Guid.Parse(id);
                var consulta = (from a in conexion.Autos where a.id == idi select a).FirstOrDefault();
                
                if (consulta != null)
                {
                    consulta.marca = marca;
                    consulta.modelo = modelo;
                    consulta.ano = año;                   
                    conexion.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }



        [WebMethod(Description = "Metodo que Elimina datos de la base de daos")]
        public bool eliminaAuto(string id)
        {
            try
            {
                var idi = Guid.Parse(id);
                var consulta = (from a in conexion.Autos where a.id == idi select a).FirstOrDefault();

                if (consulta != null)
                {
                    conexion.Autos.Remove(consulta);
                    conexion.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        #endregion
    }
}
