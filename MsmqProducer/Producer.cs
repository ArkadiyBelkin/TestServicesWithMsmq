using Contracts;
using System.Messaging;
using System;
using NLog;

namespace MsmqProducer
{
    public class Producer
    {
        private Logger _log = LogManager.GetCurrentClassLogger();
        private const string _queueName = @".\Private$\Products";

        public void AddProduct(Product product)
        {
            MessageQueue queue;
            try
            {
                if (!MessageQueue.Exists(_queueName))
                {
                    queue = MessageQueue.Create(_queueName);
                }
                else
                {
                    queue = new MessageQueue(_queueName);
                }
            }
            catch (Exception ex)
            {
                _log.FatalException("Can't open or create queue", ex);
               throw ex;
            }
            var xmlFormatter = new XmlMessageFormatter();
            var types = new Type[] { typeof(Product) };
            xmlFormatter.TargetTypes = types;
            queue.Formatter = xmlFormatter;
            try
            {
                queue.Send(product);
            }
            catch (Exception ex)
            {
                _log.FatalException("Fatal on sending message", ex);
                throw ex;
            }
        }
    }
}
