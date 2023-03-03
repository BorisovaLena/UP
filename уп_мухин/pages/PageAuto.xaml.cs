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
using System.Windows.Threading;

namespace уп_мухин.pages
{
    /// <summary>
    /// Логика взаимодействия для PageAuto.xaml
    /// </summary>
    public partial class PageAuto : Page
    {
        Table_Employees employee;
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        int sec;
        string code;
        public PageAuto()
        {
            InitializeComponent();
        }

        private void tbNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key== Key.Enter)
            {
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
                    dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                    dispatcherTimer.Tick += new EventHandler(DisTimer_Tick);
                    Timer();
                }
                else
                {
                    MessageBox.Show("Пароль неверный!!!");
                } 
            }
        }

        private void DisTimer_Tick(object sender, EventArgs e)
        {
            sec--;
            tbTimer.Text = sec + " секунд";
            if (sec == 0)
            {
                dispatcherTimer.Stop();
                tbTimer.Text = "";
                MessageBox.Show("Вы не успели ввести код!!! Сгенерируйте код заново!!!");
                tbCode.Text = "";
                btnUpdateCode.IsEnabled = true;
                btnEnter.IsEnabled = false;
                tbCode.IsEnabled = false;
            }
        }

        public string CodeGeneration()
        {
            Random random = new Random();
            char[] spsimb = { '.', '(', ')', '[', ']', '!', '?', '&', '^', '@', '*', '$', '<', '>', '-', '{', '}', '~', '#', '%', '=' };
            bool sps = false, n = false;
            code = "";
            while (code.Length < 8)
            {
                int rand = random.Next(4);
                switch(rand)
                {
                    case 0:
                        if(n==false)
                        {
                            code += random.Next(9);
                            n = true;
                        }                                             
                        break;
                    case 1:
                        if (sps == false)
                        {
                            code += spsimb[random.Next(21)];
                            sps = true;
                        }
                        break;
                    case 2:
                        code += (char)random.Next('A', 'Z');
                        break;
                    case 3:
                        code += (char)random.Next('a', 'z');
                        break;
                }
            }
            return code;
        }

        private void btnUpdateCode_Click(object sender, RoutedEventArgs e)
        {
            btnUpdateCode.IsEnabled = false;
            tbCode.IsEnabled = true;
            Timer();
        }

        public void Timer() // генерация кода и запуск таймера
        {
            string code = CodeGeneration();
            MessageBox.Show(code);
            tbCode.Focus();
            sec = 10;
            dispatcherTimer.Start();
            tbTimer.Text = "10 секунд";
        }

        private void tbCode_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                entry();
            }
        }

        private void tbCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnEnter.IsEnabled = true;
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            entry();
        }

        public void entry()
        {
            if (tbCode.Text == code)
            {
                dispatcherTimer.Stop();
                tbTimer.Text = "";
                MessageBox.Show(employee.Table_Roles.Role);
            }
            else
            {
                dispatcherTimer.Stop();
                tbTimer.Text = "";
                MessageBox.Show("Код введен неверно!!! Сгенерируйте код заново!!!");
                tbCode.Text = "";
                btnUpdateCode.IsEnabled = true;
                btnEnter.IsEnabled = false;
                tbCode.IsEnabled = false;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            //tbNumber.Text = "";
            //tbCode.Text = "";
            //Password.Password = "";
            //btnUpdateCode.IsEnabled = false;
            //btnEnter.IsEnabled=false;
            //dispatcherTimer.Stop();
            //tbTimer.Text = "";
            classes.ClassFrame.mainFrame.Navigate(new pages.PageAuto());
        }
    }
}
