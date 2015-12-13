﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication.GetterService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Positions", Namespace="http://schemas.datacontract.org/2004/07/ServiceLibrary")]
    [System.SerializableAttribute()]
    public partial class Positions : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int CourseField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime DateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int HdopField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int NumSatellitesField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string QualityField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RdXField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int RdYField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int SpeedField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TimeField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private long UnitIdField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Course {
            get {
                return this.CourseField;
            }
            set {
                if ((this.CourseField.Equals(value) != true)) {
                    this.CourseField = value;
                    this.RaisePropertyChanged("Course");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Date {
            get {
                return this.DateField;
            }
            set {
                if ((this.DateField.Equals(value) != true)) {
                    this.DateField = value;
                    this.RaisePropertyChanged("Date");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Hdop {
            get {
                return this.HdopField;
            }
            set {
                if ((this.HdopField.Equals(value) != true)) {
                    this.HdopField = value;
                    this.RaisePropertyChanged("Hdop");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int NumSatellites {
            get {
                return this.NumSatellitesField;
            }
            set {
                if ((this.NumSatellitesField.Equals(value) != true)) {
                    this.NumSatellitesField = value;
                    this.RaisePropertyChanged("NumSatellites");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Quality {
            get {
                return this.QualityField;
            }
            set {
                if ((object.ReferenceEquals(this.QualityField, value) != true)) {
                    this.QualityField = value;
                    this.RaisePropertyChanged("Quality");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RdX {
            get {
                return this.RdXField;
            }
            set {
                if ((this.RdXField.Equals(value) != true)) {
                    this.RdXField = value;
                    this.RaisePropertyChanged("RdX");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int RdY {
            get {
                return this.RdYField;
            }
            set {
                if ((this.RdYField.Equals(value) != true)) {
                    this.RdYField = value;
                    this.RaisePropertyChanged("RdY");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Speed {
            get {
                return this.SpeedField;
            }
            set {
                if ((this.SpeedField.Equals(value) != true)) {
                    this.SpeedField = value;
                    this.RaisePropertyChanged("Speed");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Time {
            get {
                return this.TimeField;
            }
            set {
                if ((object.ReferenceEquals(this.TimeField, value) != true)) {
                    this.TimeField = value;
                    this.RaisePropertyChanged("Time");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long UnitId {
            get {
                return this.UnitIdField;
            }
            set {
                if ((this.UnitIdField.Equals(value) != true)) {
                    this.UnitIdField = value;
                    this.RaisePropertyChanged("UnitId");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GetterService.IGetter")]
    public interface IGetter {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetPositionsList", ReplyAction="http://tempuri.org/IGetter/GetPositionsListResponse")]
        WebApplication.GetterService.Positions[] GetPositionsList(int max, string order);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetPositionsList", ReplyAction="http://tempuri.org/IGetter/GetPositionsListResponse")]
        System.Threading.Tasks.Task<WebApplication.GetterService.Positions[]> GetPositionsListAsync(int max, string order);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IGetterChannel : WebApplication.GetterService.IGetter, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class GetterClient : System.ServiceModel.ClientBase<WebApplication.GetterService.IGetter>, WebApplication.GetterService.IGetter {
        
        public GetterClient() {
        }
        
        public GetterClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public GetterClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GetterClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public GetterClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public WebApplication.GetterService.Positions[] GetPositionsList(int max, string order) {
            return base.Channel.GetPositionsList(max, order);
        }
        
        public System.Threading.Tasks.Task<WebApplication.GetterService.Positions[]> GetPositionsListAsync(int max, string order) {
            return base.Channel.GetPositionsListAsync(max, order);
        }
    }
}
