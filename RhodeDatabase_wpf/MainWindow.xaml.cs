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
using System.Windows.Media.Animation;
using System.Windows.Threading;
namespace RhodeDatabase_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ReadData ReadFile = new ReadData();
        private CompileData DataCompilation = new CompileData();
        private OperatorSearch SearchOp = new OperatorSearch();
        private dynamic OperatorData = "";
        DispatcherTimer ScreenCover = new DispatcherTimer();
        private double speed = 10;
        public MainWindow()
        {

            InitializeComponent();
            //Background_Video.Play();
            ScreenCover.Interval = new TimeSpan(0, 0, 0, 0, 5);
            ScreenCover.Tick += ScreenCover_Tick;

        }

        private void ScreenCover_Tick(object sender, EventArgs e)
        {
            double left = ScreenC.Margin.Left + speed;
            ScreenC.Margin = new Thickness(left, 90, 0, 0);
            if (ScreenC.Margin.Left > 922)
            {
                ScreenCover.Stop();
            }

        }

        //private void Background_Video_MediaEnded(object sender, RoutedEventArgs e)
        //{
        //    Background_Video.Position = TimeSpan.Zero;
        //    Background_Video.Play();
        //}
        private void Input(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                SearchOp.SearchOperator(TB_SearchBar.Text, ReadFile.Dynamic_Database);
                if(SearchOp.flag == true)
                {
                    ScreenC.Margin = new Thickness(8, 90, 0, 0);
                    DataCompilation.Input_Dynamic_Files(SearchOp.Return_Data());
                    labels();
                    images();
                    ScreenCover.Start();
                }
                else
                {
                    MessageBox.Show("Operator was not found in the database", "Missing Operator");
                }
            }
        }
        private void labels()
        {
            lb_codename.Content = DataCompilation.Name;          
            //lb_namelogo.Content = DataCompilation.Name;
            //lb_identity.Content = DataCompilation.Nation;
            lb_prefab.Content = DataCompilation.PrefabKey;
            lb_profession.Content = DataCompilation.Profession;
            lb_subp.Content = DataCompilation.SubProfession;
            lb_nation.Content = DataCompilation.Nation;



            lb_health.Content = DataCompilation.MaxHp;
            lb_def.Content = DataCompilation.def;
            lb_magicRes.Content = DataCompilation.MagicRes;
            lb_respawn.Content = DataCompilation.respawn;

            lb_atkspeed.Content = DataCompilation.atkspd;
            lb_attack.Content = DataCompilation.atk;
            lb_maxlevel.Content = "MAX LEVEL: " + DataCompilation.Maxlvl;
            lb_position.Content = "POSITION: " + DataCompilation.Position;
            lb_rare.Content = "RARITY: " + DataCompilation.Rarity;
            

        }
        private void images()
        {
            image_OperatorNation.Source = image_OperatorPic.Source = new BitmapImage(new Uri("FactionPictures/logo_" + DataCompilation.Nation + ".png" , UriKind.Relative));
            image_background.Source = image_OperatorPic.Source = new BitmapImage(new Uri("RhodeAssets/Op_Background.PNG", UriKind.Relative));
            image_OperatorPic.Source =  image_OperatorPic.Source = new BitmapImage(new Uri("OpPictures/" + DataCompilation.PrefabKey + ".png", UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This application is for educational purposes \n" + "Made by: @Kritzkingvoid / Kurt Velasco \n" + "@Kengxxiao : EN Files \n" + "@Aceship : Images"  );
        }

        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    Background_Video.Stop();
        //}



        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    image_OperatorPic.Source = new BitmapImage(new Uri("OpPictures/char_002_amiya.png", UriKind.Relative));
        //}
    }
}
