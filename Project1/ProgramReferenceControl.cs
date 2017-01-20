using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
   public  struct ProgramReference
    {
        /// <summary>
        /// Exit the reference 
        /// </summary>
        /// <returns>state of ProgramSate </returns>
        public static ProgramSate ExitReference()
        {
            ProgramSate ps = ProgramSate.Reference;
            Action action;
            action = UserActions.GetUserAction();
            if (action == Action.Exit)
            {
                ps = ProgramSate.Menu;
            }
            return ps;
        }
    }
}
