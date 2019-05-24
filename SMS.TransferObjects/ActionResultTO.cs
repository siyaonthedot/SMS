using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SMS.TransferObjects
{
    public class ActionResultTO
    {
        [DataMember]
        public bool Success { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public int ModelId { get; set; }

        public ActionResultTO() { }

        public ActionResultTO(bool success, string message)
        {
            Success = success;
            Message = message;
        }
    }
}

