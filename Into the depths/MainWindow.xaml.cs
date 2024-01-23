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

namespace Into_the_depths
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Frame frame;
        public MainWindow()
        {
            InitializeComponent();
            CharCreate();

        }

        private void CharCreate()
        {
            frame = new Frame();
            frame.HorizontalAlignment = HorizontalAlignment.Stretch;
            frame.VerticalAlignment = VerticalAlignment.Stretch;
            AddChild(frame);
            frame.Navigate(new CharacterCreation(this));
        }

        public void closeCharCreatePage()
        {
            Content = null;
        }
    }
}
