using System;

namespace Project1
{
    class UserTable
    {
        public const int startRow = 3;
    }


    public struct ViewTable
    {
        public int size;      // Size of the table   


        public ViewTable(int Size)
        {
            this.size = Size;
        }

        /// <summary>
        /// Move cursor by table depending of UserAction 
        /// </summary>
        /// <param name="cursorX">target cell coordinate by horizontals</param>
        /// <param name="cursorY">target cell coordinate in the vertical</param>
        public void CursorPosition(int cursorX, int cursorY)
        {
            Console.SetCursorPosition((Console.WindowWidth / 2 - size * 2) + 2 + 4 * cursorX, UserTable.startRow + cursorY * 2);
        }
        
        /// <summary>
        /// Formula сonverts ordinary coordinates in view coordinates
        /// </summary>
        /// <param name="row">target cell coordinate by horizontals</param>
        /// <param name="column">target cell coordinate in the vertical</param>
        private void SetTableCursorPosition(int row, int column)
        {
            Console.SetCursorPosition((Console.WindowWidth / 2 - size * 2) + 1 + 4 * column, UserTable.startRow + row * 2);
        }

        /// <summary>
        /// Draw a table 
        /// </summary>
        /// <param name="tb">Program table</param>
        public void DrawField(Table tb)
        {
            //Console.ResetColor();
            int currentRow = UserTable.startRow; // line which is drawn now

            //С помощью метода SetCursorPosition указывается, где должна начаться следующая операция записи в окно консоли.
            //Если заданная позиция курсора находится вне области, которая в данный момент видима в окне консоли, начало координат этого окна автоматически изменяется, чтобы курсор стал видимым.
            Console.SetCursorPosition(Console.WindowWidth / 2 - size * 2, currentRow - 1);

            //Draw the "zero" line by horizontals
            for (int k = 0; k < size; k++)
            {
                Console.Write("+---");
            }
            Console.WriteLine("+");

            //Draw table
            for (int i = 0; i < size; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - size * 2, currentRow);
                currentRow++;

                // Draw the edge of the table in the vertical
                Console.Write("|");
                for (int j = 0; j < size; j++)
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.Black;
                    if (tb.Foxes[j, i].FindFoxs == ShotInCell.Find)
                    {
                        Console.Write(" V ");
                    }
                    if (tb.Foxes[j, i].FindFoxs == ShotInCell.NotFind)
                    {
                        Console.Write(" X ");
                    }
                    if (tb.Foxes[j, i].FindFoxs == ShotInCell.NoAction)
                    {
                        Console.Write("   ");
                    }
                    Console.ResetColor();
                    Console.Write("|");

                }

                Console.SetCursorPosition(Console.WindowWidth / 2 - size * 2, currentRow);
                currentRow++;

                //Draw the edge of the table by horizontals
                for (int k = 0; k < size; k++)
                {
                    Console.Write("+---");
                }
                Console.WriteLine("+");

            }
            //Console.BackgroundColor = ConsoleColor.Green;
            //Console.ForegroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// View the peeling of the point
        /// </summary>
        /// <param name="targetRow">target cell coordinate by horizontals</param>
        /// <param name="targetColumn">target cell coordinate in the vertical</param>
        public void Peleng(int targetRow, int targetColumn, Table tb)
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < size; i++)
            {
                SetTableCursorPosition(targetRow, i);
                if (tb.Foxes[i, tb.cursorY].FindFoxs == ShotInCell.Find)
                {
                    Console.Write(" V ");
                }
                if (tb.Foxes[i, tb.cursorY].FindFoxs == ShotInCell.NotFind)
                {
                    Console.Write(" X ");
                }
                if (tb.Foxes[i, tb.cursorY].FindFoxs == ShotInCell.NoAction)
                {
                    Console.Write("   ");
                }

            }

            for (int i = 0; i < size; i++)
            {
                SetTableCursorPosition(i, targetColumn);
                if (tb.Foxes[tb.cursorX, i].FindFoxs == ShotInCell.Find)
                {
                    Console.Write(" V ");
                }
                if (tb.Foxes[tb.cursorX, i].FindFoxs == ShotInCell.NotFind)
                {
                    Console.Write(" X ");
                }
                if (tb.Foxes[tb.cursorX, i].FindFoxs == ShotInCell.NoAction)
                {
                    Console.Write("   ");
                }

            }

            Console.BackgroundColor = ConsoleColor.Red;
            SetTableCursorPosition(targetRow, targetColumn);
            if (tb.Foxes[tb.cursorX, tb.cursorY].FindFoxs == ShotInCell.Find)
            {
                Console.Write(" V ");
            }
            if (tb.Foxes[tb.cursorX, tb.cursorY].FindFoxs == ShotInCell.NotFind)
            {
                Console.Write(" X ");
            }
            if (tb.Foxes[tb.cursorX, tb.cursorY].FindFoxs == ShotInCell.NoAction)
            {
                Console.Write("   ");
            }

            Console.ResetColor();
        }




    }
}