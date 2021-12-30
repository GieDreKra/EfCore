using Microsoft.EntityFrameworkCore;
using RegistrationItemsApp.Data;
using RegistrationItemsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistrationItemsApp.Repositories
{
    public class RegistrationItemRepository
    {
        private DataContext _context;
        public RegistrationItemRepository(DataContext context)
        {
            _context = context;
        }

        public List<RegistrationItem> GetAll()
        {
            return _context.RegistrationItems.Include(i => i.Values).ToList();
        }

        public void Update(RegistrationItem registrationItem)
        {
            _context.RegistrationItems.Update(registrationItem);
            _context.SaveChanges();
        }

        public RegistrationItem Get(int id)
        {
            return _context.RegistrationItems.Find(id);
        }

    }
}
