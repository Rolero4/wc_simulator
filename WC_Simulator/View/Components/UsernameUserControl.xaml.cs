﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WC_Simulator.View.Components
{
    /// <summary>
    /// Interaction logic for UsernameUserControl.xaml
    /// </summary>
    public partial class UsernameUserControl : UserControl
    {
        #region Constructor

        public UsernameUserControl()
        {
            InitializeComponent();
        }

        #endregion


        #region Dependecies

        public static readonly DependencyProperty TBTextProperty = DependencyProperty.Register(
            "TBText",
            typeof(string),
            typeof(UsernameUserControl),
            new FrameworkPropertyMetadata(null)
            );

        public static readonly DependencyProperty TBMaxLengthProperty = DependencyProperty.Register(
            "TBMaxLength",
            typeof(int),
            typeof(UsernameUserControl),
            new FrameworkPropertyMetadata(null)
            );

        public static readonly DependencyProperty TBFontSizeProperty = DependencyProperty.Register(
            "TBFontSize",
            typeof(double),
            typeof(UsernameUserControl),
            new FrameworkPropertyMetadata(null)
            );

        #endregion


        #region Properties

        public string TBText
        {
            get { return (string)GetValue(TBTextProperty); }
            set { SetValue(TBTextProperty, value); }
        }

        public int TBMaxLength
        {
            get { return (int)GetValue(TBMaxLengthProperty); }
            set { SetValue(TBMaxLengthProperty, value); }
        }

        public double TBFontSize
        {
            get { return (double)GetValue(TBFontSizeProperty); }
            set { SetValue(TBFontSizeProperty, value); }
        }

        #endregion


        #region Events



        #endregion

    }
}
