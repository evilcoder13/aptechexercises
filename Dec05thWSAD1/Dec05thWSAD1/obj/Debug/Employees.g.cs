﻿

#pragma checksum "c:\users\thang.dm\documents\visual studio 2013\Projects\Dec05thWSAD1\Dec05thWSAD1\Employees.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FB02361FB876FF359B26D7E0372DC693"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Dec05thWSAD1
{
    partial class Employees : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 11 "..\..\Employees.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged += this.Employee_Detail;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 25 "..\..\Employees.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.GoBack_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 27 "..\..\Employees.xaml"
                ((global::Windows.UI.Xaml.Controls.SearchBox)(target)).QuerySubmitted += this.Search_Submit;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}

