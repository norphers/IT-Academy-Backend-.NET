using System;
using System.Runtime.CompilerServices;
using System.Collections.Generic;
using System.Transactions;
using System.Dynamic;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.VisualBasic.CompilerServices;

namespace ConsoleApp4
{
    class Program
    {
        static List<User> userRepository = new List<User>();
        static User userSesion;
        static void Main(string[] args)
        {
            AddData();
            AuthenticationModule();
            
            Console.WriteLine("Hello " + userSesion.GetName() + " " + userSesion.GetSurname());
            
            Menu();


            // estructura de menus

            // crear video
            // cambiar estado de video (play/pause/stop)
            // añadir nuevos tags en el video

        }


        //----------------------------------------------//

        public static void AddData()
        {
            userRepository.Add(new User("admin", "Bilbo", "Baggins", "1234", DateTime.Now));
            userRepository.Add(new User("user1", "Frodo", "Baggind", "5678", DateTime.Now));
            userRepository.Add(new User("user2", "Samwise", "Gamgee", "9101", DateTime.Now));
        }
        public static void PrintUserRepository(List<User> repository)
        {
            foreach (User one in userRepository)
            {
                Console.WriteLine(one.ToString());
            }
        }
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
        public static void Menu()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 - New video\n" + "2 - Edit Video\n" + "3 - Delete Video\n" + "4 - Show Video Repository\n");
            Console.Write("Select option: ");

            switch (Console.Read())
            {
                case '1':
                    Console.Write("New video.");
                    // Continuar lógica y extraer métodos //
                    break;
                case '2':
                    Console.Write("Edit video.");
                    // Continuar lógica y extraer métodos //
                    break;
                case '3':
                    Console.Write("Delete video.");
                    // Continuar lógica y extraer métodos //
                    break;
                case '4':
                    Console.Write("Show video repository");
                    // Continuar lógica y extraer métodos //
                    break;
            }
            Console.ReadKey();
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


    public class Video
    {
        public enum State
        {
            Play, Pause, Stop
        }

        private string url;
        private string title;
        private List<string> tags = new List<string>();
        private State state;
        
        public Video()
        {

        }

        public Video(string url, string title, List<string> tags, State state)
        {
            this.url = url;
            this.title = title;
            this.tags = tags;
            this.state = state;
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
        public State GetState()
        {
            return this.state;
        }
        public void SetState(State state)
        {
            this.state = state;
        }
    }

    public class User
    {
        private string name;
        private string surname;
        private string username;
        private string password;
        private DateTime registerDate;
        private List<Video> videoRepository = new List<Video>();
        private string token = "";
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

        public User(string token)
        {
            this.token = token;
        }

        public void SetUserVideoRepository(List<Video> videoRepository)
        {
            this.videoRepository = videoRepository;
        }

        public string GetUsername()
        {
            return this.username;
        }
        public void SetUsername(string username)
        {
            // condition ? consequent : alternative
            //username != string.Empty && username != null ? this.username=username : throw new ArgumentNullException("username cannot be empty or null");
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
        public List<Video> GetVideoRepository()
        {
            return this.videoRepository;
        }
        public void SetVideoRepository(List<Video> videoRepository)
        {
            this.videoRepository = videoRepository;
        }
        public string GetToken()
        {
            return this.token;
        }
        public void SetToken(string token)
        {
            this.token = token;
        }
        public override string ToString()
        {
            return base.ToString() + ": " + name.ToString() + " " + surname.ToString() + ", username: " + username.ToString() + " password: " + password.ToString() + ", tokenAUTH: " + token.ToString();
        }
    }
}
