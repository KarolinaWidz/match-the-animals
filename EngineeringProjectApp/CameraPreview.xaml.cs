﻿using Coding4Fun.Kinect.Wpf;
using Microsoft.Kinect;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Media;

namespace EngineeringProjectApp
{
    /// <summary>
    /// Logika interakcji dla klasy CameraPreview.xaml
    /// </summary>
    public partial class CameraPreview : Window
    {
        KinectSensor sensor;
        TransformSmoothParameters smoothParameters;
        Stopwatch watch;

        public CameraPreview(KinectSensor sensor, TransformSmoothParameters smoothParameters,Stopwatch watch)
        {
            InitializeComponent();
            this.sensor = sensor;
            this.smoothParameters = smoothParameters;
            this.watch = watch;
            sensor.ColorStream.Enable(ColorImageFormat.RgbResolution1280x960Fps12);
            sensor.ColorFrameReady += Sensor_ColorFrameReady;
            sensor.SkeletonStream.Disable();
            Closing += Window_Closing;
        }

        private void Sensor_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            using (var colorframe = e.OpenColorImageFrame())
            {
                if (null != colorframe)
                {
                    Preview.Background = new ImageBrush(colorframe.ToBitmapSource());
                }
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            sensor.ColorStream.Disable();
            sensor.SkeletonStream.Enable(smoothParameters);
            watch.Start();
        }
    }
}
