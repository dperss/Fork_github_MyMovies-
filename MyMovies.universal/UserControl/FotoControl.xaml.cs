﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MyMovies.universal.UserControl
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FotoControl : Page
    {
        public FotoControl()
        {
            this.InitializeComponent();
        }
        public byte[] ImageSource
        {
            get { return (byte[])GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(byte[]), typeof(UserControl.FotoControl), new PropertyMetadata(null, new PropertyChangedCallback(Source_Changed)));

        private static async void Source_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.NewValue != null && e.NewValue is byte[] data)
            {
                var instance = d as FotoControl;
                BitmapImage image = new BitmapImage();
                using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                {
                    await stream.WriteAsync(data.AsBuffer());
                    await image.SetSourceAsync(stream);
                }
                instance.Foto.Source = image;
            }
        }
    }
}