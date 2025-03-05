using System;
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
        Greeting AddGreeting(Greeting greeting);

        Greeting? GetGreetingById(int id);
    }
}
