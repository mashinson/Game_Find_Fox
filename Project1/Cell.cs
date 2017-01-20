using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    /// <summary>
    /// If player find / don't find foxes 
    /// </summary>
    public enum ShotInCell
    {
        NoAction = 0,
        Find = 1,
        NotFind = -1
        
    }
    /// <summary>
    /// Сell in the playfield 
    /// </summary>
   public  struct Cell
    {
        public int  CounOfFoxes; // count of Foxes in one cell
        public ShotInCell FindFoxs;     // Foxes which found \ not found
    }
}
