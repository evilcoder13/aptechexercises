﻿

#pragma checksum "C:\Users\thang.dm\documents\visual studio 2013\Projects\Nov07thWSAD2ProductCart\Nov07thWSAD2ProductCart\CartPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BD8A4A9ED7145C70ED9297EC6232FC29"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Nov07thWSAD2ProductCart
{
    partial class CartPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 27 "..\..\CartPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)(target)).Checked += this.Check_change;
                 #line default
                 #line hidden
                #line 27 "..\..\CartPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ToggleButton)(target)).Unchecked += this.Check_change;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 45 "..\..\CartPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.Pay_Click;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 42 "..\..\CartPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.GoBack_Click;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 43 "..\..\CartPage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.GoHome_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


