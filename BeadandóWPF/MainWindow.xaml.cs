using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BeadandóWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Random rnd = new Random();
        public int playerhand=0; 
        public int dealerhand=0;
        public string result;
        public int kartya;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Hit_Click(object sender, RoutedEventArgs e)
        {
            playerhand +=(rnd.Next(1, 11)); 
            UpdateHands();
            if (playerhand>21)
            {
                MessageBox.Show("U lose", "Game Over");
            }
        }

        private void Stand_Click(object sender, RoutedEventArgs e)
        {
            // Szabályok alapján a ház húz
            while (dealerhand < 17)
            {
                dealerhand+=(rnd.Next(1, 11));
            }
            UpdateHands();
            string result;
            if (playerhand > 21 || (dealerhand <= 21 && dealerhand > playerhand))
            {
                result = "Dealer wins!";
                NewGame.Visibility = Visibility.Visible;
            }
            else if (dealerhand > 21 || dealerhand < playerhand)
            {
                result = "Player wins!";
                NewGame.Visibility = Visibility.Visible;
            }
            else
            {
                result = "Draw!";
                NewGame.Visibility = Visibility.Visible;
            }

            MessageBox.Show(result, "Game Over");
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
          
            ClearHands();
            // Kiosztás           
          
            // Frissítés
            
            NewGame.Visibility = Visibility.Hidden;
            Bet.Visibility = Visibility.Visible;
        }
        private void ClearHands()
        {
            dealercardsbox.Clear();
            playercardsbox.Clear();
        }
        private void UpdateHands()
        {   
            playercardsbox.Text = playerhand.ToString();
            dealercardsbox.Text = dealerhand.ToString();
        }

        private void Bet_Click(object sender, RoutedEventArgs e)
        {
            playerhand += (rnd.Next(1, 11));
            dealerhand += (rnd.Next(1, 11));
            playerhand += (rnd.Next(1, 11));
            dealerhand += (rnd.Next(1, 11));
            UpdateHands();
            Bet.Visibility = Visibility.Hidden;
        }
    }
}
