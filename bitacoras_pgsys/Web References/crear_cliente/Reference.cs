﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// Microsoft.VSDesigner generó automáticamente este código fuente, versión=4.0.30319.42000.
// 
#pragma warning disable 1591

namespace bitacoras_pgsys.crear_cliente {
    using System;
    using System.Web.Services;
    using System.Diagnostics;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;
    using System.ComponentModel;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2053.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name="crear_clienteBinding", Namespace="urn:ws_mysqlBitacora")]
    public partial class crear_cliente : System.Web.Services.Protocols.SoapHttpClientProtocol {
        
        private System.Threading.SendOrPostCallback Callcrear_clienteOperationCompleted;
        
        private bool useDefaultCredentialsSetExplicitly;
        
        /// <remarks/>
        public crear_cliente() {
            this.Url = global::bitacoras_pgsys.Properties.Settings.Default.bitacoras_pgsys_crear_cliente_crear_cliente;
            if ((this.IsLocalFileSystemWebService(this.Url) == true)) {
                this.UseDefaultCredentials = true;
                this.useDefaultCredentialsSetExplicitly = false;
            }
            else {
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        public new string Url {
            get {
                return base.Url;
            }
            set {
                if ((((this.IsLocalFileSystemWebService(base.Url) == true) 
                            && (this.useDefaultCredentialsSetExplicitly == false)) 
                            && (this.IsLocalFileSystemWebService(value) == false))) {
                    base.UseDefaultCredentials = false;
                }
                base.Url = value;
            }
        }
        
        public new bool UseDefaultCredentials {
            get {
                return base.UseDefaultCredentials;
            }
            set {
                base.UseDefaultCredentials = value;
                this.useDefaultCredentialsSetExplicitly = true;
            }
        }
        
        /// <remarks/>
        public event Callcrear_clienteCompletedEventHandler Callcrear_clienteCompleted;
        
        /// <remarks/>
        [System.Web.Services.Protocols.SoapRpcMethodAttribute("urn:pgsyswsdl#crear_cliente", RequestNamespace="urn:ws_mysqlBitacora", ResponseNamespace="urn:ws_mysqlBitacora")]
        [return: System.Xml.Serialization.SoapElementAttribute("return")]
        public datos_cliente_salida Callcrear_cliente(datos_cliente_entrada datos_cliente_entrada) {
            object[] results = this.Invoke("Callcrear_cliente", new object[] {
                        datos_cliente_entrada});
            return ((datos_cliente_salida)(results[0]));
        }
        
        /// <remarks/>
        public void Callcrear_clienteAsync(datos_cliente_entrada datos_cliente_entrada) {
            this.Callcrear_clienteAsync(datos_cliente_entrada, null);
        }
        
        /// <remarks/>
        public void Callcrear_clienteAsync(datos_cliente_entrada datos_cliente_entrada, object userState) {
            if ((this.Callcrear_clienteOperationCompleted == null)) {
                this.Callcrear_clienteOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCallcrear_clienteOperationCompleted);
            }
            this.InvokeAsync("Callcrear_cliente", new object[] {
                        datos_cliente_entrada}, this.Callcrear_clienteOperationCompleted, userState);
        }
        
        private void OnCallcrear_clienteOperationCompleted(object arg) {
            if ((this.Callcrear_clienteCompleted != null)) {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.Callcrear_clienteCompleted(this, new Callcrear_clienteCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }
        
        /// <remarks/>
        public new void CancelAsync(object userState) {
            base.CancelAsync(userState);
        }
        
        private bool IsLocalFileSystemWebService(string url) {
            if (((url == null) 
                        || (url == string.Empty))) {
                return false;
            }
            System.Uri wsUri = new System.Uri(url);
            if (((wsUri.Port >= 1024) 
                        && (string.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) == 0))) {
                return true;
            }
            return false;
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2117.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="urn:ws_mysqlBitacora")]
    public partial class datos_cliente_entrada {
        
        private string empresaField;
        
        private string tituloField;
        
        private string descripcionField;
        
        /// <comentarios/>
        public string empresa {
            get {
                return this.empresaField;
            }
            set {
                this.empresaField = value;
            }
        }
        
        /// <comentarios/>
        public string titulo {
            get {
                return this.tituloField;
            }
            set {
                this.tituloField = value;
            }
        }
        
        /// <comentarios/>
        public string descripcion {
            get {
                return this.descripcionField;
            }
            set {
                this.descripcionField = value;
            }
        }
    }
    
    /// <comentarios/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.7.2117.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.SoapTypeAttribute(Namespace="urn:ws_mysqlBitacora")]
    public partial class datos_cliente_salida {
        
        private string codigoField;
        
        private string respuestaField;
        
        /// <comentarios/>
        public string codigo {
            get {
                return this.codigoField;
            }
            set {
                this.codigoField = value;
            }
        }
        
        /// <comentarios/>
        public string respuesta {
            get {
                return this.respuestaField;
            }
            set {
                this.respuestaField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2053.0")]
    public delegate void Callcrear_clienteCompletedEventHandler(object sender, Callcrear_clienteCompletedEventArgs e);
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.7.2053.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Callcrear_clienteCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        internal Callcrear_clienteCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        /// <remarks/>
        public datos_cliente_salida Result {
            get {
                this.RaiseExceptionIfNecessary();
                return ((datos_cliente_salida)(this.results[0]));
            }
        }
    }
}

#pragma warning restore 1591