using System;

namespace CyberBotApp
{
class Program
    {
static void Main(string[] args)
      {
  // Display ASCII logo
            
 Console.WriteLine("=========================================");
            
 Console.WriteLine("     CYBERSECURITY AWARENESS BOT");
            
 Console.WriteLine("=========================================");
            
 Console.WriteLine();

            
 ChatBot bot = new ChatBot();// Start chatbot
            
 bot.StartChat();
        
        }
    
    }
}