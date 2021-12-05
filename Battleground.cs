using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle {
    public class Battleground {
        public void Preparation() {
            var sp = new Ships();

            var fild1 = new Field();
            var fild2 = new Field();
            fild1.NewField(true);
            fild2.NewField(false);
            fild1.ShipLayout(5, 5, sp.LightShip, Direction.Right);
            fild2.ShipLayout(5, 5, sp.LightShip, Direction.Right);
            fild1.Shot(5,5,fild2.field);
            fild1.Shot(5, 5, fild2.field);





        }
        public void Battle() {

        }
    }
}
