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
    class Die
    {
        private int dieValue;
        private DieColors dieColor;
        private ImageView imageView;

        public Die(ImageView imageView, DieColors color)
        {
            this.imageView = imageView;
            this.dieColor = color;
            rollDie();
        }



        private void rollDie()
        {
            throw new NotImplementedException();
        }
    }
}