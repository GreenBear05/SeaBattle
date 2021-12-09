using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SeaBattle {
    public class Battleground {
        Field fild1 = new Field();
        Field fild2 = new Field();
        public void Preparation() {
            var sp = new Ships();

            fild1.NewField(true);
            fild2.NewField(false);
            fild1.ShipLayout(5, 5, sp.LightShip, Direction.Right, true);
            fild2.ShipLayout(5, 5, sp.HShip, Direction.Right, false);
            
           


        }
        public void Battle() {
            while(true) {
                Console.CursorTop=11;
                Console.WriteLine("выстрел игрока1");
                fild1.Shot(fild2.field, true);
                Console.CursorTop=11;
                Console.WriteLine("выстрел игрока2");
                fild2.Shot(fild1.field, false);

            }

        }
    }

    public class WorkJson<T> {
        /// <summary>
        /// Серелизуюет любой обект или массив обектов в типе JSON
        /// </summary>
        string Path = @"D:\path.txt";
        public WorkJson(string path) {
            Path = path;
        }
        
        public void JsonWrite(T list) { 
            var Options = new JsonSerializerOptions() {
                WriteIndented = true,
            };
            var ser = JsonSerializer.Serialize(list,Options);
            File.WriteAllText(Path,ser);
        }

        public T JsonRead() {
            var file = File.ReadAllText(Path);
            var ser = JsonSerializer.Deserialize<T>(file);
            return ser;
        }
    }
}
