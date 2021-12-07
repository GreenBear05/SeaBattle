using System;

namespace SeaBattle {
    public class Program {
        static void Main(string[] args) {
            

            Battleground battleground = new Battleground();
            battleground.Preparation();
            battleground.Battle();
            
            Console.ReadKey();
        }
       
    }
}

