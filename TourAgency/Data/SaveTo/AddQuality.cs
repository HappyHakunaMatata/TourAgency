using System;
namespace TourAgency.Data.SaveTo
{
	public class AddQuality
	{
        private AppDbContext _context;
        public AddQuality(AppDbContext context)
        {
            _context = context;
        }
        
        public void AddEntity()
        {
            foreach (var i in Enumerable.Range(0,6))
            {
                _context.Qualities.Add(new Models.Quality() { value = i, super = false});
                _context.Qualities.Add(new Models.Quality() { value = i, super = true });
            }
            _context.SaveChanges();
        }
    }
}

