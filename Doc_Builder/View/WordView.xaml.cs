using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
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
using System.Windows.Xps.Packaging;
using HandyControl.Controls;
using Microsoft.Office.Interop.Word;
using System.Data;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using HandyControl.Data;
using Microsoft.Office.Core;
using Newtonsoft.Json;
using System.Data.SqlClient;
using Doc_Builder.ClassesForGenerate;
using System.IO;

namespace Doc_Builder.View
{
    /// <summary>
    /// Логика взаимодействия для WordViewCommand.xaml
    /// </summary>
    public partial class WordViewCommand : UserControl
    {
        private int fieldCount = 0; // Counter to keep track of the number of fields
        private string filePath_ = "";
        public int receivedData_;


        public WordViewCommand()
        {
            InitializeComponent();
            cb1.Items.Add("Налоговые");
            cb1.Items.Add("Трудовые");
            cb1.Items.Add("Бухгалтерия");
            cb1.SelectedIndex = 0;
            int receivedData = GlobalVariables.SharedData;
            if (receivedData > 0) {
                receivedData_= receivedData;
            but.Visibility = Visibility.Visible;
            but1.Visibility = Visibility.Visible;
            }

        }

        private string ConvertDictionaryToJson(Dictionary<string, string> dict)
        {
            return JsonConvert.SerializeObject(dict);
        }


        private Dictionary<string, string> ConvertJsonToDictionary(string json)
        {
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
        }
        private void LoadFieldsFromDictionary(Dictionary<string, string> dict)
        {

            foreach (var kvp in dict)
            {
                var fieldGrid = new Grid
                {
                    Margin = new Thickness(0, 5, 0, 5)
                };

                // Define the columns
                fieldGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
                fieldGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                fieldGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                // Create and configure the first textbox
                var firstTextBox = new System.Windows.Controls.TextBox
                {
                    Text = kvp.Key,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 14,
                    Width = 200, // Устанавливаем соответствующую ширину
                    Margin = new Thickness(10, 0, 0, 0),
                 
                };
                Grid.SetColumn(firstTextBox, 1);
                fieldGrid.Children.Add(firstTextBox);

                // Create and configure the second textbox
                var secondTextBox = new System.Windows.Controls.TextBox
                {
                    Text = kvp.Value,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 14,
                    Width = 200, // Устанавливаем соответствующую ширину
                    Margin = new Thickness(10, 0, 0, 0),
                  
                };
                Grid.SetColumn(secondTextBox, 2);
                fieldGrid.Children.Add(secondTextBox);

                // Add the fieldGrid to the FieldContainer
                FieldContainer.Children.Add(fieldGrid);
            }
        }

