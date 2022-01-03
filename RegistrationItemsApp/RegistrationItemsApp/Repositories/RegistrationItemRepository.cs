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

        public List<RegistrationItem> GetAll(int regid)
        {
            return _context.RegistrationItems.Include(i => i.Form).Include(i => i.Values).Where(i => i.Form.Id == regid).ToList();
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
