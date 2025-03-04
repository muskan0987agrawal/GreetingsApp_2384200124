using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Interface;
using ModelLayer.Model;

namespace BusinessLayer.Service
{
    public class GreetingBL: IGreetingBL
    {
        public GreetingBL()
        {
            
        }
        public string getGreetMessage()
        {
            return "Hello World";
        }

        public string GetGreetingMessage(UsernameRequestModel request)
        {
            if (!string.IsNullOrWhiteSpace(request.FirstName) && !string.IsNullOrWhiteSpace(request.LastName))
            {
                return $"Hello, {request.FirstName} {request.LastName}!";
            }
            else if (!string.IsNullOrWhiteSpace(request.FirstName))
            {
                return $"Hello, {request.FirstName}!";
            }
            else if (!string.IsNullOrWhiteSpace(request.LastName))
            {
                return $"Hello, {request.LastName}!";
            }
            return "Hello World!";
        }
    }
}
