using Microsoft.EntityFrameworkCore;
using ProEvents.Domain.Models;
using ProEvents.Persistense.Data;
using ProEvents.Persistense.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProEvents.Persistense.Implementation
{
    public class GeneralPersistence : IGeneralPersist
    {
        private readonly ProEventsContext _context;

        public GeneralPersistence(ProEventsContext context)
        {
            _context = context;
        }

        //Generic
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Uppdate<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T entityArray) where T : class
        {
            _context.Remove(entityArray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            //If the return is greater than 0 it will return true
            return (await _context.SaveChangesAsync())>0;
        }
        
    }
}
