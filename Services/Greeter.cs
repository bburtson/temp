using Microsoft.Extensions.Configuration;

namespace USTVA.Services
{
    public class Greeter : IGreeter
    {
        public string _greeting;

        public Greeter(IConfigurationRoot config)
        {
            _greeting = config["Greeting"];
        }

        public string GetGreeting()
        {    
            return _greeting;
        }
    }
}
