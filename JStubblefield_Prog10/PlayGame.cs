/*Jason Stubblefield
 * Program 10, Due 3/27/18
 * Partner name: None
 * Description: This program allows the user to play rock-paper-scissors against Watson
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace JStubblefield_Prog10
{
    class PlayGame
    {
        static void Main(string[] args)
        {
            string name;
            string winner;

            Greeting();
            name = GetName();

            do
            {
                RockPaperPlayer person = new RockPaperPlayer(name);
                RockPaperPlayer watson = new RockPaperPlayer("Watson");
                for (int round = 1; round < 8; round++)
                {
                    person.MakeChoice(GetNum(true));
                    watson.MakeChoice(GetNum(false));
                    winner = PlayRound(person, watson);
                    Winner(person, watson, winner, round);
                }
            }
            while (RepeatGame());

            WriteLine();
        }

        public static void Greeting()
        {
            WriteLine("Welcome to the Rock, Paper, Scissors Championship!\n");
            WriteLine("You will be playing against Watson. You will choose a number between 1 and 3. Watson will choose a random number between 1 and 3.");
            WriteLine("1 = Rock\n2 = Paper\n3 = Scissors");
            WriteLine("These numbers will be compared to determine the winner of each round. There will be seven (7) rounds.");
            WriteLine("Good luck!\n");
        }

        public static string GetName()
        {
            Write("What is your name?  ");
            return ReadLine();
        }

        public static int GetNum(bool person)
        {
            Random r = new Random();
            int choice = 0;
            if (person)
            {
                Write("\nEnter a number 1-3:  ");
                choice = int.Parse(ReadLine());
                while (choice < 1 || choice > 3)
                {
                    Write("That's not a valid choice. Enter a number 1, 2, or 3:  ");
                    choice = int.Parse(ReadLine());
                }
            }
            else
            {
                choice = r.Next(1, 4);
            }
            return choice;
        }

        public static string PlayRound(RockPaperPlayer person, RockPaperPlayer watson)
        {
            if ((person.Choice == "Rock" && watson.Choice == "Paper")
                || (person.Choice == "Paper" && watson.Choice == "Scissors")
                || (person.Choice == "Scissors" && watson.Choice == "Rock"))
            {
                watson.Wins++;
                return "Winner is: " + watson.Name;
            }
            else if ((person.Choice == "Rock" && watson.Choice == "Scissors")
                || (person.Choice == "Paper" && watson.Choice == "Rock")
                || (person.Choice == "Scissors" && watson.Choice == "Paper"))
            {
                person.Wins++;
                return "Winner is: " + person.Name;
            }
            else
            {
                return "Round was a tie.";
            }
        }

        public static void Winner(RockPaperPlayer person, RockPaperPlayer watson, string winner, int round)
        {
            WriteLine("\nRound {0}", round);
            WriteLine("{0} chose {1}", person.Name, person.Choice);
            WriteLine("{0} chose {1}\n", watson.Name, watson.Choice);
            WriteLine(winner);
            Write(person);
            Write(watson);
            if (round == 7)
            {
                if (person.Wins > watson.Wins)
                {
                    WriteLine("\nWinner of the game is {0}\n", person.Name);
                }
                else if (watson.Wins > person.Wins)
                {
                    WriteLine("\nWinner of the game is {0}\n", watson.Name);
                }
                else
                {
                    WriteLine("\nGame was a tie\n");
                }
            }
        }

        public static bool RepeatGame()
        {
            Write("Would you like to play again?  ");
            string confirm = ReadLine();
            if (confirm == "Yes" || confirm == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
