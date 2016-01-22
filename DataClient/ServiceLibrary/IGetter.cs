using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;

namespace ServiceLibrary
{
    [ServiceContract]
    public interface IGetter
    {

        [OperationContract]
        ArrayList GetTestList();            //Test method


        [OperationContract]
        ArrayList GetQueryList(string query);

        [OperationContract]
        ArrayList GetUnitListForTopSpeed();                //Positions

        [OperationContract]
        ArrayList GetSpeedListForTopSpeed();               //Positions

        [OperationContract]
        ArrayList GetUnitListbyRepair();        //Events

        [OperationContract]
        ArrayList GetCountListbyRepair();       //Events

        [OperationContract]
        ArrayList GetHDOPList();                //Positions

        [OperationContract]
        ArrayList GetNumSatellitesList();       //Positions   

        [OperationContract]
        ArrayList GetBeginTimeListForGPSTemp(string begintime, string endtime);     //Monitoring

        [OperationContract]
        ArrayList GetMaxListForGPSTemp(string begintime, string endtime);           //Monitoring

        [OperationContract]
        ArrayList GetBeginTimeListForCPUTemp(string begintime, string endtime);     //Monitoring

        [OperationContract]
        ArrayList GetMaxListForCPUTemp(string begintime, string endtime);           //Monitoring

        [OperationContract]
        ArrayList GetLatLon(long unit, string date, string from, string till);      //Positions
    }
}
