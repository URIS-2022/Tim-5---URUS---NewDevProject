using Kupac__Mikroservis.Data;
using Kupac__Mikroservis.Interfaces;
using Kupac__Mikroservis.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Kupac__Mikroservis.Repository
{
    public class OvlascenoLiceRepository : IOvlascenoLiceRepository
    {

        private readonly DataContext _context;
        public OvlascenoLiceRepository(DataContext context)
        {
            _context = context;
        }

        //POST
        public bool CreateOvlascenoLice(OvlascenoLice ovlascenoLice)
        {
            _context.Add(ovlascenoLice);
            _context.SaveChanges();
            return Save();
            throw new NotImplementedException();
        }

        //DELETE
        public bool DeleteOvlascenoLice(OvlascenoLice ovlascenoLice)
        {
            _context.Remove(ovlascenoLice);
            return Save();
        }

        //GETBYID
        public OvlascenoLice GetOvlascenoLiceById(int id)
        {
            return _context.OvlasceniLices.Where(o => o.OvlascenoLiceID == id)
                .Include(x => x.Adresa)
                .FirstOrDefault();
            throw new NotImplementedException();
        }

        //GETALL
        public ICollection<OvlascenoLice> GetOvlascenoLices()
        {
            return _context.OvlasceniLices.OrderBy(o => o.OvlascenoLiceID)
                .Include(x => x.Adresa)
                .ToList();
            throw new NotImplementedException();
        }

        //EXIST
        public bool OvlascenoLiceExist(int OvlLiceId)
        {
            return _context.OvlasceniLices.Any(o => o.OvlascenoLiceID == OvlLiceId);
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
            throw new NotImplementedException();
        }

        //PUT
        public bool UpdateOvlascenoLice(OvlascenoLice ovlascenoLice)
        {
            _context.Update(ovlascenoLice);
            return Save();
            throw new NotImplementedException();
        }
    }
}

