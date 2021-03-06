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
using ClassLibrary2;

namespace Down_of_Nibo
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            ContentCreator.GenerateMaps();

            ContentCreator.GenerateContent();

            Globals.Player.Stats.Def = 20;
            Globals.Player.Stats.speed = 20;
            Globals.Player.Stats.Dmg = 20;

            Globals.Scene = 4;
            
        }
    }
}
