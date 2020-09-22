using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Transactions;
using System.Dynamic;

namespace ConsoleApp4
{
    class Program
    {
        static User admin = new User("admin", "john", "doe", "1234", DateTime.Now);
        static List<User> userRepository = new List<User>();
        static List<Video> videoRepository = new List<Video>();
        static void Main(string[] args)
        {
            userRepository.Add(admin);
            Console.WriteLine("WELCOME TO YOU NEW VIDEO APP.");
            string option = OptionPanel();
            if (option.Equals("1"))
            {
                Video video1 = setVideo();
                videoRepository.Add(video1);
            }
            else if (option.Equals("2"))
            {
                Console.WriteLine(videoRepository); 
            }
            else if (option.Equals("3"))
            {
                User newUser = setUser();
                userRepository.Add(newUser);
            }

        }

        public static string OptionPanel()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - Create new video\n" + "2 - Check your Video Repository\n" + "3 - Create new User\n" + "Select option 1, 2 or 3\n");    
            string response = Console.ReadLine();
            Boolean whileStatement;
            do {
                if (response.Equals("1"))
                {
                    whileStatement = true;
                }
                else if (response.Equals("2"))
                {
                    whileStatement = true;
                }
                else if (response.Equals("3"))
                {
                    whileStatement = true;
                }
                else
                {
                    Console.WriteLine("sorry I don not understand you. Please insert 1, 2 or 3.");
                    whileStatement = false;
                }
            } while (whileStatement==false);
            return response;
        }

        public static User setUser()
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
        public static Video setVideo()
        {
            Video newVideo = new Video();
            Console.WriteLine("Create new video.");
            Console.Write("url: ");
            newVideo.SetUrl(Console.ReadLine());
            Console.Write("title: ");
            newVideo.SetTitle(Console.ReadLine());
            List<string> tags = CreateTags();
            return newVideo;
        }

        public static List<string> CreateTags()
        {
            List<string> tags = new List<string>();
            Boolean exit;
            do
            {
                Console.Write("Enter a new tag: ");
                string tag = Console.ReadLine();
                tags.Add(tag);
                exit = Exit();
            } while (exit == false);
            return tags;
        }

        public static Boolean Exit()
        {
            Boolean response;
            Boolean answerBack=false;
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
                    Console.WriteLine("sorry I don not understand you. Please insert Y or N.");
                    response = false;
                }
            } while (response==false);
            return answerBack;
        }
    }


    //---------------------------------------------------------------------//


    class Video
    {
        private string url;
        private string title;
        private List<string> tags = new List<string>();

        public Video()
        {

        }

        public Video(string url, string title, List<string> tags)
        {
            this.url = url;
            this.title = title;
            this.tags = tags;
        }

        public string GetUrl()
        {
            return this.url;
        }

        public void SetUrl(string url)
        {
            this.url = url;
        }

        public string GetTitle()
        {
            return this.title;
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }
        public List<string> GetTags()
        {
            return this.tags;
        }
        public void SetTags(List<string> tags)
        {
            this.tags = tags;
        }

    }

    class User
    {
        private string username;
        private string name;
        private string surname;
        private string password;
        private DateTime registerDate;

        public User()
        {

        }

        public User(string username, string name, string surname, string password, DateTime registerDate)
        {
            this.username = username;
            this.name = name;
            this.surname = surname;
            this.password = password;
            this.registerDate = registerDate;
        }

        public string GetUsername()
        {
            return this.username;
        }

        public void SetUsername(string username)
        {
            this.username = username;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetSurname()
        {
            return this.surname;
        }

        public void SetSurname(string surname)
        {
            this.surname = surname;
        }
        public string GetPassword()
        {
            return this.password;
        }

        public void SetPassword(string password)
        {
            this.password = password;
        }
        public DateTime GetRegisterDate()
        {
            return this.registerDate;
        }

        public void SetRegisterDate(DateTime registerDate)
        {
            this.registerDate = registerDate;
        }

    }


}
