﻿using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace OrderProcessingCore.Utilities.Messaging.implementation
{
    public class TopicRabbitMQProducer : RabbitMQ, IRabbitMQProducer
    {
        IModel model;

        public TopicRabbitMQProducer()
        {
            model = connection.CreateModel();
        }

        public TopicRabbitMQProducer(string Exchange)
        {
            model = connection.CreateModel();
            this.Exchange = Exchange;
            model.ExchangeDeclare(this.Exchange, ExchangeType.Topic);
        }

        public TopicRabbitMQProducer(string Exchange, string Queue)
        {
            model = connection.CreateModel();
            this.Exchange = Exchange;
            this.Queue = Queue;
            model.ExchangeDeclare(this.Exchange,ExchangeType.Topic,true);
            model.QueueDeclare(this.Queue,true,false,false,null);
        }

        public void Send(string msg, string Routingkey)
        {
            model.QueueBind(Queue, Exchange, Routingkey, null);

            var body = Encoding.UTF8.GetBytes(msg);

            model.BasicPublish(Exchange, Routingkey, null, body);
            
        }

        public void Send(object obj, string Queue, string RoutingKey)
        {
            JObject jsonObject = JObject.FromObject(obj);
            byte[] message = System.Text.Encoding.UTF8.GetBytes(jsonObject.ToString());
            model.QueueBind(Queue, this.Exchange, RoutingKey, null);
            
            model.BasicPublish(this.Exchange, Queue, null,message);
        }

        public void Send(object obj, string Routingkey)
        {
            model.QueueBind(Queue, Exchange, Routingkey, null);

            JObject jsonObject =JObject.FromObject(obj);

            byte[] message = System.Text.Encoding.UTF8.GetBytes(jsonObject.ToString());

            model.BasicPublish(Exchange, Routingkey, null, message);
           
        }
    }
}