using System;
using System.Media;   // this lets us play a sound file
using System.Threading; // we use this to do the typing effect

namespace CyberBotApp
{
    class ChatBot

    {
        private string userName = ""; // store the name of the person chatting

       
        public void StartChat()   // this starts the whole chat process
        {
            PlayGreeting();      // play a welcome sound if we have it

            AskUserName();       // ask the person for their name

            ShowWelcomeHeader(); // show a nice welcome message

            RunChatLoop();       // start talking to the person

        }

        
        
        private void PlayGreeting()// this tries to play a .wav sound
        {
            
            try
            
            {
                SoundPlayer player = new SoundPlayer("greeting.wav");

                player.PlaySync(); // play the sound and wait until it's done
            
            }
            
            catch
            
            {
                
                Console.WriteLine("Bot: Voice greeting not found. Skipping sound...");// if file is missing, we just move on

            }
        }

       
        private void AskUserName()  // ask the user for their name

        {
            Console.ForegroundColor = ConsoleColor.Cyan;

            
            Console.Write("Bot: Hi! What is your name? ");
            
            Console.ResetColor();

            userName = Console.ReadLine()?.Trim(); // read what they type

            
            if (string.IsNullOrWhiteSpace(userName))// if they didn't type anything, just call them Friend
            
            {
                userName = "Friend";

            }

        }

        // show a welcome message with lines to make it look nice
        private void ShowWelcomeHeader()
        {
            
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("=========================================");

            Console.WriteLine($"   Welcome, {userName}, to Cybersecurity Bot!");

            Console.WriteLine("   Stay safe online and ask me anything.");

            Console.WriteLine("=========================================");

            Console.ResetColor();

            Console.WriteLine();
        }

       
        private void RunChatLoop() // this is the main loop where the chat happens
        {
            bool running = true;

            while (running)
            {
                
                Console.ForegroundColor = ConsoleColor.Yellow;// show the prompt so user can type

                Console.Write($"{userName}: ");

                Console.ResetColor();

                string userInput = Console.ReadLine()?.Trim();

               
                if (string.IsNullOrWhiteSpace(userInput)) // if they didn't type anything, tell them and ask again
                
                {
                    
                    ShowBotMessage("You didn't type anything. Please try again.", ConsoleColor.Red); // if they didn't type anything, tell them and ask again
                    continue;
                }

                
                string answer = GetResponse(userInput);// get what the bot should say
                ShowBotMessage(answer, ConsoleColor.Cyan);

               
                if (userInput.ToLower().Contains("thank")) // only ask the yes/no question if user said "thank"
                {
                    running = AskMoreHelp(); // check if they want more help
                }
            }
        }

        
        private bool AskMoreHelp()// ask user if they want more help after they say thank you
        {
            while (true)
            {
                ShowBotMessage("OK, is there anything else I can help you with? (yes/no)", ConsoleColor.Magenta);

                Console.ForegroundColor = ConsoleColor.Yellow;
                
                Console.Write($"{userName}: ");
                
                Console.ResetColor();
                
                string reply = Console.ReadLine()?.ToLower().Trim() ?? "";

                
                if (reply.Contains("no"))// if they say no, we say goodbye and stop
                {
                    ShowBotMessage($"Okay, goodbye {userName}! Stay safe online.", ConsoleColor.Green);
                    return false;
                }
               
                else if (reply.Contains("yes")) // if they say yes, we ask what else they want
                {
                    ShowBotMessage("Great! What else can I help you with?", ConsoleColor.Cyan);
                    return true;
                }
                
                else
                {
                    ShowBotMessage("Please type yes or no.", ConsoleColor.Red);// if they type something else, we ask them to type yes or no
                }
            }
        }

        
        private void ShowBotMessage(string message, ConsoleColor color)// show the bot's message with typing effect
        {
            Console.ForegroundColor = color;
            
            TypeWrite("Bot: " + message); // make it look like bot is typing
            
            Console.ResetColor();
        }

        
        private void TypeWrite(string message)// typing effect: prints one letter at a time
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(30); // short delay per letter
            }
            Console.WriteLine();
        }

        
        private string GetResponse(string message)// decides what the bot should say
        {
            string msg = message.ToLower().Trim();

            
            if (string.IsNullOrEmpty(msg))// empty input
            {
                return "You didn't type anything. Please try again.";
            }

            
            if (msg.Contains("how are you"))// questions we know how to answer

                return "I'm fine! I just want to help you stay safe online.";
            
            if (msg.Contains("your purpose") || msg.Contains("what do you do"))
               
                return "I teach people about cybersecurity and online safety.";
            
            if (msg.Contains("what can i ask"))
               
                return "You can ask me about passwords, phishing, viruses, safe browsing, or social media.";
            if (msg.Contains("password"))
               
                return "A password is a secret code that protects your accounts. Only you should know it. Always use strong passwords with numbers, symbols, and capital letters.e.g_Phathutshedzo123$";
            
            if (msg.Contains("wifi"))
              
               
                return "WiFi is the internet connection for your devices. Public WiFi can be unsafe. Avoid using it for banking or important accounts.";
            
            if (msg.Contains("email"))
                
                return "Email is your online mailbox. Some emails can trick you. Never click links from unknown emails and use two-factor authentication.";
            
            if (msg.Contains("phishing"))
               
                return "Phishing is when someone tries to trick you to give personal info. Always check who is sending messages before clicking links.";
            
            if (msg.Contains("virus") || msg.Contains("malware"))
                
                return "A computer virus can damage your files or steal info. It spreads from unsafe downloads or links. Keep antivirus software updated.";
            
            if (msg.Contains("social media"))
                
                return "Social media is where people share posts and messages. Don't share personal info and check privacy settings.";
            
            if (msg.Contains("browsing") || msg.Contains("safe browsing"))
                
                return "Browsing means visiting websites online. Some sites can be unsafe. Always check addresses and avoid suspicious sites.";

            
            
            return "I didn't quite understand that. Could you rephrase?";// default answer if we don't understand
        }
    }
}