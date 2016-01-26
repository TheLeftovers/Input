using System.Collections;
using System.ServiceModel;

namespace ServiceLibrary
{
    [ServiceContract]
    public interface IGetter
    {

        [OperationContract]
        ArrayList GetTestList();                                                    //Unit Test method

        [OperationContract]
        ArrayList GetQueryList(string query);

        [OperationContract]
        ArrayList GetUnitListForTopSpeed();                                         //Positions

        [OperationContract]
        ArrayList GetSpeedListForTopSpeed();                                        //Positions

        [OperationContract]
        ArrayList GetUnitListbyRepair();                                            //Events

        [OperationContract]
        ArrayList GetCountListbyRepair();                                           //Events

        [OperationContract]
        ArrayList GetHDOPListForQuality();                                          //Positions

        [OperationContract]
        ArrayList GetNumSatellitesListForQuality();                                 //Positions   

        [OperationContract]
        ArrayList GetBeginTimeListForGPSTemp();     //Monitoring

        [OperationContract]
        ArrayList GetMaxListForGPSTemp();           //Monitoring

        [OperationContract]
        ArrayList GetBeginTimeListForCPUTemp();     //Monitoring

        [OperationContract]
        ArrayList GetMaxListForCPUTemp();           //Monitoring

        [OperationContract]
        ArrayList GetLatLon(long unit, string date, string from, string till);                 //Positions
    }
}
