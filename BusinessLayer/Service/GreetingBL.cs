﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using ModelLayer.Model;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Service;

namespace BusinessLayer.Service
{
    public class GreetingBL: IGreetingBL
    {
        private readonly IGreetingRL _greetingRL;
     

        public GreetingBL(IGreetingRL greetingRL)
        {
            _greetingRL = greetingRL;
        }
        //UC2
        public string getGreetMessage()
        {
            return "Hello World";
        }

        //UC3
        public string GetGreetingMessage(UsernameRequestModel request)
        {
            //Both first Name and LAstName provided
            if (!string.IsNullOrWhiteSpace(request.FirstName) && !string.IsNullOrWhiteSpace(request.LastName))
            {
                return $"Hello, {request.FirstName} {request.LastName}!";
            }
            //only first /name provided
            else if (!string.IsNullOrWhiteSpace(request.FirstName))
            {
                return $"Hello, {request.FirstName}!";
            }
            //only last name provided
            else if (!string.IsNullOrWhiteSpace(request.LastName))
            {
                return $"Hello, {request.LastName}!";
            }

            //No name provided
            return "Hello World!";

        }

        //UC4
        public GreetingEntity AddGreeting(GreetingEntity greeting)
        {
            return _greetingRL.AddGreetings(greeting);
        }

        //UC5
        public GreetingEntity? GetGreetingById(int id)
        {
            return _greetingRL.GetGreetingById(id);
        }

        //uc6
        public List<GreetingEntity> GetAllGreetings()
        {
            return _greetingRL.GetAllGreetings(); // Returns list from RL
        }

        //UC7
        public GreetingEntity UpdateGreeting(int id, string NewMssge)
        {
            return _greetingRL.UpdateGreeting(id,NewMssge); // Calls RL method
        }

        //UC8
        public bool DeleteGreeting(int id)
        {
            return _greetingRL.DeleteGreeting(id);
        }

    }
}
