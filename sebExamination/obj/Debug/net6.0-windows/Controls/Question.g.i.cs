﻿#pragma checksum "..\..\..\..\Controls\Question.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7A16507302323228D0EFBF97ED013CEB087BE38F"
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
using sebExamination.Controls;


namespace sebExamination.Controls {
    
    
    /// <summary>
    /// Question
    /// </summary>
    public partial class Question : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 9 "..\..\..\..\Controls\Question.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Questions;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\..\Controls\Question.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid category_Selector;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Controls\Question.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox category_parent;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\..\Controls\Question.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox showSubcategoriesQuestions;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Controls\Question.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox showOldQuestions;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Controls\Question.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton CreateQuestionBtn;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/sebExamination;component/controls/question.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Controls\Question.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Questions = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.category_Selector = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.category_parent = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.showSubcategoriesQuestions = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.showOldQuestions = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 6:
            this.CreateQuestionBtn = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 45 "..\..\..\..\Controls\Question.xaml"
            this.CreateQuestionBtn.Click += new System.Windows.RoutedEventHandler(this.CreateQuestionBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

