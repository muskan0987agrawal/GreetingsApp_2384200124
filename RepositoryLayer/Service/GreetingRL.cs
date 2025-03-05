﻿using Microsoft.EntityFrameworkCore;
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
        public Greeting AddGreetings(Greeting greeting)
        {
            _context.Greetings.Add(greeting);
            _context.SaveChanges();
            return greeting;
        }


        //UC5

        public Greeting? GetGreetingById(int id) 
        {
            return _context.Greetings.FirstOrDefault(x => x.Id == id); 
        }

        //UC6
        public List<Greeting> GetAllGreetings()
        {
            return _context.Greetings.ToList(); //Fetch all greetings from DB
        }

    }
}