﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLayer.Model;
using RepositoryLayer.Entity;

namespace BusinessLayer.Interface
{
    public interface IGreetingBL
    {
        string getGreetMessage();
        string GetGreetingMessage(UsernameRequestModel request);
        GreetingEntity AddGreeting(GreetingEntity greeting);

        GreetingEntity? GetGreetingById(int id);

        List<GreetingEntity> GetAllGreetings();

        GreetingEntity UpdateGreeting(int id, string NewMssge);
    }
}
