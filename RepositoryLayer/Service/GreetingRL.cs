using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Service
{
    public class GreetingRL : IGreetingRL
    {
        private readonly GreetingDbContext _context;
        public GreetingRL(GreetingDbContext context)
        {

            _context = context;

        }
        //UC4
        public GreetingEntity AddGreetings(GreetingEntity greeting)
        {
            _context.Greetings.Add(greeting);
            _context.SaveChanges();
            return greeting;
        }


        //UC5

        public GreetingEntity? GetGreetingById(int id) 
        {
            return _context.Greetings.FirstOrDefault(x => x.Id == id); 
        }

        //UC6
        public List<GreetingEntity> GetAllGreetings()
        {
            return _context.Greetings.ToList(); //Fetch all greetings from DB
        }

        //UC7
        public GreetingEntity UpdateGreeting(int id, string newMssge)
        {
            var existingGreeting = _context.Greetings.FirstOrDefault(x => x.Id == id);

            if (existingGreeting == null)
            {
                return existingGreeting; //  Greeting not found
            }

            existingGreeting.Message = newMssge; // Update message
            _context.Greetings.Update(existingGreeting);
            _context.SaveChanges(); // Save changes to DB

            return existingGreeting; // Successfully updated
        }

        //UC8
        public bool DeleteGreeting(int id)
        {
            var existingGreeting = _context.Greetings.FirstOrDefault(x => x.Id == id);

            if (existingGreeting == null)
            {
                return false; //  id not found
            }

            _context.Greetings.Remove(existingGreeting);
            _context.SaveChanges(); // Save changes to DB

            return true;
        }
    }
}