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
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="GetterService.IGetter")]
    public interface IGetter {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetTestList", ReplyAction="http://tempuri.org/IGetter/GetTestListResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        object[] GetTestList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetTestList", ReplyAction="http://tempuri.org/IGetter/GetTestListResponse")]
        System.Threading.Tasks.Task<object[]> GetTestListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetQueryList", ReplyAction="http://tempuri.org/IGetter/GetQueryListResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        object[] GetQueryList(string query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetQueryList", ReplyAction="http://tempuri.org/IGetter/GetQueryListResponse")]
        System.Threading.Tasks.Task<object[]> GetQueryListAsync(string query);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetUnitListForTopSpeed", ReplyAction="http://tempuri.org/IGetter/GetUnitListForTopSpeedResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        object[] GetUnitListForTopSpeed();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetUnitListForTopSpeed", ReplyAction="http://tempuri.org/IGetter/GetUnitListForTopSpeedResponse")]
        System.Threading.Tasks.Task<object[]> GetUnitListForTopSpeedAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetSpeedListForTopSpeed", ReplyAction="http://tempuri.org/IGetter/GetSpeedListForTopSpeedResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        object[] GetSpeedListForTopSpeed();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetSpeedListForTopSpeed", ReplyAction="http://tempuri.org/IGetter/GetSpeedListForTopSpeedResponse")]
        System.Threading.Tasks.Task<object[]> GetSpeedListForTopSpeedAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetUnitListbyRepair", ReplyAction="http://tempuri.org/IGetter/GetUnitListbyRepairResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        object[] GetUnitListbyRepair();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetUnitListbyRepair", ReplyAction="http://tempuri.org/IGetter/GetUnitListbyRepairResponse")]
        System.Threading.Tasks.Task<object[]> GetUnitListbyRepairAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetCountListbyRepair", ReplyAction="http://tempuri.org/IGetter/GetCountListbyRepairResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        object[] GetCountListbyRepair();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetCountListbyRepair", ReplyAction="http://tempuri.org/IGetter/GetCountListbyRepairResponse")]
        System.Threading.Tasks.Task<object[]> GetCountListbyRepairAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetHDOPListForQuality", ReplyAction="http://tempuri.org/IGetter/GetHDOPListForQualityResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        object[] GetHDOPListForQuality();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetHDOPListForQuality", ReplyAction="http://tempuri.org/IGetter/GetHDOPListForQualityResponse")]
        System.Threading.Tasks.Task<object[]> GetHDOPListForQualityAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetNumSatellitesListForQuality", ReplyAction="http://tempuri.org/IGetter/GetNumSatellitesListForQualityResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        object[] GetNumSatellitesListForQuality();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetNumSatellitesListForQuality", ReplyAction="http://tempuri.org/IGetter/GetNumSatellitesListForQualityResponse")]
        System.Threading.Tasks.Task<object[]> GetNumSatellitesListForQualityAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetBeginTimeListForGPSTemp", ReplyAction="http://tempuri.org/IGetter/GetBeginTimeListForGPSTempResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        object[] GetBeginTimeListForGPSTemp();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetBeginTimeListForGPSTemp", ReplyAction="http://tempuri.org/IGetter/GetBeginTimeListForGPSTempResponse")]
        System.Threading.Tasks.Task<object[]> GetBeginTimeListForGPSTempAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetMaxListForGPSTemp", ReplyAction="http://tempuri.org/IGetter/GetMaxListForGPSTempResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        object[] GetMaxListForGPSTemp();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetMaxListForGPSTemp", ReplyAction="http://tempuri.org/IGetter/GetMaxListForGPSTempResponse")]
        System.Threading.Tasks.Task<object[]> GetMaxListForGPSTempAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetBeginTimeListForCPUTemp", ReplyAction="http://tempuri.org/IGetter/GetBeginTimeListForCPUTempResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        object[] GetBeginTimeListForCPUTemp();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetBeginTimeListForCPUTemp", ReplyAction="http://tempuri.org/IGetter/GetBeginTimeListForCPUTempResponse")]
        System.Threading.Tasks.Task<object[]> GetBeginTimeListForCPUTempAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetMaxListForCPUTemp", ReplyAction="http://tempuri.org/IGetter/GetMaxListForCPUTempResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        object[] GetMaxListForCPUTemp();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetMaxListForCPUTemp", ReplyAction="http://tempuri.org/IGetter/GetMaxListForCPUTempResponse")]
        System.Threading.Tasks.Task<object[]> GetMaxListForCPUTempAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetLatLon", ReplyAction="http://tempuri.org/IGetter/GetLatLonResponse")]
        [System.ServiceModel.ServiceKnownTypeAttribute(typeof(object[]))]
        object[] GetLatLon(long unit, string date, string from, string till);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGetter/GetLatLon", ReplyAction="http://tempuri.org/IGetter/GetLatLonResponse")]
        System.Threading.Tasks.Task<object[]> GetLatLonAsync(long unit, string date, string from, string till);
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
        
        public object[] GetTestList() {
            return base.Channel.GetTestList();
        }
        
        public System.Threading.Tasks.Task<object[]> GetTestListAsync() {
            return base.Channel.GetTestListAsync();
        }
        
        public object[] GetQueryList(string query) {
            return base.Channel.GetQueryList(query);
        }
        
        public System.Threading.Tasks.Task<object[]> GetQueryListAsync(string query) {
            return base.Channel.GetQueryListAsync(query);
        }
        
        public object[] GetUnitListForTopSpeed() {
            return base.Channel.GetUnitListForTopSpeed();
        }
        
        public System.Threading.Tasks.Task<object[]> GetUnitListForTopSpeedAsync() {
            return base.Channel.GetUnitListForTopSpeedAsync();
        }
        
        public object[] GetSpeedListForTopSpeed() {
            return base.Channel.GetSpeedListForTopSpeed();
        }
        
        public System.Threading.Tasks.Task<object[]> GetSpeedListForTopSpeedAsync() {
            return base.Channel.GetSpeedListForTopSpeedAsync();
        }
        
        public object[] GetUnitListbyRepair() {
            return base.Channel.GetUnitListbyRepair();
        }
        
        public System.Threading.Tasks.Task<object[]> GetUnitListbyRepairAsync() {
            return base.Channel.GetUnitListbyRepairAsync();
        }
        
        public object[] GetCountListbyRepair() {
            return base.Channel.GetCountListbyRepair();
        }
        
        public System.Threading.Tasks.Task<object[]> GetCountListbyRepairAsync() {
            return base.Channel.GetCountListbyRepairAsync();
        }
        
        public object[] GetHDOPListForQuality() {
            return base.Channel.GetHDOPListForQuality();
        }
        
        public System.Threading.Tasks.Task<object[]> GetHDOPListForQualityAsync() {
            return base.Channel.GetHDOPListForQualityAsync();
        }
        
        public object[] GetNumSatellitesListForQuality() {
            return base.Channel.GetNumSatellitesListForQuality();
        }
        
        public System.Threading.Tasks.Task<object[]> GetNumSatellitesListForQualityAsync() {
            return base.Channel.GetNumSatellitesListForQualityAsync();
        }
        
        public object[] GetBeginTimeListForGPSTemp() {
            return base.Channel.GetBeginTimeListForGPSTemp();
        }
        
        public System.Threading.Tasks.Task<object[]> GetBeginTimeListForGPSTempAsync() {
            return base.Channel.GetBeginTimeListForGPSTempAsync();
        }
        
        public object[] GetMaxListForGPSTemp() {
            return base.Channel.GetMaxListForGPSTemp();
        }
        
        public System.Threading.Tasks.Task<object[]> GetMaxListForGPSTempAsync() {
            return base.Channel.GetMaxListForGPSTempAsync();
        }
        
        public object[] GetBeginTimeListForCPUTemp() {
            return base.Channel.GetBeginTimeListForCPUTemp();
        }
        
        public System.Threading.Tasks.Task<object[]> GetBeginTimeListForCPUTempAsync() {
            return base.Channel.GetBeginTimeListForCPUTempAsync();
        }
        
        public object[] GetMaxListForCPUTemp() {
            return base.Channel.GetMaxListForCPUTemp();
        }
        
        public System.Threading.Tasks.Task<object[]> GetMaxListForCPUTempAsync() {
            return base.Channel.GetMaxListForCPUTempAsync();
        }
        
        public object[] GetLatLon(long unit, string date, string from, string till) {
            return base.Channel.GetLatLon(unit, date, from, till);
        }
        
        public System.Threading.Tasks.Task<object[]> GetLatLonAsync(long unit, string date, string from, string till) {
            return base.Channel.GetLatLonAsync(unit, date, from, till);
        }
    }
}
