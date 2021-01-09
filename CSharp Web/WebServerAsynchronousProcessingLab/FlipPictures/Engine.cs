namespace FlipPictures
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using System.Drawing;
    using System.IO;
    using System.Linq;

    public class Engine
    {
        private const string path = @"../../../Pictures/";
        private const string flippedPath = @"../../../FlippedPictures/";

        public void Run()
        {
            var images = GetImages();
            FlipImageAsync(images);
            string input;
            while ((input = Console.ReadLine()) != "exit")
            {

            }
        }

        private async void FlipImageAsync(List<Image> images)
        {
           await Task.Run(() => Rotate(images));
        }

        private void Rotate(List<Image> images)
        {
            var num = 1;
            foreach (var image in images)
            {
                image.RotateFlip(RotateFlipType.Rotate180FlipX);
                image.Save($"{flippedPath}flippedPic{num++}.jpg");
            }

            Console.WriteLine("All images flipped");
        }

        private List<Image> GetImages()
        {
            var directoryInfo = new DirectoryInfo(path);
            var pictures = directoryInfo.GetFiles().ToList();
            var images = new List<Image>();

            foreach (var file in pictures)
            {
                Image image = Image.FromFile(file.FullName);
                images.Add(image);
            }

            return images;
        }
    }
}
