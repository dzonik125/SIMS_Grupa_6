// File:    Repository.cs
// Author:  Ivana
// Created: Thursday, April 7, 2022 10:33:45
// Purpose: Definition of Interface Repository

using System;
using System.Collections.Generic;

namespace Repository
{
   public interface IRepository<T,ID>
   {
      List<T> FindAll();
      
      T FindById(ID key);
      
      void DeleteAll();
      
      void DeleteById(ID id);
      
      void Create(T entity);
      
      void Update(T entity);
   
   }
}