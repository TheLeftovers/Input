﻿using System;
using System.Collections;
using System.Collections.Generic;
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
        ArrayList GetMaxTempList();

        [OperationContract]
        ArrayList GetMinTempList();

        [OperationContract]
        ArrayList GetMaxTimeList();

        [OperationContract]
        ArrayList GetMinTimeList();

        [OperationContract]
        ArrayList GetHDOPList();

        [OperationContract]
        ArrayList GetNumSatellitesList();
    }
}
