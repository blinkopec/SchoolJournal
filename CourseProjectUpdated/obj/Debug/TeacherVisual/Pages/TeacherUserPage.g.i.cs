﻿#pragma checksum "..\..\..\..\TeacherVisual\Pages\TeacherUserPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F80B25EFF7488732AB4C006C2E8B0186B58D5CAE20004C4D22F072F66DA2F301"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CourseProjectUpdated.TeacherVisual.Pages;
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


namespace CourseProjectUpdated.TeacherVisual.Pages {
    
    
    /// <summary>
    /// TeacherUserPage
    /// </summary>
    public partial class TeacherUserPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\TeacherVisual\Pages\TeacherUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImageProfile;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\TeacherVisual\Pages\TeacherUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SurnameBox;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\..\TeacherVisual\Pages\TeacherUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NameBox;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\..\TeacherVisual\Pages\TeacherUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MiddlenameBox;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\TeacherVisual\Pages\TeacherUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button LoadPhotoButton;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\TeacherVisual\Pages\TeacherUserPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveButton;
        
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
            System.Uri resourceLocater = new System.Uri("/CourseProjectUpdated;component/teachervisual/pages/teacheruserpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\TeacherVisual\Pages\TeacherUserPage.xaml"
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
            this.ImageProfile = ((System.Windows.Controls.Image)(target));
            return;
            case 2:
            this.SurnameBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.NameBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.MiddlenameBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.LoadPhotoButton = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\..\TeacherVisual\Pages\TeacherUserPage.xaml"
            this.LoadPhotoButton.Click += new System.Windows.RoutedEventHandler(this.LoadPhotoButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.SaveButton = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\..\TeacherVisual\Pages\TeacherUserPage.xaml"
            this.SaveButton.Click += new System.Windows.RoutedEventHandler(this.SaveButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

