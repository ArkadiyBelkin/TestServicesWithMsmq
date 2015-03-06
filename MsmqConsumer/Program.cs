using System;
using System.Messaging;
using Contracts;
using System.Threading;
using NLog;
using System.Xml;

namespace MsmqConsumer
{
    class Program
    {
        private const string _queueName = @".\Private$\Products";

        static void Main(string[] args)
        {
            Logger _log = LogManager.GetCurrentClassLogger();
            while (true)
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
                Message[] messages;
                try
                {
                    messages = queue.GetAllMessages();
                }
                catch (Exception ex)
                {
                    _log.FatalException("Failed on reading messages", ex);
                    throw ex;
                }
                foreach (var message in messages)
                {
                    try
                    {
                        var product = (Product)message.Body;
                        var alert = string.Format("added a new product to the queue with name {0} and price {1}",
                            product.Name, product.Price.ToString("F2"));
                        _log.Info(alert);
                        Console.WriteLine(alert);
                    }
                    catch (XmlException ex)
                    {
                        _log.FatalException("Incorrect message in queue", ex);
                    }
                }
                queue.Purge();
                Thread.Sleep(1000);
            }
        }
    }
}
