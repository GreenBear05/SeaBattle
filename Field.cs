using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SeaBattle {
    public class Field : IXmlSerializable {
        
        public string[,] field { get; private set; }
        IList<string> MarkupFilde = new string[11] { "0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        string[,] fieldWang;

        public void NewField(bool fieldCutting) {
            field = new string[11, 11];
            fieldWang = new string[11, 11];
            for(int i = 0; i < field.GetLength(1); i++) {
                field[0, i] = $"{i}";
                field[i, 0] = $"{MarkupFilde[i]}";
            }
            for(int i = 1; i < field.GetLength(1); i++) {
                for(int j = 1; j < field.GetLength(0); j++) {
                    field[i, j] = "*";
                }
            }
            //инцелезация fieldWang
            for(int i = 0; i < fieldWang.GetLength(1); i++) {
                fieldWang[0, i] = $"{i}";
                fieldWang[i, 0] = $"{MarkupFilde[i]}";
            }
            for(int i = 1; i < fieldWang.GetLength(1); i++) {
                for(int j = 1; j < fieldWang.GetLength(0); j++) {
                    fieldWang[i, j] = "*";
                }
            }


            if(fieldCutting) {
                FieldCutting();
            }

        }
        private void FieldCutting() {

            Console.CursorTop = 0;
            Console.CursorLeft = 0;
            for(int i = 0; i < field.GetLength(1); i++) {
                for(int j = 0; j < field.GetLength(0); j++) {
                    Console.Write(field[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.CursorTop = 0;
            Console.CursorLeft = 30;

            for(int i = 0; i < fieldWang.GetLength(1); i++) {
                for(int j = 0; j < fieldWang.GetLength(0); j++) {
                    Console.Write(fieldWang[i, j] + " ");

                }

                Console.WriteLine();
                Console.CursorLeft = 30;

            }
            Console.CursorLeft = 0;

        }
        public void ShipLayout(int x, int y, string ships, Direction direction, bool fieldCutting) {
            int j = 0;
            for(int i = x; i < x + ships.Length; i++) {
                if((direction == Direction.Z) || (direction == Direction.Bottom)) {
                    field[i, y] = ships[j].ToString();
                } else {
                    field[y, i] = ships[j].ToString();
                }
                j++;
            }
            if(fieldCutting) {
                FieldCutting();
            }

        }
        public void Shot(string[,] fieldwang, bool fieldCutting) {

            int coordinates = 0;
            int coorMarkupFild = 0;
            try {
                Log.Write("Введите координаты пример 5J");
                Console.CursorTop = 13;
                var coord = Console.ReadLine();
                coorMarkupFild = MarkupFilde.IndexOf(coord[1].ToString().ToUpper());

                coordinates = Convert.ToInt32(coord[0].ToString());

                switch(fieldwang[coorMarkupFild, coordinates]) {
                    case "*":
                        Log.LogsWrite($"Выстрел по координатам {coordinates} {MarkupFilde[coorMarkupFild]} результат {fieldwang[coorMarkupFild, coordinates]} мимо");
                        fieldWang[coorMarkupFild, coordinates] = "~";
                        break;
                    case "~":
                        Log.WriteEror("Вы уже стреляли туда выберите другое место");
                        Log.LogsWrite($"Выстрел по координатам {coordinates} {MarkupFilde[coorMarkupFild]} результат {fieldwang[coorMarkupFild, coordinates]}");
                        Shot(fieldwang, fieldCutting);
                        break;
                    case "#":
                        Log.LogsWrite($"Выстрел по координатам {coordinates} {MarkupFilde[coorMarkupFild]} результат {fieldwang[coorMarkupFild, coordinates]}");
                        fieldwang[coorMarkupFild, coordinates] = "X";
                        fieldWang[coorMarkupFild, coordinates] = "X";
                        break;
                    case "X":
                        Log.WriteEror("Вы уже стреляли туда выберите другое место");
                        Log.LogsWrite($"Выстрел по координатам {coordinates} {MarkupFilde[coorMarkupFild]} результат {fieldwang[coorMarkupFild, coordinates]}");
                        Shot(fieldwang, fieldCutting);
                        break;
                    default:
                        Log.WriteEror("Ведите нормальные координаты");
                        Shot(fieldwang, fieldCutting);
                        break;
                }

            }
            catch(Exception) {

                Log.WriteEror("введите кородинаты верно");
                Shot(fieldwang, fieldCutting);
            }

            if(fieldCutting) {
                FieldCutting();
            }
        }

        public XmlSchema GetSchema() {
            return (null);
        }
        
       
        public void ReadXml(XmlReader reader) {
            XmlSerializerNamespaces xml = new XmlSerializerNamespaces();
           // xml.
            field = new string[11, 11];
            fieldWang = new string[11, 11];
            for(int i = 1; i < fieldWang.GetLength(1); i++) {
                for(int j = 1; j < fieldWang.GetLength(0); j++) {
                    field[i, j] = reader.ReadElementContentAsString("field", "https://docs.microsoft.com/ru-ru/dotnet/api/system.xml.xmlreader.readelementcontentasboolean?view=net-6.0#System_Xml_XmlReader_ReadElementContentAsBoolean_System_String_System_String_");
                }
            }



        }

        public void WriteXml(XmlWriter writer) {
            
            foreach(var item in field) {
                // writer.WriteString(item);
                writer.WriteElementString("field",item);
               
                
            }

            //foreach(var item in fieldWang) {
            //    // writer.WriteString(item);
            //    writer.WriteAttributeString("fieldWang", item);

            //}

        }
    }
    public static class Log {
        static int logint = 0;
        static int Errorlog = 11;
        public static void LogsWrite(string log) {
            var left = Console.CursorLeft;
            var top = Console.CursorTop;
            Console.CursorLeft = 60;
            Console.CursorTop = logint;
            Console.Write(log);
            Console.CursorLeft = left;
            Console.CursorTop = top;
            logint++;
        }
        public static void WriteEror(string wri) {
            var left = Console.CursorLeft;
            var top = Console.CursorTop;
            Console.CursorLeft = 30;
            Console.CursorTop = Errorlog;
            Console.WriteLine(wri);
            Console.CursorLeft = left;
            Console.CursorTop = top;
        }
        public static void Write(string wri) {
            var left = Console.CursorLeft;
            var top = Console.CursorTop;
            Console.CursorLeft = 0;
            Console.CursorTop = 12;
            Console.Write("");
            Console.WriteLine(wri);
            Console.CursorLeft = left;
            Console.CursorTop = top;
        }
    }
    public enum Direction {
        X = 1,
        Z = 0,
        Right = 1,
        Bottom = 0,
    }

}
