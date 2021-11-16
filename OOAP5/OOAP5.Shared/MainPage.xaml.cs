using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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

        ObservableCollection<Warrior> WarriorsList => new();

        public MainPage()
        {
            this.InitializeComponent();

            Heroes.ItemsSource = WarriorsList;
        }

        public void CreateWarrior_Click()
        {
            Warrior newWarrior = Race.SelectionBoxItem.ToString() switch
            {
                "Human" => new Human(CharacterName.Text),
                "Troll" => new Troll(CharacterName.Text),
                "Orc" => new Troll(CharacterName.Text),
                _ => new Human(CharacterName.Text),
            };

            newWarrior = Weapon.SelectionBoxItem.ToString() switch
            {
                "Bow" => new Archer(newWarrior),
                _ => new Archer(newWarrior),
            };
        }
    }
}
