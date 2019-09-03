// Copyright (c) Microsoft Corporation. All Rights Reserved.
// Licensed under the MIT License.

using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using InteractiveDataDisplay.WPF;

namespace ObservableLineGraphSample {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public ObservableCollection<Point> ObsPoints { get; set; } = new ObservableCollection<Point>();

        public MainWindow() {
            InitializeComponent();
            this.DataContext = this;

            for(int i = 0; i < 200; i++)
                ObsPoints.Add(new Point(i, Math.Sin(0.1*i)));
        }

        private void Change_Collection_Button_Click(object sender, RoutedEventArgs e) {
            int start_point = new Random().Next(0, 100);

            for(int i = 0; i < 200; i++)
                ObsPoints[i] = new Point(i + start_point, Math.Sin(0.1 * (i + start_point)));
        }
    }

    public class VisibilityToCheckedConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return ((Visibility)value) == Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            return ((bool)value) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
