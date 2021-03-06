﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessingCore.Service
{
    public interface IService <T>
    {
        T GetSingle(int id);

        T GetSingle(string Name);

        T GetSingle(T entity);
        ///<summary>
        ///Gets all data as per Entity from the DB 
        ///</summary>
        List<T> GetAll();

        void Save(T t);

        void Delete(int id);

        void Delete(string param);

        /// <summary>
        /// <paramref name="t"/>
        /// </summary>
        /// <returns></returns>
        T Update(T t);

        Boolean Exists(T t);

    }
}
