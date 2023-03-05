﻿using Microsoft.Win32;
using System;
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

namespace TechnicalAssignment
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Brush customColor;
        Random r = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPhoto.Source = new BitmapImage(new Uri(op.FileName));
            }
        }
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddRectangle(object sender, MouseButtonEventArgs e)
        {
            customColor = new SolidColorBrush(Color.FromRgb((byte)r.Next(1, 255), (byte)r.Next(1, 255), (byte)r.Next(1, 255)));
            Rectangle newRectangle = new Rectangle
            {
                Width = 50,
                Height = 50,
                Fill = customColor,
                StrokeThickness = 3,
                Stroke = Brushes.Black
            };

            Canvas.SetLeft(newRectangle, Mouse.GetPosition(cnvImage).X);
            Canvas.SetTop(newRectangle, Mouse.GetPosition(cnvImage).Y);

            cnvImage.Children.Add(newRectangle);


        }

        private void RemoveRectangle(object sender, MouseButtonEventArgs e)
        {
            if (e.OriginalSource is Rectangle)
            {
                Rectangle activeRectangle = (Rectangle)e.OriginalSource;
                cnvImage.Children.Remove(activeRectangle);
            }
        }
    }
}
