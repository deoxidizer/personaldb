﻿#pragma checksum "..\..\..\DetailedView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "70625298D0E519F829BE8F427B563A3D"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.18444
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Flug_INSY_Projekt_1.Semester {
    
    
    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 6 "..\..\..\DetailedView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboGeschlecht;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\..\DetailedView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxGeburtsdatum;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\..\DetailedView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxVorname;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\DetailedView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxNachname;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\DetailedView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxID;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\DetailedView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxAdresse;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\DetailedView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboRolle;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\DetailedView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxTel;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\DetailedView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button UPDATE;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\DetailedView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Cancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Flug_INSY_Projekt_1.Semester;component/detailedview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\DetailedView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.ComboGeschlecht = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.TextBoxGeburtsdatum = ((System.Windows.Controls.TextBox)(target));
            
            #line 8 "..\..\..\DetailedView.xaml"
            this.TextBoxGeburtsdatum.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged_1);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TextBoxVorname = ((System.Windows.Controls.TextBox)(target));
            
            #line 9 "..\..\..\DetailedView.xaml"
            this.TextBoxVorname.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged_2);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TextBoxNachname = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\..\DetailedView.xaml"
            this.TextBoxNachname.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TextBox_TextChanged_2);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TextBoxID = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.TextBoxAdresse = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.ComboRolle = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.TextBoxTel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 9:
            this.UPDATE = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\DetailedView.xaml"
            this.UPDATE.Click += new System.Windows.RoutedEventHandler(this.UPDATE_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\DetailedView.xaml"
            this.Cancel.Click += new System.Windows.RoutedEventHandler(this.Cancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

