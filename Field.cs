using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle {
    public class Field {
        public string[,] field { get; private set; }
        string[] MarkupFilde = new string[11] { "0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
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
            Console.Clear();
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
                Console.WriteLine("Введите координаты пример 5J");
                var coord = Console.ReadLine();
                coorMarkupFild = MarkupFilde.IndxValue<string>(coord[1].ToString().ToUpper());
                coordinates = Convert.ToInt32(coord[0].ToString());

            
            
            if(fieldWang[coorMarkupFild, coordinates] == "~" || fieldWang[coorMarkupFild, coordinates] == "X") {
                Console.WriteLine("Вы уже стреляли туда выберите другое место");
                Logs($"Выстрел по координатам {coordinates} {MarkupFilde[coorMarkupFild]} результат {fieldwang[coorMarkupFild, coordinates]}");
            } else {
                switch(fieldwang[coorMarkupFild, coordinates]) {
                    case "*":
                    Logs($"Выстрел по координатам {coordinates} {MarkupFilde[coorMarkupFild]} результат {fieldwang[coorMarkupFild, coordinates]} мимо");
                    fieldWang[coorMarkupFild, coordinates] = "~";
                    break;
                    case "#":
                    Logs($"Выстрел по координатам {coordinates} {MarkupFilde[coorMarkupFild]} результат {fieldwang[coorMarkupFild, coordinates]}");
                    fieldwang[coorMarkupFild, coordinates] = "X";
                    fieldWang[coorMarkupFild, coordinates] = "X";
                    break;
                    default:
                    Console.WriteLine("Ведите нормальные координаты");
                    break;
                }
            }
            }
            catch(Exception) {

                Console.WriteLine("введите кородинаты верно");
            }
            //if(fieldWang[coorMarkupFild, coordinates] == "~" || fieldWang[coorMarkupFild, coordinates] == "X") {
            //    Console.WriteLine("Вы уже стреляли туда выберите вругое место");
            //    Logs($"Выстрел по координатам {coordinates} {MarkupFilde[coorMarkupFild]} результат {fieldwang[coorMarkupFild, coordinates]}");
            //} else {
            //    if(fieldwang[coorMarkupFild, coordinates] != "*") {
            //        Logs($"Выстрел по координатам {coordinates} {MarkupFilde[coorMarkupFild]} результат {fieldwang[coorMarkupFild, coordinates]}");
            //        fieldwang[coorMarkupFild, coordinates] = "X";
            //        fieldWang[coorMarkupFild, coordinates] = "X";
            //    } else {
            //        fieldWang[coorMarkupFild, coordinates] = "~";
            //        Logs($"Выстрел по координатам {coordinates} {MarkupFilde[coorMarkupFild]} результат {fieldWang[coorMarkupFild, coordinates]}");
            //    }
            //}
            Console.Clear();
            if(fieldCutting) {
                FieldCutting();
            }
            

        }
        int logint = 0;
        void Logs(string log) {
            Console.CursorLeft = 60;
            Console.CursorTop = logint;
            Console.WriteLine(log);
            Console.CursorLeft = 0;
            Console.CursorTop = 12;

            logint++;
        }
    }
    public enum Direction {
        X = 1,
        Z = 0,
        Right = 1,
        Bottom = 0,
    }
    public static class Indx {
        public static int IndxValue<T>(this IEnumerable<string> col, string text) {
            int ind = 0;
            foreach(var item in col) {
                if(item != text) {
                    ind++;

                } else {

                    break;
                }
            }
            return ind;
        }
    }
}
