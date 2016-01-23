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
