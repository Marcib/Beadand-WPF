using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

    public partial class MainWindow : Window
    {
        public Random rnd = new Random();
        public int playerhand=0; 
        public int dealerhand=0;
        public string result;
        public int totalchips = 10000;
        public int totalbet = 0;


        public MainWindow()
        {
            InitializeComponent();
            //Összes pénzösszeg betöltése
            Totalchips.Content = totalchips;
            Icreasebutton.Visibility = Visibility.Hidden;
            Hit.Visibility = Visibility.Hidden;
            Stand.Visibility = Visibility.Hidden;
        }
        private void Hit_Click(object sender, RoutedEventArgs e)
        {
             
            if (totalbet>0)
            {

            
                playerhand +=(rnd.Next(2, 12)); 
                UpdateHands();
                if (playerhand>21)
                {
                    MessageBox.Show("Player bust!", "Game Over");
                    NewGame.Visibility = Visibility.Visible;
                    Icreasebutton.Visibility = Visibility.Visible;
                    totalchips = totalchips - totalbet;
                    Hit.Visibility = Visibility.Hidden;
                    Stand.Visibility = Visibility.Hidden;
                }
            }
        }

        private void Stand_Click(object sender, RoutedEventArgs e)
        {
            //Ha a játékos már nem szeretne lapot kérni
            if (totalbet>0)
            {
                dealerhand += (rnd.Next(2, 12));
                Thread.Sleep(500);
                
                while (dealerhand < 17)
                {
                    dealerhand += (rnd.Next(2, 12));
                }
                UpdateHands();
                string result;
                if (playerhand > 21 || (dealerhand <= 21 && dealerhand > playerhand))
                {
                    result = "Dealer wins!";
                    NewGame.Visibility = Visibility.Visible;
                    Icreasebutton.Visibility = Visibility.Visible;
                    Hit.Visibility = Visibility.Hidden;
                    Stand.Visibility = Visibility.Hidden;
                    totalchips =totalchips -totalbet;
                }
                else if (dealerhand > 21 || dealerhand < playerhand)
                {
                    result = "Player wins!";
                    NewGame.Visibility = Visibility.Visible;
                    Icreasebutton.Visibility = Visibility.Visible;
                    Hit.Visibility = Visibility.Hidden;
                    Stand.Visibility = Visibility.Hidden;
                    totalchips = totalchips + totalbet;
                }
                else
                {
                    result = "Draw!";
                    NewGame.Visibility = Visibility.Visible;
                    Icreasebutton.Visibility = Visibility.Visible;
                    Hit.Visibility = Visibility.Hidden;
                    Stand.Visibility = Visibility.Hidden;
                }

                MessageBox.Show(result, "Game Over");
            }
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            //Frissíti a összes chipset és törli a lapokat.
            if (totalchips==0)
            {
                MessageBox.Show("Sajnos elfogyott az összes chipse", "Nincs elegendő chips");
            }
            Totalchips.Content = totalchips;
            ClearHands();                     
            Icreasebutton.Visibility = Visibility.Visible;
            NewGame.Visibility = Visibility.Hidden;
            Bet.Visibility = Visibility.Visible;
        }
        private void ClearHands()
        {
            //Törli a lapokat
            dealercardsbox.Clear();
            playercardsbox.Clear();
            dealerhand = 0;
            playerhand = 0;
        }
        private void UpdateHands()
        {   
            //Frissíti a lapokat.
            playercardsbox.Text = playerhand.ToString();
            Thread.Sleep(500);
            dealercardsbox.Text = dealerhand.ToString();
        }

        private void Bet_Click(object sender, RoutedEventArgs e)
        {
            //Tét esetén kiosztja a lapokat és engedi a hit és stand gombot
           
            if (totalbet>0 && totalbet<=totalchips)
            {
                playerhand += (rnd.Next(2, 12));
                
                dealerhand += (rnd.Next(2, 12));
                
                playerhand += (rnd.Next(2, 12));
                

                UpdateHands();
                Bet.Visibility = Visibility.Hidden;
                Icreasebutton.Visibility = Visibility.Hidden;
                Hit.Visibility = Visibility.Visible;
                Stand.Visibility = Visibility.Visible;
            }
            else
            {
                MessageBox.Show("Nem megfelelő tétet rakott", "Error");
            }
           

        }

        private void Icreasebutton_Click(object sender, RoutedEventArgs e)
        {
            //Növeli a tétet
             totalbet += 250;
            Totalbet.Content = totalbet;
        }

        private void Clearbutton_Click(object sender, RoutedEventArgs e)
        {
            //Törli a tétet
            totalbet = 0;
            Totalbet.Content = "";

        }

        private void Doublebutton_Click(object sender, RoutedEventArgs e)
        {
            //Duplázza a tétet
            totalbet = totalbet*2;
            Totalbet.Content = totalbet;
        }
    }
}
