using MainProgram.Templates;
using MainProgram.Utilities;
using Microsoft.Win32;
using Core.DatabaseLayer;
using Core.Entities;
using Repositories.Interfaces;
using Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Configuration;
using Services.TextReaders;
using CustomErrorLogger;
using WebApiConsumers;

namespace MainProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ISavedTextRepository _savedTextRepository;
        private const string configApiKeyName = "textWebApi";

        public MainWindow(ISavedTextRepository savedTextRepository)
        {
            InitializeComponent();
            _savedTextRepository = savedTextRepository;

            cbOptions.ItemsSource = GetComboBoxTemplate();
            cbOptions.DisplayMemberPath = "DisplayedText";
            cbOptions.SelectedValuePath = "Value";

            dgTexts.ItemsSource = _savedTextRepository.GetAll();

            gbDatabaseSelection.Visibility = Visibility.Collapsed;
            gbFileDialog.Visibility = Visibility.Collapsed;
            gbUserText.Visibility = Visibility.Collapsed;
        }

        private void BtnFileBrowser_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDlg = new OpenFileDialog();

            bool? result = openFileDlg.ShowDialog();
            if (result == true)
            {
                txtFileName.Text = openFileDlg.FileName;
            }
        }

        private void CbOptions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = cbOptions.SelectedItem as ComboBoxTemplate;

            //make sure position is at the same place
            var marginPosition = new Thickness(44, 64, 0, 0);

            switch (selectedItem.Value)
            {
                case 1:
                    gbDatabaseSelection.Visibility = Visibility.Hidden;
                    gbFileDialog.Visibility = Visibility.Hidden;

                    gbUserText.Visibility = Visibility.Visible;
                    gbUserText.Margin = marginPosition;
                    break;
                case 2:
                    gbDatabaseSelection.Visibility = Visibility.Visible;
                    gbDatabaseSelection.Margin = marginPosition;

                    gbFileDialog.Visibility = Visibility.Hidden;
                    gbUserText.Visibility = Visibility.Hidden;
                    break;
                case 3:
                    gbDatabaseSelection.Visibility = Visibility.Hidden;
                    gbUserText.Visibility = Visibility.Hidden;

                    gbFileDialog.Visibility = Visibility.Visible;
                    gbFileDialog.Margin = marginPosition;
                    break;
                default:
                    break;
            }
        }

       

        #region helper methods
        private List<ComboBoxTemplate> GetComboBoxTemplate()
        {
            var comboBoxItems = new List<ComboBoxTemplate>()
            {
                new ComboBoxTemplate{Value= 1, DisplayedText= "Input your text"},
                new ComboBoxTemplate{Value= 2, DisplayedText= "Select text from database"},
                new ComboBoxTemplate{Value= 3, DisplayedText= "Select a file to get it's text"}
            };

            return comboBoxItems;
        }

        private string ExtractText(ComboBoxTemplate selectedOption)
        {
            string jsonString = "";
            var readerType = Enum.TryParse(selectedOption.Value.ToString(), out ReaderType type);
            var sourceTextReader = new SourceReader().GetAppropriateReader(type);

            if (selectedOption.Value == 3 && string.IsNullOrEmpty(txtFileName.SelectedText))
            {
                jsonString = sourceTextReader.GetTextFromSource(txtFileName.SelectedText);
            }

            if (selectedOption.Value == 2 && dgTexts.SelectedItem != null)
            {
                var selectedDataGriItem = dgTexts.SelectedItem as SavedText;
                jsonString = _savedTextRepository.GetById(selectedDataGriItem.Id).TextValue;
            }

            if (selectedOption.Value == 1 && !string.IsNullOrEmpty(txtUserInput.Text))
            {
                jsonString = txtUserInput.Text;
            }

            return jsonString;
        }
        #endregion

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var selectedOptionFromComboBox = cbOptions.SelectedItem as ComboBoxTemplate;
            string textToBeSent = ExtractText(selectedOptionFromComboBox);

            if (!TextChecker.CheckIfTextIsFormedCorrectly(textToBeSent))
            {
                MessageBox.Show("Input is not in correct format, it can not be empty, and it must contains some letters");
                return;
            }

            //TODO:: initiate request sending
            TextWebApi webApi = new TextWebApi(configApiKeyName, "xasdasdASFASGAGADasdasfgads1231241afasfafas");
            TextWebApi webApiWithoutToken = new TextWebApi(configApiKeyName, null);

            string respo = await webApi.GetResponseFromApi(textToBeSent);
            MessageBox.Show(respo);

            string responseWithoutToken = await webApiWithoutToken.GetResponseFromApi(textToBeSent);
            MessageBox.Show(responseWithoutToken);
        }
    }
}
