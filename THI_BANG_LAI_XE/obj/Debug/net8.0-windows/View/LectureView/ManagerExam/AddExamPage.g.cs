﻿#pragma checksum "..\..\..\..\..\..\View\LectureView\ManagerExam\AddExamPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C72134123DF3851612712C54B5FAC1F497AE0596"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using THI_BANG_LAI_XE.View.LectureView.ManagerExam;


namespace THI_BANG_LAI_XE.View.LectureView.ManagerExam {
    
    
    /// <summary>
    /// AddExamPage
    /// </summary>
    public partial class AddExamPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\..\..\View\LectureView\ManagerExam\AddExamPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRoomName;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\..\..\View\LectureView\ManagerExam\AddExamPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ListCourse;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\..\..\..\View\LectureView\ManagerExam\AddExamPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker txtDateStart;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\..\..\View\LectureView\ManagerExam\AddExamPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel DataExamPaper;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/THI_BANG_LAI_XE;component/view/lectureview/managerexam/addexampage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\View\LectureView\ManagerExam\AddExamPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "9.0.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 19 "..\..\..\..\..\..\View\LectureView\ManagerExam\AddExamPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtRoomName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.ListCourse = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.txtDateStart = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.DataExamPaper = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            
            #line 48 "..\..\..\..\..\..\View\LectureView\ManagerExam\AddExamPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

