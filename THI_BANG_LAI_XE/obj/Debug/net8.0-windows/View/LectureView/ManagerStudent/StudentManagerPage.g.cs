﻿#pragma checksum "..\..\..\..\..\..\View\LectureView\ManagerStudent\StudentManagerPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "A717086052074BE5459C7BEDBBD34E4E7C3273D5"
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
using THI_BANG_LAI_XE.View.LectureView.ManagerStudent;


namespace THI_BANG_LAI_XE.View.LectureView.ManagerStudent {
    
    
    /// <summary>
    /// StudentManagerPage
    /// </summary>
    public partial class StudentManagerPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\..\..\View\LectureView\ManagerStudent\StudentManagerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFUllName;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\..\..\View\LectureView\ManagerStudent\StudentManagerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtPhone;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\..\..\View\LectureView\ManagerStudent\StudentManagerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ListCourse;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\..\..\View\LectureView\ManagerStudent\StudentManagerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid DataStudent;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\..\..\View\LectureView\ManagerStudent\StudentManagerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel pagingStudent;
        
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
            System.Uri resourceLocater = new System.Uri("/THI_BANG_LAI_XE;component/view/lectureview/managerstudent/studentmanagerpage.xam" +
                    "l", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\View\LectureView\ManagerStudent\StudentManagerPage.xaml"
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
            this.txtFUllName = ((System.Windows.Controls.TextBox)(target));
            
            #line 23 "..\..\..\..\..\..\View\LectureView\ManagerStudent\StudentManagerPage.xaml"
            this.txtFUllName.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FilterByName);
            
            #line default
            #line hidden
            return;
            case 2:
            this.txtPhone = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\..\..\..\..\View\LectureView\ManagerStudent\StudentManagerPage.xaml"
            this.txtPhone.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.FilterByPhoneNumber);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ListCourse = ((System.Windows.Controls.ComboBox)(target));
            
            #line 34 "..\..\..\..\..\..\View\LectureView\ManagerStudent\StudentManagerPage.xaml"
            this.ListCourse.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ListCourse_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 38 "..\..\..\..\..\..\View\LectureView\ManagerStudent\StudentManagerPage.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.DataStudent = ((System.Windows.Controls.DataGrid)(target));
            
            #line 44 "..\..\..\..\..\..\View\LectureView\ManagerStudent\StudentManagerPage.xaml"
            this.DataStudent.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.DataStudent_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.pagingStudent = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

