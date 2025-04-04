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

//Performed by Slipushkina Oleksandra

namespace Laboratory2
{
    
    public partial class MainWindow : Window
    {
        private readonly PersonViewModel _viewModel;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new PersonViewModel();
            DataContext = _viewModel;
        }

        private void Proceed_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ProceedAsync();
        }
    }
}
