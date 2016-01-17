using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace UnitTestProject2
{
    [ServiceContract]
    public interface IUnitTest1
    {
        [OperationContract]
        ArrayList TestMethod1();
    }
}
