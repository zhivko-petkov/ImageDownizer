using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp;
using Image = SixLabors.ImageSharp.Image;

namespace ImageDownsizer
{
    internal class ParallService
    {
        public void DownscaleImage(string imagePath, string savePath, string percDownSize)
        {

            float downSize = float.Parse(percDownSize) / 100;
            
            using (Image<Rgba32> image = Image.Load<Rgba32>(imagePath))
            {
                var (redSeparator, greenSeparator, blueSeparator) = ColorSeparate(image);
   
                byte[,] redDownSizedSeparator = null;
                byte[,] greenDownSizedSeparator = null;
                byte[,] blueDownSizedSeparator = null;

                Thread redDSSThread = new Thread(() =>
                {
                    redDownSizedSeparator = BilinearInterpolation(redSeparator, downSize);
                });

                Thread greenDSSThread = new Thread(() =>
                {
                    greenDownSizedSeparator = BilinearInterpolation(greenSeparator, downSize);
                });

                Thread blueDSSThread = new Thread(() =>
                {
                    blueDownSizedSeparator = BilinearInterpolation(blueSeparator, downSize);
                });

                redDSSThread.Start(); 
                greenDSSThread.Start(); 
                blueDSSThread.Start();

                redDSSThread.Join();
                greenDSSThread.Join();
                blueDSSThread.Join();
                SaveDownSizedImage(redDownSizedSeparator, greenDownSizedSeparator, blueDownSizedSeparator, savePath);
            }

        }

        public static (byte[,], byte[,], byte[,]) ColorSeparate(Image<Rgba32> image)
        {
            Thread[] colorThreads = new Thread[image.Height];

            byte[,] red = new byte[image.Height, image.Width];
            byte[,] green = new byte[image.Height, image.Width];
            byte[,] blue = new byte[image.Height, image.Width];


            for (int row = 0; row < image.Height; row++)
            {
                   for (int col = 0; col < image.Width; col++)
                    {
                        Rgba32 pixel = image[col, row];
                        red[row, col] = pixel.R;
                        green[row, col] = pixel.G;
                        blue[row, col] = pixel.B;
                    }
            }

            return (red, green, blue);
        }


        public static (byte[,], byte[,], byte[,]) DownSizeSeparatedColors(byte[,] redChannel, byte[,] greenChannel, byte[,] blueChannel, float downSize)
        {
            var redResized = BilinearInterpolation(redChannel, downSize);
            var greenResized = BilinearInterpolation(greenChannel, downSize);
            var blueResized = BilinearInterpolation(blueChannel, downSize);

            return (redResized, greenResized, blueResized);
        }

        public static byte[,] BilinearInterpolation(byte[,] separatedColorPart, float downSize)
        {
            int rWidth = (int)(separatedColorPart.GetLength(1) * downSize);
            int rHeight = (int)(separatedColorPart.GetLength(0) * downSize);

            byte[,] downsizedColorPart = new byte[rHeight, rWidth];

            //calculate which pixels in the original image correspond to each pixel in the resized image
            float xRatio = rWidth > 1 ? (float)(separatedColorPart.GetLength(1) - 1) / (rWidth - 1) : 0;
            float yRatio = rHeight > 1 ? (float)(separatedColorPart.GetLength(0) - 1) / (rHeight - 1) : 0;

            for (int row = 0; row < rHeight; row++)
            {
                for (int col = 0; col < rWidth; col++)
                {
                    //coordinates of the pixels in the original image that are closest to the current pixel in the resized image
                    int topLeftX = (int)Math.Floor(col * xRatio);
                    int bottomRightX = Math.Min(topLeftX + 1, separatedColorPart.GetLength(1) - 1);
                    int topLeftY = (int)Math.Floor(row * yRatio);
                    int bottomRightY = Math.Min(topLeftY + 1, separatedColorPart.GetLength(0) - 1);

                    //how much the current pixel in the resized image is influenced by each of the four closest pixels in the original image        
                    float yWeight = (row * yRatio) - topLeftY;
                    float xWeight = (col * xRatio) - topLeftX;

                    //intensities of the four closest pixels in the original image.
                    float topLeftPixIntensity = separatedColorPart[topLeftY, topLeftX];
                    float bottomLeftPixIntensity = separatedColorPart[bottomRightY, topLeftX];
                    float topRightPixIntensity = separatedColorPart[topLeftY, bottomRightX];
                    float bottomRightPixIntensity = separatedColorPart[bottomRightY, bottomRightX];

                    // intensity of the current pixel in the resized image
                    downsizedColorPart[row, col] = (byte)CalculatePixel(xWeight, yWeight,
                        topLeftPixIntensity, topRightPixIntensity,
                        bottomLeftPixIntensity, bottomRightPixIntensity);
                }
            }

            return downsizedColorPart;
        }

        private static float CalculatePixel(float xWeight, float yWeight, float topLeftPixIntensity, float topRightPixIntensity, float bottomLeftPixIntensity, float bottomRightPixIntensity)
        {
            return (1 - xWeight) * (1 - yWeight) * topLeftPixIntensity + xWeight * (1 - yWeight) * topRightPixIntensity + bottomLeftPixIntensity * yWeight * (1 - xWeight) + bottomRightPixIntensity * xWeight * yWeight;
        }

        public static void SaveDownSizedImage(byte[,] redResized, byte[,] greenResized, byte[,] blueResized, string path)
        {
            int rHeight = redResized.GetLength(0);
            int rWidth = redResized.GetLength(1);

            using (Image<Rgba32> resizedImage = new Image<Rgba32>(rWidth, rHeight))
            {
                for (int row = 0; row < rHeight; row++)
                {
                    for (int col = 0; col < rWidth; col++)
                    {
                        byte red = redResized[row, col];
                        byte green = greenResized[row, col];
                        byte blue = blueResized[row, col];
                        resizedImage[col, row] = new Rgba32(red, green, blue);
                    }
                }

                resizedImage.Save(path);
            }
        }

    }
}
