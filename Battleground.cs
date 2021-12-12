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
       public Field fild1 = new(true);
       public Field fild2 = new(false);
        public void Preparation() {
            Console.WriteLine("Информация\n  Условное обозначение: # корабль \n * неизвесная теретория\n ~ промах\n Х попадение или уничтожение ");
            Console.ReadKey();
            Console.Clear();
            var sp = new Ships();
            Statistics stat1 = new Statistics(fild1);
            // Statistics stat2 = new Statistics(fild2);
            while(true) {
                fild1.ShipLayout(sp.Destroyer, Direction.Right, true);
                fild1.ShipLayout(sp.LightShip, Direction.Right, true);
            }
            
            fild2.ShipLayout( sp.HShip, Direction.Right, false);
            


        }
        public void Battle() {
            while(true) {
                Console.CursorTop=11;
                Console.WriteLine("выстрел игрока1");
                fild1.Shot(fild2.FieldMat, true);
                Console.CursorTop=11;
                Console.WriteLine("выстрел игрока2");
                fild2.Shot(fild1.FieldMat, false);
                
            }

        }
    }

    //public class WorkJson<T> {
    //    /// <summary>
    //    /// Серелизуюет любой обект или массив обектов в типе JSON
    //    /// </summary>
    //    string Path = @"D:\path.txt";
    //    public WorkJson() {
           
    //    }
    //    public WorkJson(string path) {
    //        Path = path;
    //    }
        
    //    public void JsonWrite(T list) {
    //        var l = list as ISerializer; 
    //        if(l != null) {

    //            var Options = new JsonSerializerOptions() {
    //                WriteIndented = true,
    //            };
    //            var ser = JsonSerializer.Serialize(l.Write(), Options);
    //            File.WriteAllText(Path, ser);
    //        }
    //    }

    //    public void JsonRead(T list) {
    //        var l = list as ISerializer;
    //        if(l != null) {
    //            var file = File.ReadAllText(Path);
    //            l.Read(file);
                
    //        }
            

    //    }
    //}
}
