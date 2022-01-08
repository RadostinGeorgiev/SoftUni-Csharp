using System;

namespace _03._Stream_Of_Letters
{
    class Program
    {
        static void Main(string[] args)
        {
            bool firstC = false;
            bool firstO = false;
            bool firstN = false;
            string sentence = "";
            string currentWord = "";

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                char currentStymbol = char.Parse(command);

                if ((currentStymbol < 'a' || currentStymbol > 'z') &&
                    (currentStymbol < 'A' || currentStymbol > 'Z')) continue;

                if (currentStymbol == 'c' && !firstC)
                {
                    firstC = true;
                }
                else if (currentStymbol == 'o' && !firstO)
                {
                    firstO = true;
                }
                else if (currentStymbol == 'n' && !firstN)
                {
                    firstN = true;
                }
                else
                {
                    currentWord += currentStymbol;
                }

                if (!firstC || !firstO || !firstN) continue;

                sentence += currentWord + " ";
                currentWord = "";
                firstC = false;
                firstO = false;
                firstN = false;
            }

            Console.Write(sentence);
        }
    }
}
