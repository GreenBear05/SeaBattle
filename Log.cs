using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle {
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
            Console.Write(wri);
            Console.CursorLeft = left;
            Console.CursorTop = top;
        }
        public static void WriteStat(string wri) {
            var left = Console.CursorLeft;
            var top = Console.CursorTop;
            Console.CursorLeft = 90;
            Console.CursorTop = 0;
            Console.WriteLine(wri);
            Console.CursorLeft = left;
            Console.CursorTop = top;
        }
    }
}