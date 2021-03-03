using System;
using System.IO;
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
using System.Collections.ObjectModel;
using Microsoft.Win32;

namespace D_23._11._2020_List_student
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    class Student
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Group { get; set; }
        public string Age { get; set; }
        public string Photo { get; set; }
        public Student()
        {

        }
    }
    public partial class MainWindow : Window
    {
        private string dir;
        private string dir_photo;
        //  List<Student> students_list;
       private ObservableCollection<Student> students_list;
       private OpenFileDialog openFileDialog;
       private Student newStudent;
        public MainWindow()
        {
            InitializeComponent();
            dir = Directory.GetCurrentDirectory();//путь по умолчанию для пустого фото
           // students_list = new List<Student>();
            students_list = new ObservableCollection<Student>();
            openFileDialog = new OpenFileDialog();

        }
        /// <summary>
        /// Метод подверждения ввода данных (кнопка подвердить)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {

            //обновляем перед каждой прогрузкой лист бокс 
             this.ListBoxInfo.Items.Refresh();
            
          //проверка на заполнение полей текст боксов
            if (this.TextBoxName.Text!="" && this.TextBoxSurname.Text!="" && this.TextBoxGroup.Text!="" && this.TextBoxAge.Text!="" )
            {
               
                newStudent =new Student();
                newStudent.Name = TextBoxName.Text;
                newStudent.Surname = TextBoxSurname.Text;
                newStudent.Age = TextBoxAge.Text;
                newStudent.Group = TextBoxGroup.Text;
                //если фото небыло добавлено то грузим стандартную по умолчанию
                if (dir_photo==null)
                {
                    newStudent.Photo = dir + @"\NoFoto.jpg";
                }
                else
                {
                    newStudent.Photo = dir_photo;
                }
                //добавляем студента в список
                students_list.Add(newStudent);
                this.ListBoxInfo.ItemsSource = students_list;
            }
            //если строки текст бокса не заполненны  то выводим ошибку.Исключением будет фото если его не загружали то будкет отображатьс фото по умолчанию
            else
            {
                MessageBox.Show("Error", "Не все данные были введены", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            //вывод общего количесвта студентов в списке      
            if (students_list.Count != 0)
            {
                this.TextBlockCounter.Text = students_list.Count.ToString();
            }
            //Очищаем поля тескст боксов
            this.TextBoxName.Text = null;
            this.TextBoxSurname.Text = null;        
            this.TextBoxGroup.Text = null;
            this.TextBoxAge.Text = null;
            dir_photo = null;
        }
        //запрещает ввод букв в поле возраста
        private void TextBoxAge_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0)))
            {
                e.Handled = true;
            }

        }

        private void ButtonAddFoto_Click(object sender, RoutedEventArgs e)
        {
            
            openFileDialog.ShowDialog();
            openFileDialog.Filter = "Image Files(*.BMP; *.JPG; *.GIF)| *.BMP; *.JPG; *.GIF | All files(*.*) | *.*";
            dir_photo = null;
            dir_photo = openFileDialog.FileName;
        }

        private void ButtonCancl_Click(object sender, RoutedEventArgs e)
        {
            this.TextBoxName.Text = null;
            this.TextBoxSurname.Text = null;
            this.TextBoxGroup.Text = null;
            this.TextBoxAge.Text = null;
        }

        private void ListBoxInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Window1 window1 = new Window1(this);
            window1.Show();
        }
    }
}
