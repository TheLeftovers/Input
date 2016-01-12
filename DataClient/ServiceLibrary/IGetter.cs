using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLibrary
{
    [ServiceContract]
    public interface IGetter
    {
        [OperationContract]
        ArrayList GetUnitList();

        [OperationContract]
        ArrayList GetSpeedList();

        [OperationContract]
        ArrayList GetUnitListbyRepair();

        [OperationContract]
        ArrayList GetCountListbyRepair();

        [OperationContract]
        ArrayList GetHDOPList();

        [OperationContract]
        ArrayList GetNumSatellitesList();
    }
}
