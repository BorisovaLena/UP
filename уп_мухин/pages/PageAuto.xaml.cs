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
                    tbCode.IsEnabled = true;
                    string code = CodeGeneration();
                    MessageBox.Show(code);
                }
                else
                {
                    MessageBox.Show("Пароль неверный!!!");
                } 
            }
        }

        public string CodeGeneration()
        {
            Random random = new Random();
            //char [] chars = { '.', '(', ')', '[', ']', '!', '?', '&', '^', '@', '*', '$', '<', '>', '-', '{', '}', '~', '#', '%', '=', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' , 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' , 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
            char[] spsimb = { '.', '(', ')', '[', ']', '!', '?', '&', '^', '@', '*', '$', '<', '>', '-', '{', '}', '~', '#', '%', '=' };
            string code = "";
            bool sps = false, n = false;
            int i = 0;
            while(i<8)
            {
                int rand = random.Next(4);
                switch(rand)
                {
                    case 0:
                        if(n==false)
                        {
                            code += random.Next(9);
                            n = true;
                            i++;
                        }                                             
                        break;
                    case 1:
                        if (sps == false)
                        {
                            code += spsimb[random.Next(21)];
                            sps = true;
                            i++;
                        }
                        break;
                    case 2:
                        code += (char)random.Next('A', 'Z');
                        i++;
                        break;
                    case 3:
                        code += (char)random.Next('a', 'z');
                        i++;
                        break;
                }
                //char c = chars[random.Next(21)];
                //code+= c.ToString();
            }
            return code;
        }
    }
}
