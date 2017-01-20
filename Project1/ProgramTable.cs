namespace Project1
{

    public struct Table
    {
        public int cursorX;
        public int cursorY;
        public Cell[,] Foxes;                           
        public int countFindFoxes;       // sum of caught foxes 
        public int shots;               // sum of shots
        public int countShots;
        public int countPellingFoxes;    // sum of caught foxes by pelling
        public int leftFoxes;            // sum of the remaining foxes
        public int findNowFoxes;         // sum of caugnt foxes in the cell       



        public Table(int size, int countOfFoxes)
        {

           
            countShots = 0;
        
            cursorX = 0;
            cursorY = 0;
            countFindFoxes = 0;
            shots = size*(size-1) + 1;
            countPellingFoxes = 0;
            leftFoxes = countOfFoxes;
            findNowFoxes = 0;

            Foxes = new Cell[size, size];
           
            for(int i = 0; i < Foxes.GetLength(0); i++)
            {
                for (int j = 0; j < Foxes.GetLength(1); j++)
                {
                    Foxes[i, j].CounOfFoxes = 0;
                    Foxes[i, i].FindFoxs = ShotInCell.NoAction;
                }
            }
        }


        /// <summary>
        /// Move the cursor on the playing field
        /// </summary>
        /// <param name="dx">shift by horizontals</param>
        /// <param name="dy">shift in the vertical</param>
        /// <param name="tb">User table</param>
        public void MoveGameCursore(int dx, int dy, ViewTable tb)
        {
            if (cursorX + dx >= 0 && cursorX + dx < tb.size && cursorY + dy >= 0 && cursorY + dy < tb.size)
            {
                cursorX = cursorX + dx;
                cursorY = cursorY + dy;                
            }            
            tb.CursorPosition(cursorX, cursorY);
        }

        /// <summary>
        /// find countFindFoxes, count of shots, pelling
        /// </summary>
        /// <param name="tb">Concole table</param>
        /// <returns>if result = Miss - don`t find Foxes, result = Hit - find Foxes, result = HitFirstCell - shot in first cell, result = Win - user win, result = Lose - user lose </returns>
        public GameState EnterFoxes(ViewTable tb)
        {
            GameState result = GameState.NoAction;
            findNowFoxes = 0;
            countShots += 1;
             shots -= 1;
            if (leftFoxes > 0 && shots >= 0)
            {
                if (cursorX == 0 && cursorY == 0)
                {
                    result = GameState.HitFirstCell;
                }
                else
                {
                    if (Foxes[cursorX, cursorY].CounOfFoxes == 0)
                    {
                        Foxes[cursorX, cursorY].FindFoxs = ShotInCell.NotFind;
                        result = GameState.Miss;
                    }

                    else
                    {
                        countFindFoxes += Foxes[cursorX, cursorY].CounOfFoxes;
                        findNowFoxes = Foxes[cursorX, cursorY].CounOfFoxes;
                        leftFoxes -= Foxes[cursorX, cursorY].CounOfFoxes;
                        Foxes[cursorX, cursorY].CounOfFoxes = 0;

                        Foxes[cursorX, cursorY].FindFoxs = ShotInCell.Find;
                        result = GameState.Hit;
                    }


                }

                // Peleng
                tb.Peleng(cursorY, cursorX, this);
                countPellingFoxes = 0;
                for (int j = 0; j < Foxes.GetLength(1); j++)
                {
                    countPellingFoxes += Foxes[cursorX, j].CounOfFoxes;
                }
                for (int i = 0; i < Foxes.GetLength(0); i++)
                {
                    countPellingFoxes += Foxes[i, cursorY].CounOfFoxes;
                }


            }

            if (leftFoxes == 0)
            {
                result = GameState.Win;
            }
            if (shots < 0)
            {
                result = GameState.Lose;
            }
            //cursorX = 0;
            //cursorY = 0;
            return result;
        }

      



    }
}
