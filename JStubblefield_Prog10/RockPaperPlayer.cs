/*Jason Stubblefield
 * Program 10, Due 3/27/18
 * Partner name: None
 * Description: This instance class is used to create the two players and to translate their inputs to rock, paper, or scissors
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JStubblefield_Prog10
{
    class RockPaperPlayer
    {
        private string name;
        private int wins;
        private string choice;

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Choice
        {
            get
            {
                return choice;
            }
            set
            {
                choice = value;
            }
        }

        public int Wins
        {
            get
            {
                return wins;
            }
            set
            {
                wins = value;
            }
        }

        public RockPaperPlayer(string nam)
        {
            name = nam;
            wins = 0;
        }

        public void MakeChoice(int num)
        {
            switch (num)
            {
                case 1:
                    choice = "Rock";
                    break;
                case 2:
                    choice = "Paper";
                    break;
                default:
                    choice = "Scissors";
                    break;
            }
        }

        public override string ToString()
        {
            string result = "Name:  " + name + "\nWins:  " + wins + "\n";
            return result;
        }
    }
}
