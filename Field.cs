using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle {
    public class Field {
        public string[,] field { get; private set; }
        string[,] fieldWang;
        public void NewField(bool fieldCutting) {
            field = new string[11, 11];
            fieldWang = new string[11, 11];
            for(int i = 0; i < field.GetLength(1); i++) {
                field[0, i] = $"{i}";
                field[i, 0] = $"{(MarkupFilde)i}";
                for(int j = 0; j < field.GetLength(0); j++) {
                }
            }
            for(int i = 1; i < field.GetLength(1); i++) {
                for(int j = 1; j < field.GetLength(0); j++) {
                    field[i, j] = "*";
                }
            }
            for(int i = 0; i < fieldWang.GetLength(1); i++) {
                fieldWang[0, i] = $"{i}";
                fieldWang[i, 0] = $"{(MarkupFilde)i}";
                for(int j = 0; j < fieldWang.GetLength(0); j++) {
                }
            }
            for(int i = 1; i < fieldWang.GetLength(1); i++) {
                for(int j = 1; j < fieldWang.GetLength(0); j++) {
                    fieldWang[i, j] = "*";
                }
            }
            //инцелезация fieldWang

            if(fieldCutting) {
                FieldCutting();
            }
            
        }
        void FieldCutting() {
            
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
        public void ShipLayout(int x,int y,string ships,Direction direction) {
            for(int i = x; i < x + ships.Length; i++) {
                if((direction == Direction.Z) || (direction == Direction.Bottom)) {
                    field[i, y] = "L";
                } else {
                    field[y, i] = "L";
                }
            }
            FieldCutting();
        }
        public void Shot(int x,int y,string[,] fieldwang) {
            if(fieldWang[x, y] == "~" || fieldWang[x, y] == "X") {
                Console.WriteLine("Вы уже стреляли туда выберите вругое место");
                Logs($"Выстрел по координатам {x} {(MarkupFilde)y} результат {fieldwang[x, y]}");
            } else {
                if(fieldwang[x, y] != "*") {
                    Logs($"Выстрел по координатам {x} {(MarkupFilde)y} результат {fieldwang[x, y]}");
                    fieldwang[x, y] = "X";
                    fieldWang[x, y] = "X";
                } else {
                    fieldWang[x, y] = "~";
                }
            }
            FieldCutting();
            
           

        }
        int logint = 0;
        void Logs(string log) {
            Console.CursorLeft = 60;
            Console.CursorTop = logint;
            Console.WriteLine(log);
            Console.CursorLeft = 0;
            Console.CursorTop = 11;
            logint++;
        } 
    }
    enum MarkupFilde {
        A = 1,
        B = 2,
        C = 3,
        D = 4,
        E = 5,
        F = 6,
        G = 7,
        H = 8,
        I = 9,
        J = 10,
    }
    public enum Direction {
        X = 1,
        Z = 0,
        Right = 1,
        Bottom = 0,
    }
}
