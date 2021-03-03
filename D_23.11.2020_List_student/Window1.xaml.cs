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
using System.Windows.Shapes;

namespace D_23._11._2020_List_student
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        MainWindow mainWindow;
        public Window1(MainWindow obj)
        {
            InitializeComponent();
            mainWindow = obj;
        
            Student tmp = ((Student)mainWindow.ListBoxInfo.SelectedItem);
            list2.Items.Add(tmp.Name);
            list2.Items.Add(tmp.Surname);
            list2.Items.Add(tmp.Age);


        }
    
    }
}
