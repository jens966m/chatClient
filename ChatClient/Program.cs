using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ChatClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Run();
        }

        public void Run()
        {
            string serverName = Console.ReadLine();
            int port = int.Parse(Console.ReadLine());
            ServerFacade serverFacade = new ServerFacade(port, serverName);
            

        }
    }
}
