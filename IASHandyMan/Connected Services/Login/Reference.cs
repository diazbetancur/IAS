﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IASHandyMan.Login {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Login.IServiceRegisterTime")]
    public interface IServiceRegisterTime {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceRegisterTime/DoWork", ReplyAction="http://tempuri.org/IServiceRegisterTime/DoWorkResponse")]
        void DoWork();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceRegisterTime/DoWork", ReplyAction="http://tempuri.org/IServiceRegisterTime/DoWorkResponse")]
        System.Threading.Tasks.Task DoWorkAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceRegisterTime/validarEmpleado", ReplyAction="http://tempuri.org/IServiceRegisterTime/validarEmpleadoResponse")]
        string validarEmpleado();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceRegisterTime/validarEmpleado", ReplyAction="http://tempuri.org/IServiceRegisterTime/validarEmpleadoResponse")]
        System.Threading.Tasks.Task<string> validarEmpleadoAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceRegisterTime/NuevoChisteCategoria", ReplyAction="http://tempuri.org/IServiceRegisterTime/NuevoChisteCategoriaResponse")]
        string NuevoChisteCategoria(string categoria);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IServiceRegisterTime/NuevoChisteCategoria", ReplyAction="http://tempuri.org/IServiceRegisterTime/NuevoChisteCategoriaResponse")]
        System.Threading.Tasks.Task<string> NuevoChisteCategoriaAsync(string categoria);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceRegisterTimeChannel : IASHandyMan.Login.IServiceRegisterTime, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceRegisterTimeClient : System.ServiceModel.ClientBase<IASHandyMan.Login.IServiceRegisterTime>, IASHandyMan.Login.IServiceRegisterTime {
        
        public ServiceRegisterTimeClient() {
        }
        
        public ServiceRegisterTimeClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceRegisterTimeClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceRegisterTimeClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceRegisterTimeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void DoWork() {
            base.Channel.DoWork();
        }
        
        public System.Threading.Tasks.Task DoWorkAsync() {
            return base.Channel.DoWorkAsync();
        }
        
        public string validarEmpleado() {
            return base.Channel.validarEmpleado();
        }
        
        public System.Threading.Tasks.Task<string> validarEmpleadoAsync() {
            return base.Channel.validarEmpleadoAsync();
        }
        
        public string NuevoChisteCategoria(string categoria) {
            return base.Channel.NuevoChisteCategoria(categoria);
        }
        
        public System.Threading.Tasks.Task<string> NuevoChisteCategoriaAsync(string categoria) {
            return base.Channel.NuevoChisteCategoriaAsync(categoria);
        }
    }
}
