using System;

namespace SeaBattle {
    public class Program {
        static void Main(string[] args) {
            var fild = new Field();
            fild.NewField();
            var sp = new Ships();
            fild.ShipLayout(5,5,sp.LightShip,Direction.Right);
            Console.ReadKey();
        }
       
    }
}

