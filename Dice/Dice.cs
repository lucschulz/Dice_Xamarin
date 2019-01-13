using System.Collections.Generic;

namespace Dice
{
    class Dice
    {
        private List<Die> diceList;
        public static DieColor CurrentDieColor { get; set; }

        public Dice()
        {
            diceList = new List<Die>();
        }



        public void RollDice()
        {
            foreach (Die die in diceList)
            {
                die.RollDie();
            }
        }


        public void ReloadDice()
        {
            foreach (Die die in diceList)
            {
                die.SetDieColor(CurrentDieColor);
            }
        }



        /// <summary>
        /// First make all dice invisible, then make specified amount visible.
        /// </summary>
        /// <param name="numberOfDiceVisible">The number of dice to display to the user.</param>
        public void SetDiceVisibility(int numberOfDiceVisible)
        {
            foreach (Die die in diceList)
            {
                die.SetVisible(false);
            }

            for (int i = 0; i < numberOfDiceVisible; i++)
            {
                Die die = diceList[i];
                die.SetVisible(true);
            }
        }


        /// <summary>
        /// Removes a die from view.
        /// </summary>
        public void MakeLastDieInvisible()
        {
            List<Die> list = new List<Die>();

            foreach (Die die in diceList)
            {
                if (die.IsVisible())
                {
                    list.Add(die);
                }
            }

            if (list.Count > 0)
            {
                list[list.Count - 1].SetVisible(false);
            }
        }


        /// <summary>
        /// Adds a die to the display.
        /// </summary>
        public void MakeNextDieVisible()
        {
            List<Die> list = new List<Die>();

            foreach (Die die in diceList)
            {
                if (die.IsVisible() == false)
                {
                    list.Add(die);
                }
            }

            if (list.Count > 0)
            {
                list[0].SetVisible(true);
            }
        }


        /// <summary>
        /// Adds a new instance of the Die class to the instance of the Dice class.
        /// </summary>
        /// <param name="die">A new Die instance.</param>
        public void AddDieToArray(Die die)
        {
            diceList.Add(die);
        }
    }
}