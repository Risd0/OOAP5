using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
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
            warriorBuilder.PickShield(ShieldType.SelectionBoxItem.ToString());

            WarriorsList.Add(warriorBuilder.Warrior);
        }

        public void WarriorDetails()
        {
            var selectedWarrior = WarriorsList[Heroes.SelectedIndex];

            List<(Warrior warrior, int hits)> strongerWarriors = new();
            List<(Warrior warrior, int hits)> weakerWarriors = new();

            foreach (var warrior in WarriorsList)
            {
                if (warrior == selectedWarrior) continue;   // check if selected warrior don't gonna compare with himself
                // compute how many hits are needed to take down opponent
                int selectedWarriorHits = GetBlocks(warrior) + DefPerDmg(selectedWarrior, warrior);
                int warriorHits = GetBlocks(selectedWarrior) + DefPerDmg(warrior, selectedWarrior);
                // the stronger one who has hits less
                if (selectedWarriorHits <= warriorHits) weakerWarriors.Add((warrior, selectedWarriorHits));
                else strongerWarriors.Add((warrior, warriorHits));
            }

            var info = new StringBuilder();
            info.AppendLine("Wins to:");
            WarriorInfoPart(weakerWarriors, info);
            info.AppendLine();
            info.AppendLine("Lose to:");
            WarriorInfoPart(strongerWarriors, info);

            WarriorInfo.Text = info.ToString();
            FlyoutInfo.ShowAt((FrameworkElement)Heroes);

            static int GetBlocks(Warrior warrior) => warrior is Shielder ? (warrior as Shielder).AttackBlocks : 0;
            static int DefPerDmg(Warrior yourWarrior, Warrior opponent) => opponent.CurrDef / yourWarrior.CurrStrength;
            static void WarriorInfoPart(List<(Warrior warrior, int hits)> warriorsList, StringBuilder info)
            {
                if (warriorsList.Count == 0) info.AppendLine("None");
                else foreach (var opponent in warriorsList)
                        info.AppendLine($"{opponent.warrior.Name} for {opponent.hits} hits");
            }
        }

        public INumberFormatter2 IntFormatter => new DecimalFormatter() { FractionDigits = 0, NumberRounder = new IncrementNumberRounder() };
    }
}