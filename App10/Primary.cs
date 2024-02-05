using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter;
using System;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace App10
{
    internal class ApplicationSource : IFrameworkViewSource, IFrameworkView
    {
        public virtual IFrameworkView CreateView()
        {
            return this;
        }

        public void Initialize(CoreApplicationView applicationView)
        {
            
        }

        public void SetWindow(CoreWindow window)
        {
            
        }

        public void Load(string entryPoint)
        {
            
        }

        [DllImport("Dll1.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int Launch(CallbackDelegate func);

        public delegate int CallbackDelegate();
        public int initAnalytics()
        {
            AppCenter.Configure("{Your App Secret}");
            if (AppCenter.Configured)
            {
                Debug.WriteLine("AppCenter init ok");
                AppCenter.Start(typeof(Analytics));
                AppCenter.Start(typeof(Crashes));
            }
            return 1;
        }

        public void Run()
        {
            CoreWindow window = CoreWindow.GetForCurrentThread();
            window.Activate();

            CallbackDelegate managedDelegate = new CallbackDelegate(initAnalytics);
            Debug.WriteLine(Launch(managedDelegate));

            //initAnalytics();

            CoreDispatcher dispatcher = window.Dispatcher;
            dispatcher.ProcessEvents(CoreProcessEventsOption.ProcessUntilQuit);
        }

        public void Uninitialize()
        {
            
        }

    }

    public class Primary
    {
        [MTAThread]
        public static int Main()
        {
            var appSource = new ApplicationSource();
            CoreApplication.Run(appSource);
            return 0;
        }
    }
}
