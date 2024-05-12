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
        public int [] Cards = new int [9] {2,3,4,5,6,7,8,9,10};
        public Random rnd = new Random();
        public int playerhand; 
        public int dealerhand;
        public string result;

        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        private void NewGame()
        {



         int playerhand = 0;
         int dealerhand = 0;

        // Kiosztás
       
                playerhand+= (rnd.Next(1, 11));
                
                dealerhand+=(rnd.Next(1, 11));
                

            

            

            // Frissítés
            UpdateHands();
        }

        private void UpdateHands()
        {
            playercardsbox.Text=playerhand.ToString();
      
            dealercardsbox.Text = dealerhand.ToString();
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
            }
            else if (dealerhand > 21 || dealerhand < playerhand)
            {
                result = "Player wins!";
            }
            else
            {
                result = "Draw!";
            }

            MessageBox.Show(result, "Game Over");
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGame();
        }

        
    }
}
