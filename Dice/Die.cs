using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Dice
{
    public enum DieColor
    {
        White,
        Transparent
    }

    class Die
    {
        private Random random;
        private int dieValue;
        private DieColor currentDieColor;
        private ImageView imageView;

        public Die(ImageView imageView, DieColor color)
        {
            random = new Random();

            this.imageView = imageView;
            this.currentDieColor = color;
            RollDie();
        }

        public void SetDieColor(DieColor dieColor)
        {
            this.currentDieColor = dieColor;
            SetDieValue(imageView, dieValue);
        }

        public void RollDie()
        {            
            int dieValue = random.Next(1, 7);
        }

        public bool IsVisible()
        {
            ViewStates visibility = imageView.Visibility;
            if (visibility == ViewStates.Visible)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void SetVisible(bool visible)
        {
            if (visible)
            {
                imageView.Visibility = ViewStates.Visible;
            }
            else
            {
                imageView.Visibility = ViewStates.Invisible;
            }

        }

        private void SetDieValue(ImageView dieImg, int value)
        {
            if (currentDieColor == DieColor.White)
            {
                if (value == 1)
                    dieImg.SetImageResource(Resource.Drawable.die1_white);

                else if (value == 2)
                {
                    dieImg.SetImageResource(Resource.Drawable.die2_white);
                }

                else if (value == 3)
                {
                    dieImg.SetImageResource(Resource.Drawable.die3_white);
                }

                else if (value == 4)
                {
                    dieImg.SetImageResource(Resource.Drawable.die4_white);
                }

                else if (value == 5)
                {
                    dieImg.SetImageResource(Resource.Drawable.die5_white);
                }

                else if (value == 6)
                {
                    dieImg.SetImageResource(Resource.Drawable.die6_white);
                }
            }

            else if (currentDieColor == DieColor.Transparent)
            {
                if (value == 1)
                    dieImg.SetImageResource(Resource.Drawable.die1);

                else if (value == 2)
                {
                    dieImg.SetImageResource(Resource.Drawable.die2);
                }

                else if (value == 3)
                {
                    dieImg.SetImageResource(Resource.Drawable.die3);
                }

                else if (value == 4)
                {
                    dieImg.SetImageResource(Resource.Drawable.die4);
                }

                else if (value == 5)
                {
                    dieImg.SetImageResource(Resource.Drawable.die5);
                }

                else if (value == 6)
                {
                    dieImg.SetImageResource(Resource.Drawable.die6);
                }
            }
        }
    }
}