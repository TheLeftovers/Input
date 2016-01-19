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
        ArrayList GetBeginTimeListForGPSTemp();     //Monitoring

        [OperationContract]
        ArrayList GetMaxListForGPSTemp();           //Monitoring

        [OperationContract]
        ArrayList GetBeginTimeListForCPUTemp();     //Monitoring

        [OperationContract]
        ArrayList GetMaxListForCPUTemp();           //Monitoring

        [OperationContract]
        ArrayList GetLatLon();                 //Positions
    }
}
