using System.Collections.ObjectModel;
using Windows.Globalization.NumberFormatting;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace OOAP5
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public ViewModelClass ViewModel { get; set; }

        internal ObservableCollection<Warrior> WarriorsList = new();

        public MainPage()
        {
            this.InitializeComponent();

            Heroes.ItemsSource = WarriorsList;
        }

        public void CreateWarrior_Click()
        {
            if (RaceOption.SelectedItem == null || WeaponOption.SelectedItem == null || string.IsNullOrEmpty(CharacterName.Text))
            {
                _ = new MessageDialog("Race, weapon or name is not given!", "Hey man!").ShowAsync();
                return;
            }

            WarriorFacade warriorBuilder = new();
            warriorBuilder.PickNameAndRace(RaceOption.SelectionBoxItem.ToString(), CharacterName.Text);
            warriorBuilder.PickWeapon(WeaponOption.SelectionBoxItem.ToString());
            warriorBuilder.PickArmor((int)ArmorPower.Value);

            WarriorsList.Add(warriorBuilder.Warrior);
        }

        public void WarriorDetails()
        {
            var flyout = new Flyout();
            var selectedOne = Heroes.SelectedItem;
            flyout.ShowAt(Heroes as FrameworkElement);

            var selectedWarrior = WarriorsList[Heroes.SelectedIndex];
            var hits = selectedWarrior is Shielder ? (selectedWarrior as Shielder).AttackBlocks : 0;
            do
            {

                hits++;
            } while (true);
        }

        void IntFormatter() => ArmorPower.NumberFormatter = new DecimalFormatter() { FractionDigits = 0, NumberRounder = new IncrementNumberRounder() };
    }
}