using static System.Console;
using System.Collections.Generic;

namespace Finals
{
    internal class Menu
    {
        private int SelectedIndex;
        private string[] Options;
        private string Prompt;
        private string Prompt1;

        public Menu(string prompt, string[] options) 
        {
           Prompt = prompt;
            Prompt1 = prompt;
           Options = options;
           SelectedIndex = 0;
        }
        private void DisplayOptions()
        {
            WriteLine(Prompt);
            for(int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];

                if (i == SelectedIndex)
                {
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;

                }

                WriteLine($"<< {currentOption} >>");
            }
            ResetColor();
        }
        public int Run()
        {  
            ConsoleKey KeyPressed;
            do
            {
                Clear();
                DisplayOptions();
                ConsoleKeyInfo keyInfo = ReadKey(true);
                KeyPressed = keyInfo.Key;
                if(KeyPressed == ConsoleKey.UpArrow)
                {
                    SelectedIndex--;
                    if(SelectedIndex == -1)
                    {
                        SelectedIndex = Options.Length - 1;
                    }
                }
                else if(KeyPressed == ConsoleKey.DownArrow)
                {
                    SelectedIndex++;
                    if(SelectedIndex == Options.Length)
                    {
                        SelectedIndex = 0;
                    }
                }
            }
            while (KeyPressed != ConsoleKey.Enter);
            return SelectedIndex;
        }
    }
}
