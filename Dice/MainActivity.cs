using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Dice
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        TextView textMessage;
        private Dice dice;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            textMessage = FindViewById<TextView>(Resource.Id.message);
            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);

            ConfigureButtons();

            Dice.CurrentDieColor = DieColor.White;

            dice = new Dice();
            ConfigureDice();
            SetDiceVisibility(6);
        }


        protected override void OnResume()
        {
            base.OnResume();
            dice.ChangeColorOfDice();
        }

        #region BUTTONS
        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:
                    textMessage.SetText(Resource.String.title_home);
                    return true;
                case Resource.Id.navigation_dashboard:
                    textMessage.SetText(Resource.String.title_dashboard);
                    return true;
                case Resource.Id.navigation_notifications:
                    textMessage.SetText(Resource.String.title_notifications);
                    return true;
            }
            return false;
        }

        private void ConfigureButtons()
        {
            FloatingActionButton btnRemoveDie = FindViewById<FloatingActionButton>(Resource.Id.btnRemoveDie);
            btnRemoveDie.Click += BtnRemoveDie_Click;

            FloatingActionButton btnAddDie = FindViewById<FloatingActionButton>(Resource.Id.btnAddDie);
            btnAddDie.Click += BtnAddDie_Click;

            Button btnRollDice = FindViewById<Button>(Resource.Id.btnRollDice);
            btnRollDice.Click += BtnRollDice_Click;
        }

        private void BtnRemoveDie_Click(object sender, System.EventArgs e)
        {
            MakeLastDieInvisible();
        }

        private void BtnAddDie_Click(object sender, System.EventArgs e)
        {
            MakeNextDieVisible();
        }

        private void BtnRollDice_Click(object sender, System.EventArgs e)
        {
            dice.RollDice();
        }
        #endregion



        private void SetDiceVisibility(int numberOfDiceVisible)
        {
            dice.SetDiceVisibility(numberOfDiceVisible);
        }

        // Adds a die up to a maximum of six.
        private void MakeNextDieVisible()
        {
            dice.MakeNextDieVisible();
        }

        // Remove the last die in the list.
        private void MakeLastDieInvisible()
        {
            dice.MakeLastDieInvisible();
        }



        private void ConfigureDice()
        {
            for (int i = 1; i <= 6; i++)
            {
                string imgId = "img_die" + i;
                int imageResourceId = Resources.GetIdentifier(imgId, "id", PackageName);
                ImageView imgView = (ImageView)FindViewById(imageResourceId);

                Die die = new Die(imgView, Dice.CurrentDieColor);
                die.SetVisible(true);
                dice.AddDieToArray(die);
                dice.RollDice();
            }
        }



    }
}

