using Microsoft.EntityFrameworkCore;
using System;
using Zalba_Mikroservis.Data;
using Zalba_Mikroservis.Interfaces;
using Zalba_Mikroservis.Models;
using Zalba_Mikroservis.Models.DTO;

namespace Zalba_Mikroservis.Repository
{
    public class ZalbaRepository : IZalbaRepository
    {
        private readonly DataContext _context;
        public ZalbaRepository(DataContext context) 
        { 
            _context= context;  
        }

        //POST
        public bool CreateZalba(Zalba zalba)
        {
            _context.Add(zalba);
            //greska
          //  _context.SaveChanges();
            return Save();
            throw new NotImplementedException();


        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
            throw new NotImplementedException();
        }

        //GETBYID
        public Zalba GetZalbaById(int id)
        {
            return _context.Zalbas.Where(z => z.ZalbaID == id)
                .Include(x => x.Kupac)
                .FirstOrDefault();
            throw new NotImplementedException();

        }

        //GETALL
        public ICollection<Zalba> GetZalbas()
        {
            return _context.Zalbas.OrderBy(z => z.ZalbaID)
                //.Include(x => x.Kupac)
                .ToList();
            throw new NotImplementedException();

        }

        //EXIST
        public bool ZalbaExist(int ZalId)
        {
            return _context.Zalbas.Any(z => z.ZalbaID == ZalId);
            throw new NotImplementedException();


        }
        //PUT
        public bool UpdateZalba(Zalba zalba)
        {
            _context.Update(zalba);
            return Save();
            throw new NotImplementedException();

        }
        //DELETE
        public bool DeleteZalba(Zalba zalba)
        {
            _context.Remove(zalba);
            return Save();
        }

        
    }
}
