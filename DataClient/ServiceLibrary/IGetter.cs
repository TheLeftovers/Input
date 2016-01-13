using System.Collections;
using System.Collections.Generic;
using System.ServiceModel;

namespace ServiceLibrary
{
    [ServiceContract]
    public interface IGetter
    {
        [OperationContract]
        ArrayList GetUnitList();                //Positions

        [OperationContract]
        ArrayList GetSpeedList();               //Positions

        [OperationContract]
        ArrayList GetUnitListbyRepair();        //Events

        [OperationContract]
        ArrayList GetCountListbyRepair();       //Events

        [OperationContract]
        ArrayList GetHDOPList();                //Positions

        [OperationContract]
        ArrayList GetNumSatellitesList();       //Positions   

        [OperationContract]
        ArrayList GetBeginTimeList();           //Monitoring

        [OperationContract]
        ArrayList GetMaxList();                 //Monitoring

        [OperationContract]
        ArrayList GetLatLon();                 //Positions
    }
}
