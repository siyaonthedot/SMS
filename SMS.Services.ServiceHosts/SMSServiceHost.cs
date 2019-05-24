using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using SMS.Service.Interface;
using System.ServiceModel.Description;
using System.ServiceModel;

namespace SMS.Services.ServiceHosts
{
    public class SMSServiceHost
    {
        private string _host;
        private int _port;

        public SMSServiceHost(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public void Initialize()
        {
            try
            {
                var host = new ServiceHost(typeof(SMSService));

                var binding = new NetTcpBinding
                {
                    MaxReceivedMessageSize = 2147483647,
                    MaxBufferPoolSize = 2147483647,
                    MaxBufferSize = 2147483647,
                    MaxConnections = 30000,
                    ReaderQuotas =
                    {
                        MaxBytesPerRead = 2147483647,
                        MaxDepth = 2147483647,
                        MaxArrayLength = 2147483647,
                        MaxNameTableCharCount = 2147483647,
                        MaxStringContentLength = 2147483647
                    }
                };

                binding.SendTimeout = binding.ReceiveTimeout = new TimeSpan(0, 15, 0);
                host.AddServiceEndpoint(typeof(ISMSService), binding, string.Format("net.tcp://{0}:{1}", _host, _port));

                ServiceBehaviorAttribute serviceBehaviorAttribute = host.Description.Behaviors.Find<ServiceBehaviorAttribute>();
                if (serviceBehaviorAttribute != null)
                    serviceBehaviorAttribute.MaxItemsInObjectGraph = int.MaxValue;

                if (host.Description != null)
                {
                    var throttle = host.Description.Behaviors.Find<ServiceThrottlingBehavior>();
                    if (throttle == null)
                    {
                        throttle = new ServiceThrottlingBehavior
                        {
                            MaxConcurrentCalls = 80,
                            MaxConcurrentSessions = 1200,
                            MaxConcurrentInstances = 1200
                        };
                        host.Description.Behaviors.Add(throttle);
                    }
                }
                host.Open();
            }
            catch (Exception exception)
            {
                //Console.WriteLine(ex.Message);
                EventLog.WriteEntry("SMS Service Host", exception.Message, EventLogEntryType.Error);
            }
        }
    }
}
