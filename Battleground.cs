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
            
            var ser = new WorkXml<Field>();
            ser.XmlWrite(fild1);
            //ser.XmlWrite(fild1);
            fild1 = ser.XmlRead();
            //  var ser = new WorkJson<Field>();


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
    public class WorkXml<T> {
        /// <summary>
        /// Серелизуюет любой обект или массив обектов в типе Xml
        /// </summary>
        string Path = @"D:\path.Xml";
        public WorkXml() { }
        public WorkXml(string path) {
            Path=path;
        }

        public void XmlWrite(T list) {
         
            using FileStream file = File.Create(Path);
            {
                var ser = new XmlSerializer(typeof(T));
                ser.Serialize(file, list);

            }
        }
        public T XmlRead() {
            using FileStream file = File.OpenRead(Path);
            {
                var ser = new XmlSerializer(typeof(T));
                 var data = ser.Deserialize(file);
                return (T)data;
            }

        }
    }
}
