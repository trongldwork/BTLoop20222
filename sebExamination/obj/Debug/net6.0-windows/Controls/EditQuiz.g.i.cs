﻿#pragma checksum "..\..\..\..\Controls\EditQuiz.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F2C25BE2D9FAE25D98AFA98BFD724690B52EF35E"
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
    /// EditQuiz
    /// </summary>
    public partial class EditQuiz : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 21 "..\..\..\..\Controls\EditQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock editTitle;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Controls\EditQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton settingTestBtn;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Controls\EditQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock questNum;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\Controls\EditQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MaxGradeTxb;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Controls\EditQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton save_max_geadeBtn;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\..\..\Controls\EditQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton RepaginateBtn;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\..\Controls\EditQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton Select_Multiple_ItemBtn;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\..\Controls\EditQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock totalMark;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\..\..\Controls\EditQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.ToggleButton Add_QuestionBtn;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\..\..\Controls\EditQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid Add_Ques_Grid;
        
        #line default
        #line hidden
        
        
        #line 204 "..\..\..\..\Controls\EditQuiz.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel quesContainer;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/sebExamination;V1.0.0.0;component/controls/editquiz.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Controls\EditQuiz.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "7.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.editTitle = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.settingTestBtn = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 36 "..\..\..\..\Controls\EditQuiz.xaml"
            this.settingTestBtn.Click += new System.Windows.RoutedEventHandler(this.settingTestBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.questNum = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.MaxGradeTxb = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.save_max_geadeBtn = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            return;
            case 6:
            this.RepaginateBtn = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            return;
            case 7:
            this.Select_Multiple_ItemBtn = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            return;
            case 8:
            this.totalMark = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.Add_QuestionBtn = ((System.Windows.Controls.Primitives.ToggleButton)(target));
            
            #line 145 "..\..\..\..\Controls\EditQuiz.xaml"
            this.Add_QuestionBtn.Click += new System.Windows.RoutedEventHandler(this.Add_QuestionBtn_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.Add_Ques_Grid = ((System.Windows.Controls.Grid)(target));
            return;
            case 11:
            
            #line 163 "..\..\..\..\Controls\EditQuiz.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Add_Ques_MouseEnter);
            
            #line default
            #line hidden
            
            #line 163 "..\..\..\..\Controls\EditQuiz.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Add_Ques_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 176 "..\..\..\..\Controls\EditQuiz.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Click += new System.Windows.RoutedEventHandler(this.open_addFromQuestionBank_Click);
            
            #line default
            #line hidden
            
            #line 177 "..\..\..\..\Controls\EditQuiz.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Add_Ques_MouseEnter);
            
            #line default
            #line hidden
            
            #line 177 "..\..\..\..\Controls\EditQuiz.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Add_Ques_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 189 "..\..\..\..\Controls\EditQuiz.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).Click += new System.Windows.RoutedEventHandler(this.Add_Random_Question);
            
            #line default
            #line hidden
            
            #line 190 "..\..\..\..\Controls\EditQuiz.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Add_Ques_MouseEnter);
            
            #line default
            #line hidden
            
            #line 190 "..\..\..\..\Controls\EditQuiz.xaml"
            ((System.Windows.Controls.Primitives.ToggleButton)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Add_Ques_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 14:
            this.quesContainer = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

