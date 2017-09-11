using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_Calc
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string SumValue(double n1, double n2);

        [OperationContract]
        string SubtractValue(double n1, double n2);

        [OperationContract]
        string MultiValue(double n1, double n2);

        [OperationContract]
        string DivValue(double n1, double n2);

        [OperationContract]
        string PowerValue(double n1, double n2);
    }
}
