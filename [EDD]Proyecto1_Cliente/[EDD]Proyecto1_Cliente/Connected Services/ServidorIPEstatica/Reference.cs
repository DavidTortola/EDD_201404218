﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _EDD_Proyecto1_Cliente.ServidorIPEstatica {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServidorIPEstatica.WebService1Soap")]
    public interface WebService1Soap {
        
        // CODEGEN: Generating message contract since element name HelloWorldResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/HelloWorld", ReplyAction="*")]
        _EDD_Proyecto1_Cliente.ServidorIPEstatica.HelloWorldResponse HelloWorld(_EDD_Proyecto1_Cliente.ServidorIPEstatica.HelloWorldRequest request);
        
        // CODEGEN: Generating message contract since element name nickname from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/insertarUsuario", ReplyAction="*")]
        _EDD_Proyecto1_Cliente.ServidorIPEstatica.insertarUsuarioResponse insertarUsuario(_EDD_Proyecto1_Cliente.ServidorIPEstatica.insertarUsuarioRequest request);
        
        // CODEGEN: Generating message contract since element name graficarUsuariosResult from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/graficarUsuarios", ReplyAction="*")]
        _EDD_Proyecto1_Cliente.ServidorIPEstatica.graficarUsuariosResponse graficarUsuarios(_EDD_Proyecto1_Cliente.ServidorIPEstatica.graficarUsuariosRequest request);
        
        // CODEGEN: Generating message contract since element name nickname from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/insertarJuego", ReplyAction="*")]
        _EDD_Proyecto1_Cliente.ServidorIPEstatica.insertarJuegoResponse insertarJuego(_EDD_Proyecto1_Cliente.ServidorIPEstatica.insertarJuegoRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/limpiar", ReplyAction="*")]
        void limpiar();
        
        // CODEGEN: Generating message contract since element name nickname from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/eliminarUsuario", ReplyAction="*")]
        _EDD_Proyecto1_Cliente.ServidorIPEstatica.eliminarUsuarioResponse eliminarUsuario(_EDD_Proyecto1_Cliente.ServidorIPEstatica.eliminarUsuarioRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorld", Namespace="http://tempuri.org/", Order=0)]
        public _EDD_Proyecto1_Cliente.ServidorIPEstatica.HelloWorldRequestBody Body;
        
        public HelloWorldRequest() {
        }
        
        public HelloWorldRequest(_EDD_Proyecto1_Cliente.ServidorIPEstatica.HelloWorldRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class HelloWorldRequestBody {
        
        public HelloWorldRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class HelloWorldResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="HelloWorldResponse", Namespace="http://tempuri.org/", Order=0)]
        public _EDD_Proyecto1_Cliente.ServidorIPEstatica.HelloWorldResponseBody Body;
        
        public HelloWorldResponse() {
        }
        
        public HelloWorldResponse(_EDD_Proyecto1_Cliente.ServidorIPEstatica.HelloWorldResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class HelloWorldResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string HelloWorldResult;
        
        public HelloWorldResponseBody() {
        }
        
        public HelloWorldResponseBody(string HelloWorldResult) {
            this.HelloWorldResult = HelloWorldResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class insertarUsuarioRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="insertarUsuario", Namespace="http://tempuri.org/", Order=0)]
        public _EDD_Proyecto1_Cliente.ServidorIPEstatica.insertarUsuarioRequestBody Body;
        
        public insertarUsuarioRequest() {
        }
        
        public insertarUsuarioRequest(_EDD_Proyecto1_Cliente.ServidorIPEstatica.insertarUsuarioRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class insertarUsuarioRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string nickname;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string contraseña;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=2)]
        public string correoElectronico;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public bool conectado;
        
        public insertarUsuarioRequestBody() {
        }
        
        public insertarUsuarioRequestBody(string nickname, string contraseña, string correoElectronico, bool conectado) {
            this.nickname = nickname;
            this.contraseña = contraseña;
            this.correoElectronico = correoElectronico;
            this.conectado = conectado;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class insertarUsuarioResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="insertarUsuarioResponse", Namespace="http://tempuri.org/", Order=0)]
        public _EDD_Proyecto1_Cliente.ServidorIPEstatica.insertarUsuarioResponseBody Body;
        
        public insertarUsuarioResponse() {
        }
        
        public insertarUsuarioResponse(_EDD_Proyecto1_Cliente.ServidorIPEstatica.insertarUsuarioResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class insertarUsuarioResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string insertarUsuarioResult;
        
        public insertarUsuarioResponseBody() {
        }
        
        public insertarUsuarioResponseBody(string insertarUsuarioResult) {
            this.insertarUsuarioResult = insertarUsuarioResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class graficarUsuariosRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="graficarUsuarios", Namespace="http://tempuri.org/", Order=0)]
        public _EDD_Proyecto1_Cliente.ServidorIPEstatica.graficarUsuariosRequestBody Body;
        
        public graficarUsuariosRequest() {
        }
        
        public graficarUsuariosRequest(_EDD_Proyecto1_Cliente.ServidorIPEstatica.graficarUsuariosRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class graficarUsuariosRequestBody {
        
        public graficarUsuariosRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class graficarUsuariosResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="graficarUsuariosResponse", Namespace="http://tempuri.org/", Order=0)]
        public _EDD_Proyecto1_Cliente.ServidorIPEstatica.graficarUsuariosResponseBody Body;
        
        public graficarUsuariosResponse() {
        }
        
        public graficarUsuariosResponse(_EDD_Proyecto1_Cliente.ServidorIPEstatica.graficarUsuariosResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class graficarUsuariosResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string graficarUsuariosResult;
        
        public graficarUsuariosResponseBody() {
        }
        
        public graficarUsuariosResponseBody(string graficarUsuariosResult) {
            this.graficarUsuariosResult = graficarUsuariosResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class insertarJuegoRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="insertarJuego", Namespace="http://tempuri.org/", Order=0)]
        public _EDD_Proyecto1_Cliente.ServidorIPEstatica.insertarJuegoRequestBody Body;
        
        public insertarJuegoRequest() {
        }
        
        public insertarJuegoRequest(_EDD_Proyecto1_Cliente.ServidorIPEstatica.insertarJuegoRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class insertarJuegoRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string nickname;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string oponente;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=2)]
        public int unidadesDesplegadas;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=3)]
        public int unidadesSobrevivientes;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=4)]
        public int unidadesDestruidas;
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=5)]
        public bool gano;
        
        public insertarJuegoRequestBody() {
        }
        
        public insertarJuegoRequestBody(string nickname, string oponente, int unidadesDesplegadas, int unidadesSobrevivientes, int unidadesDestruidas, bool gano) {
            this.nickname = nickname;
            this.oponente = oponente;
            this.unidadesDesplegadas = unidadesDesplegadas;
            this.unidadesSobrevivientes = unidadesSobrevivientes;
            this.unidadesDestruidas = unidadesDestruidas;
            this.gano = gano;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class insertarJuegoResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="insertarJuegoResponse", Namespace="http://tempuri.org/", Order=0)]
        public _EDD_Proyecto1_Cliente.ServidorIPEstatica.insertarJuegoResponseBody Body;
        
        public insertarJuegoResponse() {
        }
        
        public insertarJuegoResponse(_EDD_Proyecto1_Cliente.ServidorIPEstatica.insertarJuegoResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class insertarJuegoResponseBody {
        
        public insertarJuegoResponseBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class eliminarUsuarioRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="eliminarUsuario", Namespace="http://tempuri.org/", Order=0)]
        public _EDD_Proyecto1_Cliente.ServidorIPEstatica.eliminarUsuarioRequestBody Body;
        
        public eliminarUsuarioRequest() {
        }
        
        public eliminarUsuarioRequest(_EDD_Proyecto1_Cliente.ServidorIPEstatica.eliminarUsuarioRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class eliminarUsuarioRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string nickname;
        
        public eliminarUsuarioRequestBody() {
        }
        
        public eliminarUsuarioRequestBody(string nickname) {
            this.nickname = nickname;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class eliminarUsuarioResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="eliminarUsuarioResponse", Namespace="http://tempuri.org/", Order=0)]
        public _EDD_Proyecto1_Cliente.ServidorIPEstatica.eliminarUsuarioResponseBody Body;
        
        public eliminarUsuarioResponse() {
        }
        
        public eliminarUsuarioResponse(_EDD_Proyecto1_Cliente.ServidorIPEstatica.eliminarUsuarioResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class eliminarUsuarioResponseBody {
        
        public eliminarUsuarioResponseBody() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface WebService1SoapChannel : _EDD_Proyecto1_Cliente.ServidorIPEstatica.WebService1Soap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class WebService1SoapClient : System.ServiceModel.ClientBase<_EDD_Proyecto1_Cliente.ServidorIPEstatica.WebService1Soap>, _EDD_Proyecto1_Cliente.ServidorIPEstatica.WebService1Soap {
        
        public WebService1SoapClient() {
        }
        
        public WebService1SoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public WebService1SoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        _EDD_Proyecto1_Cliente.ServidorIPEstatica.HelloWorldResponse _EDD_Proyecto1_Cliente.ServidorIPEstatica.WebService1Soap.HelloWorld(_EDD_Proyecto1_Cliente.ServidorIPEstatica.HelloWorldRequest request) {
            return base.Channel.HelloWorld(request);
        }
        
        public string HelloWorld() {
            _EDD_Proyecto1_Cliente.ServidorIPEstatica.HelloWorldRequest inValue = new _EDD_Proyecto1_Cliente.ServidorIPEstatica.HelloWorldRequest();
            inValue.Body = new _EDD_Proyecto1_Cliente.ServidorIPEstatica.HelloWorldRequestBody();
            _EDD_Proyecto1_Cliente.ServidorIPEstatica.HelloWorldResponse retVal = ((_EDD_Proyecto1_Cliente.ServidorIPEstatica.WebService1Soap)(this)).HelloWorld(inValue);
            return retVal.Body.HelloWorldResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        _EDD_Proyecto1_Cliente.ServidorIPEstatica.insertarUsuarioResponse _EDD_Proyecto1_Cliente.ServidorIPEstatica.WebService1Soap.insertarUsuario(_EDD_Proyecto1_Cliente.ServidorIPEstatica.insertarUsuarioRequest request) {
            return base.Channel.insertarUsuario(request);
        }
        
        public string insertarUsuario(string nickname, string contraseña, string correoElectronico, bool conectado) {
            _EDD_Proyecto1_Cliente.ServidorIPEstatica.insertarUsuarioRequest inValue = new _EDD_Proyecto1_Cliente.ServidorIPEstatica.insertarUsuarioRequest();
            inValue.Body = new _EDD_Proyecto1_Cliente.ServidorIPEstatica.insertarUsuarioRequestBody();
            inValue.Body.nickname = nickname;
            inValue.Body.contraseña = contraseña;
            inValue.Body.correoElectronico = correoElectronico;
            inValue.Body.conectado = conectado;
            _EDD_Proyecto1_Cliente.ServidorIPEstatica.insertarUsuarioResponse retVal = ((_EDD_Proyecto1_Cliente.ServidorIPEstatica.WebService1Soap)(this)).insertarUsuario(inValue);
            return retVal.Body.insertarUsuarioResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        _EDD_Proyecto1_Cliente.ServidorIPEstatica.graficarUsuariosResponse _EDD_Proyecto1_Cliente.ServidorIPEstatica.WebService1Soap.graficarUsuarios(_EDD_Proyecto1_Cliente.ServidorIPEstatica.graficarUsuariosRequest request) {
            return base.Channel.graficarUsuarios(request);
        }
        
        public string graficarUsuarios() {
            _EDD_Proyecto1_Cliente.ServidorIPEstatica.graficarUsuariosRequest inValue = new _EDD_Proyecto1_Cliente.ServidorIPEstatica.graficarUsuariosRequest();
            inValue.Body = new _EDD_Proyecto1_Cliente.ServidorIPEstatica.graficarUsuariosRequestBody();
            _EDD_Proyecto1_Cliente.ServidorIPEstatica.graficarUsuariosResponse retVal = ((_EDD_Proyecto1_Cliente.ServidorIPEstatica.WebService1Soap)(this)).graficarUsuarios(inValue);
            return retVal.Body.graficarUsuariosResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        _EDD_Proyecto1_Cliente.ServidorIPEstatica.insertarJuegoResponse _EDD_Proyecto1_Cliente.ServidorIPEstatica.WebService1Soap.insertarJuego(_EDD_Proyecto1_Cliente.ServidorIPEstatica.insertarJuegoRequest request) {
            return base.Channel.insertarJuego(request);
        }
        
        public void insertarJuego(string nickname, string oponente, int unidadesDesplegadas, int unidadesSobrevivientes, int unidadesDestruidas, bool gano) {
            _EDD_Proyecto1_Cliente.ServidorIPEstatica.insertarJuegoRequest inValue = new _EDD_Proyecto1_Cliente.ServidorIPEstatica.insertarJuegoRequest();
            inValue.Body = new _EDD_Proyecto1_Cliente.ServidorIPEstatica.insertarJuegoRequestBody();
            inValue.Body.nickname = nickname;
            inValue.Body.oponente = oponente;
            inValue.Body.unidadesDesplegadas = unidadesDesplegadas;
            inValue.Body.unidadesSobrevivientes = unidadesSobrevivientes;
            inValue.Body.unidadesDestruidas = unidadesDestruidas;
            inValue.Body.gano = gano;
            _EDD_Proyecto1_Cliente.ServidorIPEstatica.insertarJuegoResponse retVal = ((_EDD_Proyecto1_Cliente.ServidorIPEstatica.WebService1Soap)(this)).insertarJuego(inValue);
        }
        
        public void limpiar() {
            base.Channel.limpiar();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        _EDD_Proyecto1_Cliente.ServidorIPEstatica.eliminarUsuarioResponse _EDD_Proyecto1_Cliente.ServidorIPEstatica.WebService1Soap.eliminarUsuario(_EDD_Proyecto1_Cliente.ServidorIPEstatica.eliminarUsuarioRequest request) {
            return base.Channel.eliminarUsuario(request);
        }
        
        public void eliminarUsuario(string nickname) {
            _EDD_Proyecto1_Cliente.ServidorIPEstatica.eliminarUsuarioRequest inValue = new _EDD_Proyecto1_Cliente.ServidorIPEstatica.eliminarUsuarioRequest();
            inValue.Body = new _EDD_Proyecto1_Cliente.ServidorIPEstatica.eliminarUsuarioRequestBody();
            inValue.Body.nickname = nickname;
            _EDD_Proyecto1_Cliente.ServidorIPEstatica.eliminarUsuarioResponse retVal = ((_EDD_Proyecto1_Cliente.ServidorIPEstatica.WebService1Soap)(this)).eliminarUsuario(inValue);
        }
    }
}
