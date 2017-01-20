using System;

namespace Project1
{
    public struct UserReference
    {
        /// <summary>
        /// Show Reference
        /// </summary>
        /// <param name="view">User Table</param>
        /// <param name="playingField">Program Table</param>
        /// <returns>Program state</returns>
        public static ProgramSate Reference(string strReference, ref ViewTable view, ref Table playingField)
        {
            ProgramSate ps = ProgramSate.Reference;
          
            Console.Clear();
            Console.WriteLine(strReference);
            Console.SetCursorPosition(0, 0);

            ps = ProgramReference.ExitReference();
            return ps;

        }

    }
}
