using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle {
    public class Field {
        string[,] field = new string[11, 11];
        public void NewField() {
            
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
            FieldCutting();
        }
        public void FieldCutting() {
            Console.Clear();
            for(int i = 0; i < field.GetLength(1); i++) {
                for(int j = 0; j < field.GetLength(0); j++) {
                    Console.Write(field[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        public void ShipLayout(int up,int bottom,string ships,Direction direction) {
            for(int i = up; i < up + ships.Length; i++) {
                if((direction == Direction.Z) || (direction == Direction.Bottom)) {
                    field[i, bottom] = "L";
                } else {
                    field[bottom, i] = "L";
                }
                    
                
            }
            FieldCutting();
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
        Bottom = 0
    }
}