        private Dictionary<string, string> FormDictionaryFromFields()
        {
            var items = new Dictionary<string, string>();

            foreach (var child in FieldContainer.Children)
            {
                if (child is Grid grid)
                {
                    System.Windows.Controls.TextBox firstTextBox = null;
                    System.Windows.Controls.TextBox secondTextBox = null;

                    foreach (var gridChild in grid.Children)
                    {
                        if (Grid.GetColumn(gridChild as UIElement) == 1 && gridChild is System.Windows.Controls.TextBox)
                        {
                            firstTextBox = gridChild as System.Windows.Controls.TextBox;
                        }
                        else if (Grid.GetColumn(gridChild as UIElement) == 2 && gridChild is System.Windows.Controls.TextBox)
                        {
                            secondTextBox = gridChild as System.Windows.Controls.TextBox;
                        }
                    }

                    if (firstTextBox != null && secondTextBox != null)
                    {
                        // Проверяем, существует ли уже такой ключ в словаре
                        if (!items.ContainsKey(firstTextBox.Text))
                        {
                            items.Add(firstTextBox.Text, secondTextBox.Text);
                        }
                        else
                        {
                            // Обработка случая, когда ключ уже существует
                            // Например, выбор нового уникального ключа или обновление значения существующего ключа
                            // В зависимости от вашей логики
                        }
                    }
                }
            }

            return items;
        }
        private void AddField_Click(object sender, RoutedEventArgs e)
        {// Create a new Grid for the Label and TextBoxes
         // 
         // Создаем новый Grid для Label и TextBox
            var fieldGrid = new Grid
            {
                Margin = new Thickness(0, 5, 0, 5)
            };

            // Определяем колонки
            fieldGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Auto) });
            fieldGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            fieldGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            // Создаем и настраиваем Label
            var newLabel = new System.Windows.Controls.Label
            {
                Foreground = Brushes.White,
                FontSize = 14,
                Content = $"Созданное поле {fieldCount + 1}",
                VerticalAlignment = VerticalAlignment.Center
            };
            Grid.SetColumn(newLabel, 0);
            fieldGrid.Children.Add(newLabel);

            // Создаем и настраиваем первое текстовое поле
            var firstTextBox = new System.Windows.Controls.TextBox
            {
                FontSize = 14,
                Width = 200, // Устанавливаем соответствующую ширину
                Margin = new Thickness(10, 0, 0, 0),
                Name = $"FirstTextBox_{fieldCount}" // Уникальное имя
            };
            Grid.SetColumn(firstTextBox, 1);
            fieldGrid.Children.Add(firstTextBox);

            // Создаем и настраиваем второе текстовое поле
            var secondTextBox = new System.Windows.Controls.TextBox
            {
                Width = 200, // Устанавливаем соответствующую ширину
                Margin = new Thickness(10, 0, 0, 0),
                Name = $"SecondTextBox_{fieldCount}" // Уникальное имя
            };
            Grid.SetColumn(secondTextBox, 2);
            fieldGrid.Children.Add(secondTextBox);

            // Добавляем fieldGrid в FieldContainer
            FieldContainer.Children.Add(fieldGrid);

            fieldCount++; // Увеличиваем счетчик полей


        }

        private void GetValues_Click(object sender, RoutedEventArgs e)
        {

            try
            {   if (filePath_ == null || filePath_.Length == 0)
                {

                    System.Windows.MessageBox.Show("Выберите файл");
                }
                else
                {
                    if (text.Text== null || text.Text.Length == 0)
                    {
                        System.Windows.MessageBox.Show("Заполните поле");
                    }
                    else
                    {
                        var items1 = FormDictionaryFromFields();
                        User10_Sgr1Entities conn = new User10_Sgr1Entities();
                        Mil_Templates templates = new Mil_Templates();
                        templates.Header = text.Text;
                        templates.TypeName = cb1.SelectedItem.ToString();
                        string json = ConvertDictionaryToJson(items1);
                        templates.FieldData = json;
                        templates.Path = filePath_;
                        

                        string destinationFolderPath = "Documents/Templates/";

                        // Имя файла
                        string fileName = System.IO.Path.GetFileName(filePath_);

                        // Путь к целевому файлу с добавлением Header
                        string destinationFilePath = System.IO.Path.Combine(destinationFolderPath, templates.Header + "_" + fileName);

                        // Записываем путь в базу данных
                        templates.Path = destinationFilePath;
                        conn.Mil_Templates.Add(templates);
                        conn.SaveChangesAsync();

                        try
                        {
                            // Перемещаем файл
                            File.Move(filePath_, destinationFilePath);
                            
                        }
                        catch (IOException ex)
                        {
                           
                        }


                        try
                        {
                            // Перемещаем файл
                            File.Move(filePath_, destinationFilePath);
                            
                        }
                        catch (IOException ex)
                        {
                            
                        }


                        var items = FormDictionaryFromFields();
                        var helper = new WordHelper(filePath_);
                        helper.Process(items, text.Text, "");
                    }
                   
                }
            }
            catch (Exception ex) { 

            System.Windows.MessageBox.Show("Файл загружен");
            
            }


        }
        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем и настраиваем OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "All Files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            // Показываем диалоговое окно и проверяем результат
            if (openFileDialog.ShowDialog() == true)
            {
                // Получаем путь к выбранному файлу
                string filePath = openFileDialog.FileName;
                filePath_ = filePath;

                // Обновляем TextBlock с информацией о выбранном файле
                SelectedFileTextBlock.Text = $"Выбранный файл: {filePath}";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            User10_Sgr1Entities conn = new User10_Sgr1Entities();
            Mil_Templates templates = conn.Mil_Templates.FirstOrDefault(c=>c.ID==receivedData_);
            text.Text = templates.Header;
            LoadFieldsFromDictionary(ConvertJsonToDictionary(templates.FieldData));
        }

        private void but1_Click(object sender, RoutedEventArgs e)
        {
            
            var items1 = FormDictionaryFromFields();
            User10_Sgr1Entities conn = new User10_Sgr1Entities();
            Mil_Templates templates = conn.Mil_Templates.FirstOrDefault(c => c.ID == receivedData_);
            filePath_ = templates.Path;
            var helper = new WordHelper(filePath_);
            helper.Process(items1, templates.Header, "");
            GlobalVariables.SharedData = 0;
            filePath_ = "";
        }
    }
}
