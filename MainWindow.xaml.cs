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
using System.IO;
using Forge.Forms;
using WpfAnimatedGif;

namespace SMAShareXCaptureOptions
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string[] imgFormats =
        {
            ".jpg", ".jpeg", ".png", ".gif"
        };

        public static string[] audioFormats =
        {
            ".wav", ".mp3", ".ogg",
        };

        public static string[] videoFormats =
        {
            ""
        };

        public MainWindow()
        {

            List<string> args = App.Args;
            if (args == null || args.Count == 0)
            {
                OpenAlert("Failed to open options window because no filepath argument was passed");
                return;
            }

            string filepath = args[0];
            if (!File.Exists(filepath))
            {
                OpenAlert("Failed to open options window because filepath does not exist");
                return;
            }

            string ext = System.IO.Path.GetExtension(filepath);

            var mediaType = MediaType.Image;
            if (imgFormats.Any(x => x == ext))
            {
                mediaType = MediaType.Image;
            }
            else if (audioFormats.Any(x => x == ext))
            {
                mediaType = MediaType.Audio;
            }
            else if (videoFormats.Any(x => x == ext))
            {
                mediaType = MediaType.Video;
            }
            else
            {
                OpenAlert("Files with extension {ext} are not supported");
                return;
            }

            InitializeComponent();

            var extract = new Extract()
            {
                File = filepath,
                MediaExtension = ext,
                MediaType = mediaType,
                IsSupported = imgFormats.Any(x => x == ext)
            };

            DG1.Items.Add(extract);

            if (extract.MediaType == MediaType.Image)
            {
                var uri = new Uri(filepath);
                var bitmap = new BitmapImage(uri);
                if (ext == ".gif")
                {

                    ImageBehavior.SetAnimatedSource(GifBox, bitmap);
                    return;
                }
                else
                {
                    ImageBox.Source = bitmap;
                    return;
                }

            }
            else if (extract.MediaType == MediaType.Audio)
            {
                //MediaPlayer.Source = filepath;
            }
        }

        private void OpenAlert(string msg)
        {
            Forge.Forms
                .Show
                .Window()
                .For(new Alert(msg));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void PrioritySlider_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.PageDown)
            {
                PrioritySlider.Value += 10;
                e.Handled = true;
            }
            else if (e.Key == Key.PageUp)
            {
                PrioritySlider.Value -= 10;
                e.Handled = true;
            }
            else if (e.Key == Key.Escape)
            {
                Close();
            }
        }
    }
}
