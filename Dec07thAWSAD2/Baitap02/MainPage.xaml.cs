using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Background;
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

namespace Baitap02
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            fnChkReg();
            if (!isRegistered)
            {
                RegisterBackgroundTask("BackgroundTask01", "BackgroundTasks.MyBackgroundTask");
            }
        }
        bool isRegistered=false;
        private void fnChkReg()
        {
            foreach (var task in BackgroundTaskRegistration.AllTasks)
            {
                if (task.Value.Name == "BackgroundTask01")
                {
                    isRegistered = true;
                    break;
                }
            }
        }
        private void RegisterBackgroundTask(string n, string p)
        {
            BackgroundTaskBuilder b = new BackgroundTaskBuilder();
            b.Name = n;
            b.TaskEntryPoint = p;
            b.SetTrigger(new SystemTrigger(SystemTriggerType.InternetAvailable,
            false));
            BackgroundTaskRegistration t = b.Register();
            //Thongbao("Task Registered!");
        } 	
        void Thongbao(string message)
        {
            Windows.UI.Popups.MessageDialog m = new Windows.UI.Popups.MessageDialog(message);
            m.ShowAsync();
        }
    }
}
