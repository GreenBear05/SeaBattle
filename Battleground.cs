using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle {
    public class Battleground {
        Field fild1 = new Field();
        Field fild2 = new Field();
        public void Preparation() {
            var sp = new Ships();
            
            fild1.NewField(true);
            fild2.NewField(false);
            fild1.ShipLayout(5, 5, sp.LightShip, Direction.Right,true);
            fild2.ShipLayout(5, 5, sp.HShip, Direction.Right,false);
           
        }
        public void Battle() {
            while(true) {
                Console.WriteLine("выстрел игрока1");
                fild1.Shot(fild2.field,true);
                Console.WriteLine("выстрел игрока2");
                fild2.Shot(fild1.field,false);
                
            }

        }
    }
}
