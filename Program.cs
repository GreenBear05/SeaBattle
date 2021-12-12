using System;
using System.IO;
using System.Text.Json;


namespace SeaBattle {
    public class Program {
        private static Battleground battleground = new Battleground();
        static void Main(string[] args) {
            // AppDomain.CurrentDomain.ProcessExit+=CurrentDomain_ProcessExit;
            battleground.Preparation();
            battleground.Battle();

            Console.ReadKey();
        }

       

        
        
    }

}