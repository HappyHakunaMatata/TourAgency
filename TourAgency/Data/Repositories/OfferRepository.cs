using System;
using System.Xml.Linq;
using TourAgency.Data;
using TourAgency.Models;
using TourAgency.Data.Interfaces;

namespace TourAgency.Data.Repositories
{
    public class OfferRepository: IOffer
    {
        private readonly AppDbContext _context;

        public OfferRepository(AppDbContext context)
        {
            _context = context;
        }
        
        /*public Offer getModel(int id)
        {
            try
            {
                var db_model = _context.Offers.Find(id);
                if (db_model == null)
                {
                    return new Offer();
                }
                else
                {
                    return db_model;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("HistoryAssetRepository: " + e);
                return new Offer();
            }
        }

        public List<Offer> GetListModel(int quantity)
        {
            try
            {
                var db_model = _context.Offers.Where(model => model.id < quantity).ToList();
                if (db_model == null)
                {
                    return new List<Offer>();
                }
                else
                {
                    return db_model;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("HistoryAssetRepository: " + e);
                return new List<Offer>();
            }
        }

        public void SaveData(Offer model)
        {
            try
            {
                _context.Offers.Add(model);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("HistoryAssetRepository: " + e);
            }
        }*/
    }
}

