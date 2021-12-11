using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace SeaBattle {
    public class Field{
        public event Action<StatisticsEventEnum> StatisticsEvent;
        public string[,] field { get; private set; }
        IList<string> MarkupFilde = new string[11] { "0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        string[,] fieldWang;

       public Field(bool fieldCutting) {
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
        public void ShipLayout(string ships, Direction direction, bool fieldCutting) {
            int coordinates = 0;
            int coorMarkupFild = 0;
            bool sost = true;
            Log.Write("Введите координаты пример 5J чтобы разместить корабль");
            Console.CursorTop = 13;
            var coord = Console.ReadLine();
            coorMarkupFild = MarkupFilde.IndexOf(coord[1].ToString().ToUpper());
            coordinates = Convert.ToInt32(coord[0].ToString());
            var mini = coorMarkupFild - 1;
            var minj = coordinates - 1;
            var maxi = coorMarkupFild + 1;
            var maxj = coordinates + ships.Length;
            for(int i = mini; i < maxi; i++) {
                for(int j = minj; j < maxj; j++) {
                    if(field[i, j].Contains("#")) {
                        var a = false;
                        break;
                    }
                }
            }


            if(sost) {

                for(int i = coordinates; i < coordinates + ships.Length; i++) {

                    if((direction == Direction.Z) || (direction == Direction.Bottom)) {
                        field[i, coorMarkupFild] = ships[i - coordinates].ToString();
                    } else {
                        field[coorMarkupFild, i] = ships[i - coordinates].ToString();
                    }
                }
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
                        StatisticsEvent?.Invoke(StatisticsEventEnum.slips);
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
                        StatisticsEvent?.Invoke(StatisticsEventEnum.hitting);
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
            bool victory = false;
            foreach(var item in fieldwang) {
                if(item.Contains("#")) {
                    victory = true;
                    break; 
                }
            }
            
            if(fieldCutting) {
                FieldCutting();
            } else {
                Console.CursorTop = 0;
                Console.CursorLeft = 0;
                for(int i = 0; i < field.GetLength(1); i++) {
                    for(int j = 0; j < fieldwang.GetLength(0); j++) {
                        Console.Write(fieldwang[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.CursorTop = 0;
                Console.CursorLeft = 30;
            }
        }
    }
   
    
    public enum Direction {
        X = 1,
        Z = 0,
        Right = 1,
        Bottom = 0,
    }

}
public enum StatisticsEventEnum {
    hitting,
    slips
}
