using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiscordPortal.Net;

namespace EveryTokens
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "EveryToken";
            PortalClient client = new PortalClient();
            string token = File.ReadAllText("token.txt");

            // Turn to True to save tokens
            bool SaveToken = false;
            client.Connect(token);

            Applications app = client.GetApplications();
            string tokenlist = "";
            foreach (Apps ap in app.Apps)
            {
                
                if (ap.bot != null)
                {
                    Console.WriteLine(ap.bot.username+"#"+ap.bot.discriminator.ToString()+" | "+ap.bot.token);
                    tokenlist += ap.bot.token + Environment.NewLine;
                }
            }
            if (SaveToken)
            {
                var c = File.Create("tokenlist.txt");
                c.Dispose();
                c.Close();
                File.WriteAllText("tokenlist.txt",tokenlist);
            }
            Console.ReadLine();

        }
    }
}
