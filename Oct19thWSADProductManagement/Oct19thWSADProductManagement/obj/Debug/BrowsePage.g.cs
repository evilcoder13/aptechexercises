﻿

#pragma checksum "c:\users\thang.dm\documents\visual studio 2013\Projects\Oct19thWSADProductManagement\Oct19thWSADProductManagement\BrowsePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8925273359EE4BDBECC550E06F64293A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Oct19thWSADProductManagement
{
    partial class BrowsePage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 34 "..\..\BrowsePage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnPrevious_Click;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 35 "..\..\BrowsePage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnDelete_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 36 "..\..\BrowsePage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnNext_Click;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 40 "..\..\BrowsePage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.GoBack_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


