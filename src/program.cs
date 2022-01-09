using System;
using Leaf.xNet;

namespace dtde_claimer_unpacked
{
    class Program
    {
        public static int thread_count;
        public static string target;
        public static string proxy_option;
        public static string writemsg_match;
        public static int attempts;
        public static bool claimed;
        public static int bad_requests;
        public static int requests_per_second;
        public static int integer_1;
        public static int integer_2;
        public static int integer_3;
        public static System.Collections.Generic.List<string> proxy_list;
        public static System.Collections.Generic.List<string> session_list;
        public static System.Collections.Generic.List<string> list;
        public static bool random_boolean;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern void MessageBoxW(int hwnd, string message, string title, int flag);
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("@DTDE Claimer Unpacked by Eve");
            Console.WriteLine("Nice Authentication:  https://pastebin.com/raw/2TkGGr5Z");
            System.Threading.Thread.Sleep(10000);
            proxy_list = new System.Collections.Generic.List<string>(System.IO.File.ReadLines("proxies.text"));
            session_list = new System.Collections.Generic.List<string>(System.IO.File.ReadAllLines("sessions.txt"));
            list = new System.Collections.Generic.List<string>(System.IO.File.ReadAllLines("list.txt"));
            System.Threading.Thread.Sleep(5000);
            Console.Clear(); EntryPoint(); 
        }

