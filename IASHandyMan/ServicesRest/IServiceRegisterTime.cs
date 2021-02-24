using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace IASHandyMan.ServicesRest
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServiceRegisterTime" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServiceRegisterTime
    {
        [OperationContract]
        void DoWork();

        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "validarEmpleado")]
        string validarEmpleado();

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "nuevochistecat/{categoria}")]
        string NuevoChisteCategoria(string categoria);
    }
}
