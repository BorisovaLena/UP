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

namespace уп_мухин.pages
{
    /// <summary>
    /// Логика взаимодействия для PageAuto.xaml
    /// </summary>
    public partial class PageAuto : Page
    {
        Table_Employees employee;
        public PageAuto()
        {
            InitializeComponent();
        }

        private void tbNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key== Key.Enter)
            {
                
                //List<Table_Employees> table_Employees = classes.ClassBase.Base.Table_Employees.Where(z => z.Number == tbNumber.Text).ToList();
                if(classes.ClassBase.Base.Table_Employees.FirstOrDefault(z => z.Number == tbNumber.Text)!=null)
                {
                    employee = classes.ClassBase.Base.Table_Employees.FirstOrDefault(z => z.Number == tbNumber.Text);
                    Password.IsEnabled = true;
                    Password.Focus();
                }
                else
                {
                    MessageBox.Show("Такого номера нет!!!");
                }
            }
        }

        private void Password_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if(employee.Password== Password.Password.GetHashCode())
                {
                    MessageBox.Show("qqq");
                }
                else
                {
                    MessageBox.Show("no");
                } 
            }
        }
    }
}