        public static void EntryPoint()
        {
            string settings_file = System.IO.File.ReadAllText("settings.txt");
            string name_match = System.Text.RegularExpressions.Regex.Match(settings_file, "Name:(.*?)]").Groups[1].Value;
            string msgbox_match = System.Text.RegularExpressions.Regex.Match(settings_file, "Msgbox:(.*?)]").Groups[1].Value;
            writemsg_match = System.Text.RegularExpressions.Regex.Match(settings_file, "WriteMessage:(.*?)]").Groups[1].Value;
            string bio_match = System.Text.RegularExpressions.Regex.Match(settings_file, "Bio:(.*?)]").Groups[1].Value;
            System.Net.ServicePointManager.DefaultConnectionLimit = int.MaxValue;
            System.Threading.ThreadPool.SetMinThreads(int.MaxValue, int.MaxValue);
            System.Threading.ThreadPool.SetMaxThreads(int.MaxValue, int.MaxValue);
            System.Net.ServicePointManager.Expect100Continue = false;
            System.Net.ServicePointManager.CheckCertificateRevocationList = false;
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            System.Net.ServicePointManager.UseNagleAlgorithm = false;
            Console.SetWindowSize(70, 12);
            //The most incompetent person I have ever seen.
            Console.ForegroundColor = (ConsoleColor)15;
            Console.Write("[");
            Console.ForegroundColor = (ConsoleColor)4;
            Console.Write("x");
            Console.ForegroundColor = (ConsoleColor)15;
            Console.Write("] - 1 For List Or 2 For Target : ");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    AlternateStartingPoint();
                    break;
                case "2":
                    StartingPoint();
                    break;
                default:
                    Console.Clear();
                    EntryPoint();
                    break;
            }
        }

        public static void ThreadHandler()
        {
            if (claimed != true)
            {
                for (int i = 0; i < thread_count; i++)
                {
                    System.Threading.Thread thread = new System.Threading.Thread(RequestWithListOneUsername);
                    thread.IsBackground = false;
                    thread.Priority = System.Threading.ThreadPriority.Highest;
                    thread.Start();
                }
            }
        }

        public static void AlternateThreadHandler()
        {
            if (claimed != true)
            {
                for (int i = 0; i <= thread_count; i++)
                {
                    System.Threading.Thread thread = new System.Threading.Thread(RequestWithListWithMultipleUsernames);
                    thread.IsBackground = false;
                    thread.Priority = System.Threading.ThreadPriority.Highest;
                    thread.Start();
                }
            }
        }

        public static void AlternateStartingPoint()
        {
            Console.ForegroundColor = (ConsoleColor)15;
            Console.Write("[");
            Console.ForegroundColor = (ConsoleColor)11;
            Console.Write("x");
            Console.ForegroundColor = (ConsoleColor)15;
            Console.WriteLine("] Threads : ");
            try
            {
                thread_count = Convert.ToInt32(Console.ReadLine());
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine("Oops.. we went into an exception.");
                Console.WriteLine($"Exception: {ex.ToString()}");
                System.Threading.Thread.Sleep(5000);
                Console.Clear(); AlternateStartingPoint();
            }
            Console.ForegroundColor = (ConsoleColor)15;
            Console.Write("[");
            Console.ForegroundColor = (ConsoleColor)11;
            Console.Write("x");
            Console.ForegroundColor = (ConsoleColor)15;
            Console.Write("] - Socks4 [1] http [2] Socks5 [3] : ");
            proxy_option = Console.ReadLine();
            AlternateThreadHandler();
        }

        public static void StartingPoint()
        {
            Console.ForegroundColor = (ConsoleColor)15;
            Console.Write("[");
            Console.ForegroundColor = (ConsoleColor)11;
            Console.Write("x");
            Console.ForegroundColor = (ConsoleColor)15;
            Console.Write("] - Target : ");
            target = Console.ReadLine();

            Console.ForegroundColor = (ConsoleColor)15;
            Console.Write("[");
            Console.ForegroundColor = (ConsoleColor)11;
            Console.Write("x");
            Console.ForegroundColor = (ConsoleColor)15;
            Console.WriteLine("] Threads : ");
            try
            {
                thread_count = Convert.ToInt32(Console.ReadLine());
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine("Oops.. we went into an exception.");
                Console.WriteLine($"Exception: {ex.ToString()}");
                System.Threading.Thread.Sleep(5000);
                Console.Clear(); StartingPoint();
            }
            Console.ForegroundColor = (ConsoleColor)15;
            Console.Write("[");
            Console.ForegroundColor = (ConsoleColor)11;
            Console.Write("x");
            Console.ForegroundColor = (ConsoleColor)15;
            Console.Write("] - Socks4 [1] http [2] Socks5 [3] : ");
            proxy_option = Console.ReadLine();
            ThreadHandler();

        }

        public static void RequestWithListWithMultipleUsernames()
        {
            while (claimed != true)
            {
                try
                {
                    integer_3++;
                    if (integer_3 >= list.Count - 1)
                    {
                        integer_3 = 0;
                    }
                    integer_1++;
                    if (integer_1 >= proxy_list.Count - 1)
                    {
                        integer_1 = 0;
                    }
                    integer_2++;
                    if (integer_2 >= session_list.Count - 1)
                    {
                        integer_2 = 0;
                    }
                    ChangeUsername(list[integer_3], proxy_list[integer_1], session_list[integer_2]);
                    
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Sowwy. Dumb programmers don't know what to with the catch block.");
                    Console.WriteLine($"Exception: {exception.ToString()}");
                }
            }
        }

        public static void RequestWithListOneUsername()
        {
            claimed = false;
            integer_1 = 0;
            integer_2 = 0;
            try
            {
                while (claimed != true)
                {
                    if (claimed != true)
                    {
                        integer_1++;
                        if (integer_1 >= proxy_list.Count - 1)
                        {
                            integer_1 = 0;
                        }
                        integer_2++;
                        if (integer_2 >= session_list.Count - 1)
                        {
                            integer_2 = 0;
                        }
                        ChangeUsername(Program.target, proxy_list[integer_1], session_list[integer_1]);
                    }

                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Sowwy. Dumb programmers don't know what to with the catch block.");
                Console.WriteLine($"Exception: {exception.ToString()}");
            }
        }

        public static void ChangeUsername(string target, string proxy, string session_id)
        {
            try
            {
                Random random = new Random();
                HttpRequest request = new HttpRequest();
                request.IgnoreProtocolErrors = true;
                request.UserAgent = "Instagram 10.3.2 Android";
                request.AddHeader("Accept-Language", "en-US");
                request.AddHeader("Cookie", $"sessionid={session_id}");
                request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                request.AddHeader("Host", "i.instagram.com");
                request.KeepAlive = true;
                request.ConnectTimeout = 1000;
                switch (proxy_option)
                {
                    case "1":
                        if (proxy_option == "2")
                            HttpRequest.GlobalProxy = ProxyClient.Parse(ProxyType.HTTP, proxy);
                        else if (proxy_option == "3")
                            HttpRequest.GlobalProxy = ProxyClient.Parse(ProxyType.Socks5, proxy);
                        break;
                    default:
                        HttpRequest.GlobalProxy = ProxyClient.Parse(ProxyType.Socks4, proxy);
                        break;
                }
                StringContent content = new StringContent($"username={target}");
                string response = request.Post("https://i.instagram.com/api/v1/accounts/set_username", content).ToString();
                if (response.Contains("\"status\":\"ok\""))
                {
                    string email = System.Text.RegularExpressions.Regex.Match(response, "\"email\":\"(.*?)\",").Groups[1].Value;
                    Console.ForegroundColor = (ConsoleColor)15;
                    Console.Write("[");
                    Console.ForegroundColor = (ConsoleColor)10;
                    Console.Write("$");
                    Console.ForegroundColor = (ConsoleColor)15;
                    Console.Write("[");
                    Console.ForegroundColor = (ConsoleColor)11;
                    Console.Write(writemsg_match);
                    Console.ForegroundColor = (ConsoleColor)12;
                    Console.Write($"@{target}");
                    Console.ForegroundColor = (ConsoleColor)11;
                    Console.Write("Attempts: ");
                    Console.ForegroundColor = (ConsoleColor)12;
                    Console.Write($"{attempts.ToString()}\r\n");
                    System.IO.File.WriteAllText($"@{target}_info.txt", $"User: @{target}\r\nEmail:{email}\r\nSessionID:{session_id}\r\nLove from your favorite reverse engineer,\r\nEve <3");
                    if (proxy_list.Count == 1)
                    {
                        proxy_list.Remove(session_id);
                    }
                    else
                    {
                        claimed = true;
                        Console.ForegroundColor = (ConsoleColor)12;
                        Console.WriteLine("Auto Claimer Stopped ...  No SessionID");
                    }
                    EditProfile(target, email, session_id);
                    if (random_boolean != true)
                    {
                        random_boolean = true;
                        MessageBoxW(0, $"@{target}\r\nAttempts: {attempts}\r\nReverse Engineered by Eve ;3", "Reverse Engineered by Eve ;3", (int)0x00000000L);
                    }
                }
                if (response.Contains("This username isn't available"))
                {
                    if (response.Contains("Please wait a few minutes before you try again"))
                    {
                        bad_requests++;
                        Console.Title = $"Attempt [{attempts}] / Error [{bad_requests}] / R/S[{requests_per_second}]";
                    }
                }
                else
                {
                    attempts++;
                    Console.Title = $"Attempt [{attempts}] / Error [{bad_requests}] / R/S[{requests_per_second}]";
                }
                request.Dispose();
                request.ClearAllHeaders();
                request.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Sowwy. Dumb programmers don't know what to do with catch blocks.");
                Console.WriteLine($"Exception: {exception.ToString()}");
            }
        }
        public static void EditProfile(string username, string email, string session_id)
        {
            try
            {
                System.Net.ServicePointManager.CheckCertificateRevocationList = false;
                System.Net.ServicePointManager.DefaultConnectionLimit = 300;
                System.Net.ServicePointManager.UseNagleAlgorithm = false;
                System.Net.ServicePointManager.Expect100Continue = false;
                System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
                string data = $"gender=1&_csrftoken=missing&_uuid={System.Guid.NewGuid().ToString()}&external_url=&username={username}&email={email}&phone_number=&biography=Reverse Engineered by Eve ;3&first_name=Goodmorning from Eve";
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
                System.Net.HttpWebRequest Request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("https://i.instagram.com/api/v1/accounts/edit_profile/");
                Request.Method = "POST";
                Request.ServicePoint.UseNagleAlgorithm = false;
                Request.ServicePoint.ConnectionLimit = 300;
                Request.Proxy = null;
                Request.UserAgent = "Instagram 10.26.0 Android (26/8.0.0; 320dpi; 768x1184; unknown/Android; Custom Phone; vbox86p; vbox86; en_US; 23286034)";
                Request.Headers.Add("Accept-Language", "en-US");
                Request.Headers.Add("Cookie", $"sessionid={session_id}");
                Request.ContentType = "application/x-www-form-urlencoded; charset=UTF-8";
                Request.ContentLength = (long)bytes.Length;
                System.IO.Stream stream = Request.GetRequestStream();
                stream.Write(bytes, 0, bytes.Length);
                stream.Dispose(); stream.Close();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Sowwy. Dumb programmers don't know what to do with catch blocks.");
                Console.WriteLine($"Exception: {exception.ToString()}");
            }

        }
        public static void SendWebhook(string username)
        {

        }

        public static void CalculateRequestsPerSecond()
        {
            while (claimed != true)
            {
                int old_attempts = attempts;
                System.Threading.Thread.Sleep(1000);
                requests_per_second = attempts - old_attempts;
                Console.Title = $"Attempt [{attempts}] / Error [{bad_requests}] / R/S[{requests_per_second}]";
            }
        }
    }
}
