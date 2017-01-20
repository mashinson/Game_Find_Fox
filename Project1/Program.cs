using System;
using System.IO;

namespace Project1
{
   public  enum ProgramSate
    {
        Menu,
        Game,
        Reference,
        GameSetUp,
        Exit
    }
   
    class Program
    {
       
        public static string strMenu = "";
        public static string strWin = "";
        public static string strReference = "";
        public static string strExit = "";
      
       
        static void Main(string[] args)
        {
            ViewTable view = new ViewTable();
            MenuConsole mn = new MenuConsole();
            ProgMenu pm = new ProgMenu();
            Table playingField = new Table();

            strMenu = loadResources("MenuFox.txt");
            strWin = loadResources("Win.txt");
            strReference = loadResources("Reference.txt");
            strExit = loadResources("ExitGame.txt");
            ProgramSate ps = ProgramSate.Menu;

            while (ps != ProgramSate.Exit)
            {
                switch (ps)
                {
                    case ProgramSate.Menu:
                        ps = MenuControl.Menu(strMenu, ref pm, ref mn, ref playingField);
                        break;
                    case ProgramSate.Game:
                        ps = ProgramGame.Game(strExit, strWin, ref pm, ref view, ref mn,  ref playingField);
                        break;
                    case ProgramSate.Reference:
                        ps = UserReference.Reference(strReference, ref view, ref playingField);
                        break;
                    case ProgramSate.GameSetUp:
                        ps = ProgramGame.GameSetUp( ref view, ref playingField);
                        break;
                    case ProgramSate.Exit:
                        return;
                }
            }

        }

        

        /// <summary>
        /// Load different files
        /// </summary>
        /// <param name="fileName">name of file and it's path</param>
        /// <returns>a string s that contains information from a file</returns>
        public static string loadResources(string fileName)
        {
            string s = "";
            StreamReader reader = new StreamReader(fileName);
            try
            {
                do
                {
                    s += reader.ReadLine() + "\n";
                }
                while (reader.Peek() != -1);
            }

            catch
            {
                s = "Error!";
            }

            finally
            {
                reader.Close();
            }
            return s;
        }






      
    }
}

