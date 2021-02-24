using IASHandyMan.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace IASHandyMan.ServicesRest
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "ServiceRegisterTime" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione ServiceRegisterTime.svc o ServiceRegisterTime.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class ServiceRegisterTime : IServiceRegisterTime
    {
        public void DoWork()
        {
        }

        public string NuevoChisteCategoria(string categoria)
        {
            throw new NotImplementedException();
        }

        public string validarEmpleado()
        {
            try
            {
                return DBConexion.GetLogin(11, "HolaMund");
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
