using CustomPaintObjectControl.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Markup;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

namespace CustomPaintObjectControl
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void btnImage_Click(object sender, RoutedEventArgs e)
        {
            // Create the image
            Image image = new Image();
            image.Source = new BitmapImage(new Uri(BaseUri, "/Assets/iphone.png"));
            image.Stretch = Stretch.Fill;

            // Get the image properties
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(BaseUri, "/Assets/iphone.png"));
            ImageProperties imageProperties = await file.Properties.GetImagePropertiesAsync();

            // Create the window and set the image as it's content
            PaintObjectTemplatedControl paintObject = new PaintObjectTemplatedControl();
            paintObject.Width = imageProperties.Width;
            paintObject.Height = imageProperties.Height;
            paintObject.Content = image;
            paintObject.OpacitySliderIsVisible = true;

            gridForWindows.Children.Add(paintObject);
        }

        private void btnTextBox_Click(object sender, RoutedEventArgs e)
        {
            TextBox textBox = new TextBox();
            textBox.Style = Resources["styleTextBox"] as Style;
            textBox.Foreground = new SolidColorBrush(Colors.Red);
            textBox.Background = new SolidColorBrush(Colors.LightBlue);
            textBox.BorderBrush = textBox.Foreground;

            PaintObjectTemplatedControl paintObject = new PaintObjectTemplatedControl();
            paintObject.Content = textBox;

            gridForWindows.Children.Add(paintObject);
        }

        private void btnTransparentTextBox_Click(object sender, RoutedEventArgs e)
        {
            TextBox textBox = new TextBox();
            textBox.Style = Resources["styleTextBox"] as Style;
            textBox.Foreground = new SolidColorBrush(Colors.Purple);
            textBox.Background = new SolidColorBrush(Colors.Transparent);
            textBox.BorderBrush = new SolidColorBrush(Colors.Transparent);

            PaintObjectTemplatedControl paintObject = new PaintObjectTemplatedControl();
            paintObject.Content = textBox;

            gridForWindows.Children.Add(paintObject);
        }

        private void btnEllipse_Click(object sender, RoutedEventArgs e)
        {
            Ellipse ellipse = new Ellipse();
            ellipse.Stroke = new SolidColorBrush(Colors.Gray);
            ellipse.StrokeThickness = 5;
            ellipse.Fill = new SolidColorBrush(Colors.LightBlue);

            PaintObjectTemplatedControl paintObject = new PaintObjectTemplatedControl();
            paintObject.Width = 150;
            paintObject.Height = 150;
            paintObject.Content = ellipse;

            gridForWindows.Children.Add(paintObject);
        }

        private void btnRectangle_Click(object sender, RoutedEventArgs e)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Stroke = new SolidColorBrush(Colors.Black);
            rectangle.StrokeThickness = 5;
            rectangle.Fill = new SolidColorBrush(Colors.Pink);

            PaintObjectTemplatedControl paintObject = new PaintObjectTemplatedControl();
            paintObject.Width = 300;
            paintObject.Height = 200;
            paintObject.Content = rectangle;

            gridForWindows.Children.Add(paintObject);
        }

        private void btnRoundedRectangle_Click(object sender, RoutedEventArgs e)
        {
            Rectangle rectangle = new Rectangle();
            rectangle.Stroke = new SolidColorBrush(Colors.LightGreen);
            rectangle.StrokeThickness = 5;
            rectangle.Fill = new SolidColorBrush(Colors.Orange);
            rectangle.RadiusX = 20;
            rectangle.RadiusY = 20;

            PaintObjectTemplatedControl paintObject = new PaintObjectTemplatedControl();
            paintObject.Width = 300;
            paintObject.Height = 300;
            paintObject.Content = rectangle;

            gridForWindows.Children.Add(paintObject);
        }

        private async void btnXaml1_Click(object sender, RoutedEventArgs e)
        {
            // Get your file
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(BaseUri, "/MyXamlTextFiles/SixGridXamlText.txt"));

            // Read your file and set it to a string variable
            string myXamlString = await FileIO.ReadTextAsync(file);

            // Create the object from that string
            object myAdditionalContent = XamlReader.Load(myXamlString);

            // Create the paintObject and set the xaml file object as the content
            PaintObjectTemplatedControl paintObject = new PaintObjectTemplatedControl();
            paintObject.Width = gridForWindows.ActualWidth / 2;
            paintObject.Height = gridForWindows.ActualHeight / 2;
            paintObject.Opacity = 0.6;
            paintObject.OpacitySliderIsVisible = true;
            paintObject.Content = myAdditionalContent;

            gridForWindows.Children.Add(paintObject);
        }

        private async void btnXaml2_Click(object sender, RoutedEventArgs e)
        {
            // Get your file
            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri(BaseUri, "/MyXamlTextFiles/CompressionOverlayXamlText.txt"));

            // Read your file and set it to a string variable
            string myXamlString = await FileIO.ReadTextAsync(file);

            // Create the object from that string
            object myAdditionalContent = XamlReader.Load(myXamlString);

            // Create the paintObject and set the xaml file object as the content
            PaintObjectTemplatedControl paintObject = new PaintObjectTemplatedControl();
            paintObject.Width = gridForWindows.ActualWidth / 2;
            paintObject.Height = gridForWindows.ActualHeight / 2;
            paintObject.Content = myAdditionalContent;

            gridForWindows.Children.Add(paintObject);
        }
    }
}
