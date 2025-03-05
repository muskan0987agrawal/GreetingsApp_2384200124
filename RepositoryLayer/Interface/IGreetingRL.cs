using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryLayer.Entity;
using RepositoryLayer.Service;


namespace RepositoryLayer.Interface
{
   public interface IGreetingRL
    {
        GreetingEntity AddGreetings(GreetingEntity greeting);
        GreetingEntity GetGreetingById(int id);
        List<GreetingEntity> GetAllGreetings();
        GreetingEntity UpdateGreeting(int id, string newMssge);
    }
}
