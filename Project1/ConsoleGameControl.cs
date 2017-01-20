using System;

namespace Project1
{

    public struct ConsoleGame
    {

        /// <summary>
        ///  Show if user find/don't find foxes, countFindFoxes, count of shots, pelling ...
        /// </summary>
        /// <param name="view">User Table</param>
        /// <param name="playingField">Program Table</param>
        /// <param name="stateOfGame">stateOfGame = 0 - don`t find Foxes, stateOfGame = 1 - find Foxes, stateOfGame = -1 - shot in first cell, stateOfGame = 2 - user win </param>
        /// <param name="start">start = Environment.TickCount;</param>
        public static void GameInfo(ViewTable view, Table playingField, GameState stateOfGame)
        {
            switch (stateOfGame)
            {
                case GameState.HitFirstCell:
                    Console.SetCursorPosition(0, 7 + 2 * view.size);
                    Console.WriteLine("Здесь находитесь ВЫ. Введите другую клеточку.");

                    Console.SetCursorPosition(0, 8 + 2 * view.size);
                    Console.Write("Количество выстрелов осталось: {0}", playingField.shots);
                    break;
                case GameState.Miss:
                    Console.SetCursorPosition(0, 7 + 2 * view.size);
                    Console.Write("Вы не попали:((((");

                    Console.SetCursorPosition(0, 8 + 2 * view.size);
                    Console.Write("Количество лис по пеллингу: {0}", playingField.countPellingFoxes);

                    Console.SetCursorPosition(0, 9 + 2 * view.size);
                    Console.Write("Количество всего найденных лис: {0}", playingField.countFindFoxes);

                    Console.SetCursorPosition(0, 10 + 2 * view.size);
                    Console.Write("Количество лис, которых нужно найти: {0}", playingField.leftFoxes);

                    Console.SetCursorPosition(0, 11 + 2 * view.size);
                    Console.Write("Количество выстрелов осталось: {0}", playingField.shots);

                    break;
                case GameState.Hit:
                    Console.SetCursorPosition(0, 7 + 2 * view.size);
                    Console.Write("Вы попали!!!");

                    Console.SetCursorPosition(0, 8 + 2 * view.size);
                    Console.WriteLine("Количество найденных лис: {0}", playingField.findNowFoxes);

                    Console.SetCursorPosition(0, 9 + 2 * view.size);
                    Console.Write("Количество лис по пеллингу: {0}", playingField.countPellingFoxes);

                    Console.SetCursorPosition(0, 10 + 2 * view.size);
                    Console.Write("Количество всего найденных лис: {0}", playingField.countFindFoxes);

                    Console.SetCursorPosition(0, 11 + 2 * view.size);
                    Console.Write("Количество лис, которых нужно найти: {0}", playingField.leftFoxes);

                    Console.SetCursorPosition(0, 12 + 2 * view.size);
                    Console.Write("Количество выстрелов осталось: {0}", playingField.shots);
                    break;

            }
        }

        /// <summary>
        /// If user wins game
        /// </summary>
        /// <param name="strWin">Picture of win game</param>
        /// <param name="pm">Program menu</param>
        /// <param name="mn">User Table</param>
        /// <param name="playingField">Program Table</param>
        /// <returns>Program state</returns>
        public static ProgramSate WinGame(string strWin, ref ProgMenu pm, ref MenuConsole mn, ref Table playingField, GameState stateOfGame)
        {
            ProgramSate ps = ProgramSate.Game;
            Console.Clear();
            Console.Write(strWin);

            if (stateOfGame == GameState.Win)
            {
                Console.SetCursorPosition(20, 10);
                Console.WriteLine(" Поздравляю, вы победили! ");

            }
            if (stateOfGame == GameState.Lose)
            {
                Console.SetCursorPosition(24, 10);
                Console.WriteLine(" Вы проиграли! ");
            }
            pm.MoveYesNo(mn, 0);
            Console.SetCursorPosition(38, 12);

            Console.WriteLine(playingField.countShots);

            int time = (Environment.TickCount - ProgramGame.start) / 1000;
            int timeMin = time / 60;
            int timeSec = time % 60;
            Console.SetCursorPosition(34, 15);
            Console.WriteLine(timeMin);
            Console.SetCursorPosition(40, 15);
            Console.WriteLine(timeSec);


            ps = ProgramGame.GameWinMoveYesNo(ref pm, ref mn, ref playingField);
            return ps;
        }
    }
}
