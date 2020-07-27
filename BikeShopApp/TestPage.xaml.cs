using BusinessLogic;
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

namespace BikeShopApp
{
    /// <summary>
    /// TestPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TestPage : Page
    {
        public TestPage()
        {
            InitializeComponent();

            InitListBox();
        }

        private void InitListBox()
        {
            Random rand = new Random();
            string[] names = { "Hugo", "Ted", "Ashley", "Jeff", "Dave", "Allen" };
            List<Car> lists = new List<Car>();
            for (int i = 0; i < 10; i++)
            {
                var red = (byte)(i % 3 == 0 ? 255 : (i * 50) % 255);
                var green = (byte)0;
                var blue = (byte)(i % 3 == 0 ? (i * 90) % 255 : 255);
                int index = rand.Next(names.Length);
                lists.Add(new Car
                {
                    Speed = i * 30,
                    Color = Color.FromRgb(red, green, blue),
                    Driver = new Human
                    {
                        Name = names[index],
                        HasDrivingLicense = true
                    }
                }
                );
            }
            List<Car> DataContext = lists;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Car car = new Car();
            car.Speed = 100;
            car.Color = Colors.Blue;
            car.Driver = new Human { Name = "Ted", HasDrivingLicense = true };

            this.DataContext = car;
        }
    }
}
