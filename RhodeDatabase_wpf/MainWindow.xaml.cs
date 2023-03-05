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
        public MainWindow()
        {
            InitializeComponent();         
        }

        private void Input(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                SearchOp.SearchOperator(TB_SearchBar.Text, ReadFile.Dynamic_Database);
                if(SearchOp.flag == true)
                {
                    DataCompilation.Input_Dynamic_Files(SearchOp.Return_Data());
                    labels();
                    images();
                   

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
            lb_rarity.Content = DataCompilation.Rarity;
            lb_prefab.Content = DataCompilation.PrefabKey;
        }
        private void images()
        {
            image_OperatorPic.Source =  image_OperatorPic.Source = new BitmapImage(new Uri("OpPictures/" + DataCompilation.PrefabKey + ".png", UriKind.Relative));
        }



        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    image_OperatorPic.Source = new BitmapImage(new Uri("OpPictures/char_002_amiya.png", UriKind.Relative));
        //}
    }
}
