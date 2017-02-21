using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Oct28thWSAD2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Calculator : Page
    {
        public Calculator()
        {
            this.InitializeComponent();
        }
        //Chua su dung
        CalculatorCheck cc = new CalculatorCheck();
        // De match '(' voi ')'
        int openSign = 0;
        private void Digit_Click(object sender, RoutedEventArgs e)
        {
            //Kiem tra xem da co gia tri nao luu trong oriValue khong, neu co thi se tra gia tri nay ve cho textbox (la gia tri thap phan cua phep tinh gan nhat)
            if(isSet)
            {
                txtFormula.Text = oriValue.ToString();
                isSet = false;
            }
            //Gan content cua nut duoc bam vao textbox
            txtFormula.Text += ((Button)sender).Content.ToString();
            //Kiem tra ky tu vua nhap, neu la kieu so thi cho phep su dung cac dau +-*/, neu khong khoa cac nut do lai.
            char c = txtFormula.Text[txtFormula.Text.Length - 1];
            cc.afterNumber = char.IsDigit(c);
            cc.afterSign = !char.IsDigit(c);
            //Kiem tra ky tu vua nhap la dau ngoac de xu ly match giua dau mo va dong ngoac
            if (c == '(')
                openSign++;
            if (c == ')')
                openSign--;
            if (openSign > 0)
                cc.allowClose = true;
            //Khoa cac nut +-*/ khi ky tu cuoi cung nhap khong phai la so
            this.DataContext = cc.afterNumber;//char.IsDigit(c);
        }

        private void Function_Click(object sender, RoutedEventArgs e)
        {
            //Kiem tra xem da co gia tri nao luu trong oriValue khong, neu co thi se tra gia tri nay ve cho textbox (la gia tri thap phan cua phep tinh gan nhat)
            if (isSet)
            {
                txtFormula.Text = oriValue.ToString();
                isSet = false;
            }
            //Tuy theo nut chuc nang duoc bam se xu ly du lieu.
            switch (((Button)sender).Content.ToString())
            {
                case "AC": // Xoa du lieu
                    txtFormula.Text = "";
                    txtFormula.Header = "Formula";
                    break;
                case "=": // Tinh toan bieu thuc
                    //Bo sung dau ')' vao cuoi chuong trinh neu thieu dau )
                    for (int i = 0; i < openSign; i++)
                        txtFormula.Text += ")";
                    //Dua bieu thuc hien tai len header, them dau =
                    txtFormula.Header = txtFormula.Text + "=";
                    //Xu ly giai thua
                    while (txtFormula.Text.Contains("!"))
                    {
                        //Tim doan text chua giai thua, chay lay phan so truoc giai thua de xu ly
                        int idx = txtFormula.Text.IndexOf("!");
                        int lidx = 0;
                        string factorial = "";
                        for (int i = idx - 1; i >= 0; i--)
                            if (char.IsDigit(txtFormula.Text[i]))
                                factorial = txtFormula.Text[i] + factorial;
                            else
                            {
                                //Het day so cua giai thua, break va luu lai vi tri cuoi.
                                lidx = i + 1;
                                break;
                            }
                        //Thuc hien tinh giai thua theo day so nhan duoc
                        long f = 1;
                        for (int i = 1; i <= int.Parse(factorial); i++)
                            f *= i;
                        //Bo phan text giai thua di
                        txtFormula.Text = txtFormula.Text.Remove(lidx, idx - lidx + 1);
                        //Thay phan ket qua tinh giai thua vao phan text da bo
                        txtFormula.Text = txtFormula.Text.Insert(lidx, f.ToString());
                    }
                    try
                    {
                        //Thuc hien tinh toan bieu thuc. Bao loi neu bieu thuc khong the tinh toan duoc.
                        Jace.CalculationEngine engine = new Jace.CalculationEngine();
                        txtFormula.Text = engine.Calculate(txtFormula.Text.Replace("x", "*")).ToString();
                    }
                    catch { ThongBao("Bad formula!"); }
                    break;
            }
        }

        private void Go_Back(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Exit();
        }
        void ThongBao(string message)
        {
            Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog(message);
            m.ShowAsync();
        }
        long oriValue = 0;
        bool isSet = false;
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Kiem tra loai convert duoc chon tren listbox, neu khong chon hoac chon dong convert thi khong xu ly gi ca.
            ListBox l = (ListBox)sender;
            if (l.SelectedIndex <= 0)
                return;
            //Kiem tra phan textbox xem co phai kieu so hay khong, neu khong phai se bao khong convert.
            if(!isSet)
            foreach(char c in txtFormula.Text)
                if(!char.IsDigit(c))
                {
                    ThongBao("Can not convert!");
                    return;
                }
            //Kiem tra xem da luu gia tri thap phan vao oriValue chua, neu chua thi luu lai de tinh toan, neu da luu thi khong can set lai gia tri.
            if(!isSet)
            {
                oriValue = long.Parse(txtFormula.Text);
                isSet = true;
            }
            var li = l.SelectedItem as ListBoxItem;
            //Thuc hien convert so trong textbox theo 4 dinh dang dua ra.
            switch(li.Content.ToString())
            {
                case "BIN":
                    txtFormula.Text = Convert.ToString(oriValue, 2);
                    break;
                case "OCT":
                    txtFormula.Text = Convert.ToString(oriValue, 8);
                    break;
                case "DEC":
                    txtFormula.Text = Convert.ToString(oriValue, 10);
                    break;
                case "HEX":
                    txtFormula.Text = Convert.ToString(oriValue, 16);
                    break;
            }
        }
    }
}
