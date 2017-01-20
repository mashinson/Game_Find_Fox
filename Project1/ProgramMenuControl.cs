using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public struct MenuControl
    {

        /// <summary>
        /// Move by Menu
        /// </summary>
        /// <param name="mn">User Table</param>
        /// <param name="playingField">Program Table</param>
        /// <returns>Program state</returns>
        public static ProgramSate Menu(string strMenu, ref ProgMenu pm, ref MenuConsole mn, ref Table playingField)
        {
            Console.Clear();
            Console.Write(strMenu); // draw menu
            ProgramSate ps = ProgramSate.Menu;
            Console.CursorVisible = false;

            Action action;
            pm.MoveMenu(mn, 0);

            action = UserActions.GetUserAction();
            switch (action)
            {
                case Action.Bottom:
                    pm.MoveMenu(mn, 1);
                    break;
                case Action.Top:
                    pm.MoveMenu(mn, -1);
                    break;
                case Action.Enter:
                    switch (pm.cursorMenu)
                    {
                        case 0:
                            ps = ProgramSate.GameSetUp;
                            break;
                        case 1:
                            ps = ProgramSate.Reference;
                            break;
                        case 2:
                            ps = ProgramSate.Exit;
                            break;

                    }
                    break;
            }
            Console.CursorVisible = true;
            return ps;
        }
    }
}
