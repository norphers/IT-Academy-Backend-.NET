using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Transactions;
using System.Dynamic;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.VisualBasic.CompilerServices;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;

namespace ConsoleApp4
{
    class Program
    {
        static List<User> userRepository = new List<User>();
        static List<Video> videoRepository = new List<Video>();
        static User userSesion;
        static void Main(string[] args)
        {
            LoadData();
            AuthenticationModule();
            Menu();

            // add tags to Video
            // option 2 (edit video)
            // delete video
        }


        //----------------------------------------------//
        
        public static void Menu()
        {
            Console.Write($"Hello {userSesion.GetName()} {userSesion.GetSurname()}. ");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - New video\n2 - Edit Video\n3 - Delete Video\n4 - Show Video Repository\n");
            Console.Write("Select option: ");
            string option = Console.ReadLine();
            if (option.Equals("1"))
            {
                Console.Clear();
                Console.Write("Create new video.");
                CreateVideo();
                Continue();
            }
            else if (option.Equals("2"))
            {
                Console.Clear();
                Console.WriteLine("Under Construction. Come back later.");
                Continue();
            }
            else if (option.Equals("3"))
            {
                Console.Clear();
                Console.WriteLine("Under Construction. Come back later.");
                Continue();
            }
            else if (option.Equals("4"))
            {
                Console.Clear();
                Console.WriteLine($"Video repository of {userSesion.GetUsername().ToUpper()}.");
                PrintVideoRepository();
                Continue();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("sorry I do not understand you. Please select one of the options.");
                Continue();
            }
        }

        public static User CreateUser()
        {
            User newUser = new User();
            Console.WriteLine("Create new user.");
            Console.Write("username: ");
            newUser.SetUsername(Console.ReadLine());
            Console.Write("name: ");
            newUser.SetUsername(Console.ReadLine());
            Console.Write("surname: ");
            newUser.SetUsername(Console.ReadLine());
            Console.Write("pasword: ");
            newUser.SetUsername(Console.ReadLine());
            newUser.SetRegisterDate(DateTime.Now);
            return newUser;
        }

        // ---------- VIDEO ---------- //

        public static Video CreateVideo()
        {
            Video video = new Video();
            video.SetUsername(userSesion.GetUsername());
            Console.Write("url: ");
            video.SetUrl(Console.ReadLine());
            Console.Write("title: ");
            video.SetTitle(Console.ReadLine());
            videoRepository.Add(video);
            return video;
        }     


        // ---------- DATA ---------- //
        
        public static void LoadData()
        {
            userRepository.Add(new User("admin", "Bilbo", "Baggins", "1234", DateTime.Now));
            userRepository.Add(new User("frodo", "Frodo", "Baggins", "5678", DateTime.Now));
            userRepository.Add(new User("sam", "Samwise", "Gamgee", "9101", DateTime.Now));
            videoRepository.Add(new Video("frodo", "www.example.com/user1", "Title1"));
            videoRepository.Add(new Video("frodo", "www.example.com/user1", "Title2"));
            videoRepository.Add(new Video("admin", "www.example.com/admin", "Title1"));
        }
        public static void PrintUserRepository(List<User> repository)
        {
            foreach (User one in repository)
            {
                Console.WriteLine(one.ToString());
            }
        }
        public static void PrintVideoRepository()
        {
            foreach (Video one in videoRepository)
            {
                if (one.GetUsername().Equals(userSesion.GetUsername()))
                {
                    Console.WriteLine(one.ToString());
                }
            }
        }


        // ---------- BASIC COMMANDS ---------- //

        public static Boolean Exit()
        {
            Boolean response;
            Boolean answerBack = false;
            do
            {
                Console.Write("Do you want to exit? Y/N : ");
                string answer = Console.ReadLine().ToUpper();
                if (answer.Equals("Y"))
                {
                    response = true;
                    answerBack = true;
                }
                else if (answer.Equals("N"))
                {
                    response = true;
                    answerBack = false;
                }
                else
                {
                    Console.WriteLine("sorry I do not understand you. Please insert Y or N.");
                    response = false;
                }
            } while (response == false);
            return answerBack;
        }

        public static void Continue()
        {
            string response;
            Console.Write("\nDo you want to return to menu? Y/N : ");
            response = Console.ReadLine().ToLower();
            if (response.Equals("y"))
            {
                Console.Clear();
                Menu();
            }
            else if (response.Equals("n"))
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("sorry I do not understand you. Please insert Y or N.");
                Continue();
            }
        }


        // ---------- AUTHENTICATION ---------- //

        public static void AuthenticationModule()
        {
            Boolean authResponse;
            int attempt = 0;
            do
            {
                Console.WriteLine("WELCOME TO YOU NEW VIDEO APP.");
                authResponse = Authentication();
                attempt++;
                if (attempt == 3) { Environment.Exit(0); }
            } while (authResponse == false);
        }
        public static Boolean Authentication()
        {
            string usernameAuth;
            string passwordAuth;
            Boolean authResponse = false;
            Console.Write("username: ");
            usernameAuth = Console.ReadLine();
            Console.Write("pasword: ");
            passwordAuth = Console.ReadLine();
            foreach (User one in userRepository)
            {
                if (one.GetUsername().Equals(usernameAuth) && one.GetPassword().Equals(passwordAuth))
                {
                    authResponse = true;
                    one.SetToken(System.Guid.NewGuid().ToString());
                    userSesion = one;
                    Console.Clear();
                }
            }
            if (authResponse == false)
            {
                Console.WriteLine("Login failed");
                Console.Clear();
            }
            return authResponse;
        }
    }
}
