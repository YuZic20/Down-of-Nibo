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

namespace Down_of_Nibo
{
    /// <summary>
    /// Interakční logika pro WorldMap.xaml
    /// </summary>
    public partial class WorldMap : Page
    {
        public WorldMap()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Globals.Scene = 0;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Globals.Scene = 1;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Globals.Scene = 2;
        }
        private void Button_Inventory(object sender, RoutedEventArgs e)
        {
            Globals.Scene = 7;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            GameFileHandle.SaveGame();
            Globals.Scene = 4;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            QestInfo.Visibility = Visibility.Visible;
        }
        
        private void Button_Click_Reject(object sender, RoutedEventArgs e)
        {
            QestInfo.Visibility = Visibility.Hidden;
        }
        private void Button_Click_Accept(object sender, RoutedEventArgs e)
        {
            //start battle
            Globals.Mobs[1] = Repository.AllMobs[3];
            Globals.Scene = 5;
            WinScrean.Visibility = Visibility.Visible;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            GameFileHandle.DeleteSave();
            Globals.Scene = 4;
        }
    }
}
