using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace Chat
{
    class Program
    {
        static void Main(string[] args)
        {
            /*IChatter bob = new TextChatter("Bob");
            IChatter joe = new TextChatter("Joe");
            ITopicsManager gt = new TextGestTopics();

            gt.createTopic("java");
            gt.createTopic("UML");
            gt.listTopics();
            gt.createTopic("jeux");
            gt.listTopics();
            IChatroom cr = gt.joinTopic("jeux");
            cr.join(bob);
            cr.post("Je suis seul ou quoi ?",bob);
            cr.join(joe);
            cr.post("Tiens, salut Joe !",bob);
            cr.post("Toi aussi tu chat sur les forums de jeux pendant les TP, Bob?",joe);

            Console.Read();*/

            /*AuthentificationManager am = new Authentification();

            // users management

            try
            {
                am.addUser("bob", "123");
                Console.WriteLine("Bob has been added !");
                am.removeUser("bob");
                Console.WriteLine("Bob has been removed !");
                am.removeUser("bob");
                Console.WriteLine("Bob has been removes twice !");
            }
            catch (UserUnknownException e)
            {
                Console.WriteLine(e.login + " : user unknown (enable to remove) !");
            }
            catch (UserExistsException e)
            {
                Console.WriteLine(e.login + " has already been added !");
            }

            // authentification
            try
            {
                am.addUser("bob", "123");
                Console.WriteLine("Bob has been added !");
                am.authentify("bob", "123");
                Console.WriteLine("Authentification OK !");
                am.authentify("bob", "456");
                Console.WriteLine("Invalid password !");
            }
            catch (WrongPasswordException e)
            {
                Console.WriteLine(e.login + " has provided an invalid password !");
            }
            catch (UserExistsException e)
            {
                Console.WriteLine(e.login + " has already been added !");

            }
            catch (UserUnknownException e)
            {
                Console.WriteLine(e.login + " : user unknown (enable to remove) !");
            }

            // persistance
            try
            {
                am.save("users.txt");
                AuthentificationManager am1 = new Authentification();
                am1.load("users.txt");
                am1.authentify("bob", "123");
                Console.WriteLine("Loading complete !");
            }
            catch (UserUnknownException e)
            {
                Console.WriteLine(e.login + " is unknown ! error during the saving/loading.");
            }
            catch (WrongPasswordException e)
            {
                Console.WriteLine(e.login + " has provided an invalid password! error during the saving/loading .");
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }

            Console.Read();*/

            /*TCPServerTest test = new TCPServerTest();

            test.startServer(25565);
            new Thread(test.run).Start();*/

            Server.ServerGestTopics server = new Server.ServerGestTopics();
            server.startServer(25565);

            new Thread(server.run).Start();
        }
    }
}
