﻿

#pragma checksum "c:\users\thang.dm\documents\visual studio 2013\Projects\Dec2ndWSAD1\Dec2ndWSAD1\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8C47A76AFFCAF4CC0BE2BBEA6D7A6E93"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dec2ndWSAD1
{
    partial class MainPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 14 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).KeyDown += this.OnKeyDown_Username;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 15 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).KeyDown += this.OnKeyDown_Password;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 17 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.OnClick_Login;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


