﻿using OrderProcessing.Domain;
using OrderProcessing.Utilities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderProcessing.Database.Mongo.Implementation
{
    public class OrderMongoDAO : MongoDAO, IMongoDAO<Order>
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Order model)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            throw new NotImplementedException();
        }

        public Order GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public Order GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Save(Order model)
        {
            throw new NotImplementedException();
        }

        public void Update(Order Model)
        {
            throw new NotImplementedException();
        }
    }
}