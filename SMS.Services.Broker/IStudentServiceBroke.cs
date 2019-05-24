using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Service.Interface;

namespace SMS.Services.Broker
{
    public interface IStudentServiceBroke
    {
        ISMSService Proxy { get; set; }
    }
}
