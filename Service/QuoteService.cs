﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using DAL;
using System.Net.Http;
//using System.Web.Http.Filters;

namespace Service
{
    public class QuoteService
    {
        private UnitOfWork uow = new UnitOfWork();
         
        public IEnumerable<tblQuote> GetallQuotes()
        {
            return uow.QuoteRepo.GetAll();
        }

        public tblQuote GetbyID(int ID)
        {
            
            return uow.QuoteRepo.GetByID(ID);
        }
        
        public void insert(tblQuote item)
        {
            if (item == null)
            {
                throw new InvalidOperationException("invalid entity");
            }
            uow.QuoteRepo.Insert(item);
        }

        //check if the entity is valid or not 
        public void update(int id, tblQuote item)
        { 
            var entry = GetbyID(id);
            if(entry == null)
            {
                throw new InvalidOperationException("Quote ID doesnt exist");
            }
            //assemble the id correctly and send down
            item.QuoteID = id;

            uow.QuoteRepo.Update(id, item);
        }

        public void delete(tblQuote item)
        {
            if (item == null)
            {
                throw new InvalidOperationException("invalid entity");
            }
            uow.QuoteRepo.Delete(item);
        } 

    }
}
