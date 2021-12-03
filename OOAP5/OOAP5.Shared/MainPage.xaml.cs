using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Globalization.NumberFormatting;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

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

        void IntFormatter() => ArmorPower.NumberFormatter = new DecimalFormatter() { FractionDigits = 0, NumberRounder = new IncrementNumberRounder() };
    }
}