using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
   public  struct MenuConsole
    {
        /// <summary>
        /// Menu items
        /// </summary>
        public void ConsoleMenu()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(5, 8);
            Console.WriteLine(" Начать Игру ");

            Console.SetCursorPosition(5, 10);
            Console.WriteLine("   Справка   ");

            Console.SetCursorPosition(5, 12);
            Console.WriteLine("    Выход    ");
            Console.ResetColor();
        }

        /// <summary>
        /// Select menu items 
        /// </summary>
        /// <param name="mn">a number of menu item that was select</param>
        public void SelectItemMenu(Menu mn)
        {
            ConsoleMenu();
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;
            switch (mn)
            {
                case Menu.Game:
                    Console.SetCursorPosition(5, 8);
                    Console.WriteLine(" Начать Игру ");

                    break;
                case Menu.Reference:
                    Console.SetCursorPosition(5, 10);
                    Console.WriteLine("   Справка   ");
                    break;
                case Menu.Exit:
                    Console.SetCursorPosition(5, 12);
                    Console.WriteLine("    Выход    ");
                    break;
            }
            Console.ResetColor();
        }

        /// <summary>
        /// Console Yes/No
        /// </summary>
        /// <param name="x">Cursor Position by horizontals</param>
        /// <param name="y">Cursor Position in the vertical</param>
        public void ConsoleYesNo(int x, int y)
        {

            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.SetCursorPosition(x, y);
            Console.WriteLine(" Да ");

            Console.SetCursorPosition(x + 16, y);
            Console.WriteLine(" Нет ");

            Console.ResetColor();
        }


        /// <summary>
        /// Select Yes or No
        /// </summary>
        /// <param name="ch">What user choose</param>
        /// <param name="x">Cursor Position by horizontals</param>
        /// <param name="y">Cursor Position in the vertical</param>
        public void SelectYesNo(YesNo ch, int x, int y)
        {
            ConsoleYesNo(x, y);
            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Black;

            switch (ch)
            {
                case YesNo.Yes:
                    Console.SetCursorPosition(x, y);
                    Console.WriteLine(" Да ");
                    break;
                case YesNo.No:
                    Console.SetCursorPosition(x + 16, y);
                    Console.WriteLine(" Нет ");
                    break;
            }
            Console.ResetColor();
        }



    }
}
