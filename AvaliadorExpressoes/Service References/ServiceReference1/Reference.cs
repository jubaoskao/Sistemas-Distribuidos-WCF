﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AvaliadorExpressoes.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SumValue", ReplyAction="http://tempuri.org/IService1/SumValueResponse")]
        string SumValue(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/SubtractValue", ReplyAction="http://tempuri.org/IService1/SubtractValueResponse")]
        string SubtractValue(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/MultiValue", ReplyAction="http://tempuri.org/IService1/MultiValueResponse")]
        string MultiValue(double n1, double n2);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/DivValue", ReplyAction="http://tempuri.org/IService1/DivValueResponse")]
        string DivValue(double n1, double n2);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : AvaliadorExpressoes.ServiceReference1.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<AvaliadorExpressoes.ServiceReference1.IService1>, AvaliadorExpressoes.ServiceReference1.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string SumValue(double n1, double n2) {
            return base.Channel.SumValue(n1, n2);
        }
        
        public string SubtractValue(double n1, double n2) {
            return base.Channel.SubtractValue(n1, n2);
        }
        
        public string MultiValue(double n1, double n2) {
            return base.Channel.MultiValue(n1, n2);
        }
        
        public string DivValue(double n1, double n2) {
            return base.Channel.DivValue(n1, n2);
        }
    }
}
