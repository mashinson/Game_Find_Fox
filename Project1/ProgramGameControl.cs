using System;

namespace Project1
{
    public enum GameState
    {
        NoAction,
        Win,
        Lose,
        Hit,
        Miss,
        HitFirstCell
    }


    public struct ProgramGame
    {
        public static GameState stateOfGame = GameState.NoAction;
        public static bool showPeleng = false;
        public static int countOfFoxes; // Count of all Foxes
        public static int sizeOfTable; // Size of table
        public const int minSizeTable = 2;
        public const int maxSizeTable = 10;
        public const int minCountOfFoxs = 2;
        public static int start;

        /// <summary>
        /// User determines the size of the field and the number of foxes on it
        /// </summary>
        /// <returns>Program state</returns>
        public static ProgramSate GameSetUp(ref ViewTable view, ref Table playingField)
        {
            start = Environment.TickCount;
            showPeleng = false;
            bool ch = true;
            string s = "";
            bool bl;

            while (ch)
            {
                s = "";
                Console.Clear();
                Console.Write("Введите размер таблички (не меньше 2 и не больше 10): ");
                s = Console.ReadLine();
                bl = Int32.TryParse(s, out sizeOfTable);
                if (bl == false || sizeOfTable < minSizeTable || sizeOfTable > maxSizeTable)
                {
                    Console.Clear();
                    Console.WriteLine("Введите правильный размер табличики!!!");
                    Console.ReadLine();
                }
                else
                {
                    ch = false;
                }
            }

            ch = true;

            while (ch)
            {
                Console.Clear();
                Console.Write("Введите количество лис (не меньше 2 и не больше {0}): ", (sizeOfTable * sizeOfTable));
                s = Console.ReadLine();
                bl = Int32.TryParse(s, out countOfFoxes);
                if (bl == false || countOfFoxes < minCountOfFoxs || countOfFoxes > (sizeOfTable * sizeOfTable))
                {
                    Console.Clear();
                    Console.WriteLine("Введите правильное колиество лис!!!");
                    Console.ReadLine();
                }
                else
                {
                    ch = false;
                }

            }
            Console.Clear();
            view = new ViewTable(sizeOfTable);
            playingField = new Table(sizeOfTable, countOfFoxes);

            RandomArray(ref playingField);
            view.DrawField(playingField);


            playingField.MoveGameCursore(0, 0, view);
            return ProgramSate.Game;
        }

        /// <summary>
        /// Fills an array randomly by numbers 
        /// </summary>
        /// <param name="playingField">ProgramTable</param>
        public static void RandomArray(ref Table playingField)
        {
            int i, j;
            Random x = new Random();

            for (int w = 0; w < countOfFoxes; w++)
            {
                i = x.Next(0, sizeOfTable);
                j = x.Next(0, sizeOfTable);
                if ((i == 0) & (j == 0))
                {
                    j = +1;
                }
                playingField.Foxes[i, j].CounOfFoxes = playingField.Foxes[i, j].CounOfFoxes + 1;
            }

        }


        /// <summary>
        /// Game, move by table, shot ...
        /// </summary>
        /// <param name="strExit">Picture of Exit</param>
        /// <param name="strWinGame">Picture of  WinGame</param>
        /// <param name="pm">Program Menu</param>
        /// <param name="view">User Table</param>
        /// <param name="playingField">Program Table</param>
        /// <returns>Program state</returns>
        public static ProgramSate Game(string strExit, string strWinGame, ref ProgMenu pm, ref ViewTable view, ref MenuConsole mn, ref Table playingField)
        {
            ProgramSate ps = ProgramSate.Game;
            Action action;

            Console.CursorVisible = true;

            action = UserActions.GetUserAction();
            switch (action)
            {
                case Action.Left:
                    playingField.MoveGameCursore(-1, 0, view);
                    break;
                case Action.Right:
                    playingField.MoveGameCursore(1, 0, view);
                    break;
                case Action.Top:
                    playingField.MoveGameCursore(0, -1, view);
                    break;
                case Action.Bottom:
                    playingField.MoveGameCursore(0, 1, view);
                    break;
                case Action.Enter:
                    showPeleng = !showPeleng;
                    if (showPeleng)
                    {
                        Console.Clear();
                        view.DrawField(playingField);
                        Console.CursorVisible = false;
                        stateOfGame = playingField.EnterFoxes(view);
                        if (stateOfGame == GameState.Win || stateOfGame == GameState.Lose)
                        {
                            ps = ConsoleGame.WinGame(strWinGame, ref pm, ref mn, ref playingField, stateOfGame);
                        }
                        else
                        {
                            ConsoleGame.GameInfo(view, playingField, stateOfGame);
                            Console.CursorVisible = false;
                        }

                    }
                    else
                    {
                        Console.Clear();
                        view.DrawField(playingField);
                        playingField.MoveGameCursore(0, 0, view);
                        Console.CursorVisible = true;
                    }
                    break;
                case Action.Exit:
                    Console.WriteLine(strExit);
                    ps = GameExit(strExit, ref pm, ref mn, ref playingField, view);
                    break;
            }
            return ps;
        }

        /// <summary>
        /// Exit from game
        /// </summary>
        /// <param name="strExit">Picture of Exit</param>
        /// <param name="pm">Program Menu</param>
        /// <param name="mn">User Table</param>
        /// <param name="playingField">Program Table</param>
        /// <returns>Program state</returns>
        private static ProgramSate GameExit(string strExit, ref ProgMenu pm, ref MenuConsole mn, ref Table playingField, ViewTable view)
        {
            ProgramSate ps = ProgramSate.Game;
            Action action;
            Console.Clear();
            Console.WriteLine(strExit);
            pm.MoveYesNoExit(mn, 0);
            bool bl = true;
            while (bl)
            {
                action = UserActions.GetUserAction();
                switch (action)
                {
                    case Action.Left:
                        pm.MoveYesNoExit(mn, -1);
                        break;
                    case Action.Right:
                        pm.MoveYesNoExit(mn, 1);
                        break;
                    case Action.Enter:

                        if (pm.cursorYesNoExit == 0)
                        {
                            bl = false;
                            ps = ProgramSate.Menu;

                        }
                        else
                        {
                            bl = false;
                            Console.Clear();
                            view.DrawField(playingField);
                            showPeleng = false;
                            ps = ProgramSate.Game;
                        }
                        break;
                }
            }
            return ps;
        }

        /// <summary>
        /// Choose to begin a new game or to go to the menu
        /// </summary>
        /// <param name="pm">Program Menu</param>
        /// <param name="mn">User Table</param>
        /// <param name="playingField">Program Table</param>
        /// <returns>Program state</returns>
        public static ProgramSate GameWinMoveYesNo(ref ProgMenu pm, ref MenuConsole mn, ref Table playingField)
        {
            ProgramSate ps = ProgramSate.Game;
            Action action;
            bool ch = true;
            while (ch)
            {
                action = UserActions.GetUserAction();
                switch (action)
                {
                    case Action.Left:
                        pm.MoveYesNo(mn, -1);
                        break;
                    case Action.Right:
                        pm.MoveYesNo(mn, 1);
                        break;
                    case Action.Enter:
                        ch = false;
                        if (pm.cursorYesNo == 0)
                        {
                            ps = ProgramSate.GameSetUp;
                        }
                        else
                        {
                            ps = ProgramSate.Menu;
                        }
                        break;
                }
            }
            return ps;
        }
    }
}
