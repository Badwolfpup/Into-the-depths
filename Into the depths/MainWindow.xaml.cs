using System.Windows;
using System.Windows.Controls;

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
            //frame.Navigate(new StartPage());
        }

        public void closeCharCreatePage()
        {
            Content = null;
        }
    }
}
