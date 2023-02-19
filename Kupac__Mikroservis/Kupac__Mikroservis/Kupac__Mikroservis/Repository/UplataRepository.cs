using Kupac__Mikroservis.Data;
using Kupac__Mikroservis.Interfaces;
using Kupac__Mikroservis.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Kupac_Mikroservis.Repository
{
    public class UplataRepository : IUplataRepository
    {

        private readonly DataContext _context;
        public UplataRepository(DataContext context)
        {
            _context = context;
        }

        //POST
        public bool CreateUplata(Uplata uplata)
        {
            _context.Add(uplata);
            _context.SaveChanges();
            return Save();
            throw new NotImplementedException();
        }

        //DELETE
        public bool DeleteUplata(Uplata uplata)
        {
            _context.Remove(uplata);
            return Save();
        }


        //GETBYID
        public Uplata GetUplataById(int id)
        {
            return _context.Uplatas.Where(u => u.UplataID == id)
                .Include(x => x.Kupac)
                .FirstOrDefault();
            throw new NotImplementedException();
        }


        //GETALL
        public ICollection<Uplata> GetUplatas()
        {
            return _context.Uplatas.OrderBy(u => u.UplataID)
                .Include(x => x.Kupac)
                .ToList();
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
            throw new NotImplementedException();
        }

        //PUT
        public bool UpdateUplata(Uplata uplata)
        {
            _context.Update(uplata);
            return Save();
            throw new NotImplementedException();
        }


        //EXIST
        public bool UplataExist(int UpltId)
        {
            return _context.Uplatas.Any(u => u.UplataID == UpltId);
            throw new NotImplementedException();
        }
    }
}
