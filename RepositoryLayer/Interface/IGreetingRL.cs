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
        Greeting AddGreetings(Greeting greeting);
        Greeting GetGreetingById(int id);
        List<Greeting> GetAllGreetings();
    }
}
