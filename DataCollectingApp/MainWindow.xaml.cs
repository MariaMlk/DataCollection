using Microsoft.Win32;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Xml.Serialization;

namespace DataCollectingApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ViewModel Model { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Model = new ViewModel();
            DataContext = Model;
            Genders.ItemsSource = new[] { "Мужской", "Женский" };
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            var saveDialog = new SaveFileDialog();
            if (saveDialog.ShowDialog() == true)
            {
                var filePath = saveDialog.FileName;
                var xmlSerializer = new XmlSerializer(typeof(ViewModel));

                using (var writer = new StreamWriter(filePath))
                {
                    xmlSerializer.Serialize(writer, Model);
                }                
            }
        }

        private void LoadClick(object sender, RoutedEventArgs e)
        {
            var openDialog = new OpenFileDialog();
            if(openDialog.ShowDialog() == true)
            {
                var filePath = openDialog.FileName;

                var xmlSerializer = new XmlSerializer(typeof(ViewModel));

                using (var fs = new FileStream(filePath, FileMode.Open))
                {
                    Model = (ViewModel)xmlSerializer.Deserialize(fs);
                    DataContext = Model;
                }
            }
        }

        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            var regex = new Regex("[^0-9\\+\\(\\)-]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
