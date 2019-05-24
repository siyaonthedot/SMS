using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;
using SMS.Service.Interface;

namespace SMS.Services.Broker
{

        public class StudentServiceBroke : IStudentServiceBroke, IDisposable
        {
            public ISMSService Proxy { get; set; }

            private ChannelFactory<ISMSService> channelFactory;

            public void Dispose()
            {
                try
                {
                    if (channelFactory.State != CommunicationState.Faulted)
                        channelFactory.Close();
                }
                catch (Exception)
                {
                    channelFactory.Abort();
                }

            }

            public StudentServiceBroke(string host, int port)
            {
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
                },
                    TransferMode = TransferMode.Buffered
                };

                binding.SendTimeout = binding.ReceiveTimeout = new TimeSpan(0, 15, 0);
                EndpointAddress endpointAddress = new EndpointAddress(string.Format("net.tcp://{0}:{1}", host, port));

                channelFactory = new ChannelFactory<ISMSService>(binding, endpointAddress);

                foreach (var operation in channelFactory.Endpoint.Contract.Operations)
                {
                    var behavior = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
                    if (behavior != null)
                    {
                        behavior.MaxItemsInObjectGraph = 2147483647;
                    }
                }

                Proxy = channelFactory.CreateChannel();
            }
        }
    }

