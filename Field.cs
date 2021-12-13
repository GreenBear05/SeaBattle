using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace SeaBattle {
    public class Field{
        public event Action<StatisticsEventEnum> StatisticsEvent;
        public string[,] FieldMat { get; private set; }
        private IList<string> MarkupFilde = new string[11] { "0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J" };
        private string[,] fieldWang;

       public Field(bool fieldCutting) {
            FieldMat = new string[11, 11];
            fieldWang = new string[11, 11];
            for(int i = 0; i < FieldMat.GetLength(1); i++) {
                FieldMat[0, i] = $"{i}";
                FieldMat[i, 0] = $"{MarkupFilde[i]}";
            }
            for(int i = 1; i < FieldMat.GetLength(1); i++) {
                for(int j = 1; j < FieldMat.GetLength(0); j++) {
                    FieldMat[i, j] = "*";
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
            for(int i = 0; i < FieldMat.GetLength(1); i++) {
                for(int j = 0; j < FieldMat.GetLength(0); j++) {
                    Console.Write(FieldMat[i, j] + " ");
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
            try {
                //Random r1 = new Random();
                //Random r2 = new Random();
                //int coordNumerical = r1.Next(1, 10);
                //int coordMarkupFild = r2.Next(1, 10);
                int coordNumerical = y;
                int coordMarkupFild = x;
                bool condition = true;
                Log.Write("Введите координаты пример 5J чтобы разместить корабль");
                Console.CursorTop = 13;
                //var coordinates = Console.ReadLine();

                //foreach(var item in MarkupFilde) {
                //    var charbool = coordinates.EndsWith(item.ToLower());
                //    if(charbool) {
                //        coordMarkupFild = MarkupFilde.IndexOf(item);
                //        coordNumerical = Convert.ToInt32(coordinates.Substring(startIndex: 0, coordinates.Length - 1));
                //        break;
                //    }
                //}

                //проверка теретории границ чтобы поставить кораболь
                int increaseinspectionarea = 1;
                var minj = coordMarkupFild - increaseinspectionarea;
                var maxj = coordMarkupFild;
                var mini = coordNumerical - increaseinspectionarea;
                var maxi = coordNumerical + ships.Length;
                if(!(coordMarkupFild >= 10)) {
                    maxj += increaseinspectionarea;
                }
                if((coordNumerical > 10 - ships.Length )) {
                    maxi -= increaseinspectionarea;
                } 

                for(int i = mini; i <= maxi; i++) {
                    for(int j = minj; j <= maxj; j++) {
                        FieldMat[j, i] = "&";
                        if(FieldMat[j, i].Contains("#")) {
                            condition = false;
                            break;
                        }
                    }
                }

                // TODO - всратый костыль нужно обязательно решить .
                if( coordNumerical + ships.Length >= 12) {
                    condition = false;
                }

                //ставит кораболь по рпзмещенным координатам
                if(condition) {
                    for(int i = coordNumerical; i < coordNumerical + ships.Length; i++) {

                        if((direction == Direction.Z) || (direction == Direction.Bottom)) {
                            FieldMat[i, coordMarkupFild] = ships[i - coordNumerical].ToString();
                        } else {
                            FieldMat[coordMarkupFild, i] = ships[i - coordNumerical].ToString();
                        }
                    }
                } else {
                    Log.WriteEror("выберете другое место");
                    ShipLayout(x,y,ships, direction, fieldCutting);
                }
            }
            catch(Exception) {
                Log.WriteEror("введите кородинаты верно");
                ShipLayout(x, y, ships, direction, fieldCutting);
            }
            if(fieldCutting) {
                FieldCutting();

            }
        }
        public void Shot(string[,] fieldwang, bool fieldCutting) {

            int coordNumerical = 0;
            int coordMarkupFild = 0;
            try {
                Log.Write("Введите координаты пример 5J");
                Console.CursorTop = 13;
                var coordinates = Console.ReadLine();
                foreach(var item in MarkupFilde) {
                    var charbool = coordinates.EndsWith(item.ToLower());
                    if(charbool) {
                        coordMarkupFild = MarkupFilde.IndexOf(item);
                        coordNumerical = Convert.ToInt32(coordinates.Substring(startIndex: 0, coordinates.Length - 1));
                        break;
                    }
                }

                switch(fieldwang[coordMarkupFild, coordNumerical]) {
                    case "*":
                        Log.LogsWrite($"Выстрел по координатам {coordNumerical} {MarkupFilde[coordMarkupFild]} результат {fieldwang[coordMarkupFild, coordNumerical]} мимо");
                        fieldWang[coordMarkupFild, coordNumerical] = "~";
                        StatisticsEvent?.Invoke(StatisticsEventEnum.slips);
                        break;
                    case "~":
                        Log.WriteEror("Вы уже стреляли туда выберите другое место");
                        Log.LogsWrite($"Выстрел по координатам {coordNumerical} {MarkupFilde[coordMarkupFild]} результат {fieldwang[coordMarkupFild, coordNumerical]}");
                        Shot( fieldwang, fieldCutting);
                        break;
                    case "#":
                        Log.LogsWrite($"Выстрел по координатам {coordNumerical} {MarkupFilde[coordMarkupFild]} результат {fieldwang[coordMarkupFild, coordNumerical]}");
                        fieldwang[coordMarkupFild, coordNumerical] = "X";
                        fieldWang[coordMarkupFild, coordNumerical] = "X";
                        StatisticsEvent?.Invoke(StatisticsEventEnum.hitting);
                        break;
                    case "X":
                        Log.WriteEror("Вы уже стреляли туда выберите другое место");
                        Log.LogsWrite($"Выстрел по координатам {coordNumerical} {MarkupFilde[coordMarkupFild]} результат {fieldwang[coordMarkupFild, coordNumerical]}");
                        Shot( fieldwang, fieldCutting);
                        break;
                    default:
                        Log.WriteEror("Ведите нормальные координаты");
                        Shot( fieldwang, fieldCutting);
                        break;
                }

            }
            catch(Exception) {
                Log.WriteEror("введите кородинаты верно");
                Shot( fieldwang, fieldCutting);
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
                for(int i = 0; i < FieldMat.GetLength(1); i++) {
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
