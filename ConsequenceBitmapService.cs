using System.Drawing.Imaging;

namespace ImageDownsizer
{
    internal class ConsequenceBitmapService
    {
        public void DownscaleImage(string imagePath, string savePath, string percDownSize)
        {
            Bitmap image = new Bitmap(imagePath);
            double downSize = double.Parse(percDownSize) / 100.0;
            Bitmap compressedImage = BilinearInterpolation(image, downSize);
            compressedImage.Save(savePath);
        }

        private Bitmap BilinearInterpolation(Bitmap image, double downSize)
        {
            Bitmap resizedImage = CreateResizedBitmap(image, downSize);

            BitmapData originalData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height),
                ImageLockMode.ReadOnly, image.PixelFormat);

            BitmapData resizedImageData = resizedImage.LockBits(new Rectangle(0, 0, resizedImage.Width, resizedImage.Height),
                ImageLockMode.WriteOnly, image.PixelFormat);

            int bytesPerPixel = Image.GetPixelFormatSize(image.PixelFormat) / 8;

            unsafe
            {
                for (int x = 0; x < resizedImage.Width; x++)
                {
                    for (int y = 0; y < resizedImage.Height; y++)
                    {
                        IdentifyClosestPixels(x, y, originalData, resizedImageData, bytesPerPixel);
                    }
                }

            }

            image.UnlockBits(originalData);
            resizedImage.UnlockBits(resizedImageData);

            return resizedImage;
        }

        private unsafe static int[] CalculateRGB(int x, int y, BitmapData originalData, BitmapData downscaledData, int bytesPerPixel, float gx, float gy, int gxi, int gyi, int nextGxi, int nextGyi)
        {
            byte* firstPxO = (byte*)originalData.Scan0;
            Color[,] colorPosition = GetColor(originalData, bytesPerPixel, gxi, gyi, nextGxi, nextGyi, firstPxO);

            int red = calculateColorOfPixel(colorPosition[0, 0].R, colorPosition[1, 0].R, colorPosition[0, 1].R, colorPosition[1, 1].R, gx - gxi, gy - gyi);
            int green = calculateColorOfPixel(colorPosition[0, 0].G, colorPosition[1, 0].G, colorPosition[0, 1].G, colorPosition[1, 1].G, gx - gxi, gy - gyi);
            int blue = calculateColorOfPixel(colorPosition[0, 0].B, colorPosition[1, 0].B, colorPosition[0, 1].B, colorPosition[1, 1].B, gx - gxi, gy - gyi);

            return new int[] { red, green, blue };
        }

        private static unsafe Color[,] GetColor(BitmapData originalData, int bytesPerPixel, int gxi, int gyi, int nextGxi, int nextGyi, byte* firstPxO)
        {
            Color[,] colorPosition = new Color[2, 2];

            //the colfour nearest pixels surrounding the desired location in the source image
            colorPosition[0, 0] = GetPixel(firstPxO, gxi, gyi, originalData.Stride, bytesPerPixel);
            colorPosition[0, 1] = GetPixel(firstPxO, gxi, nextGyi, originalData.Stride, bytesPerPixel);
            colorPosition[1, 0] = GetPixel(firstPxO, nextGyi, gyi, originalData.Stride, bytesPerPixel);
            colorPosition[1, 1] = GetPixel(firstPxO, nextGxi, nextGyi, originalData.Stride, bytesPerPixel);
            return colorPosition;
        }

        public Bitmap CreateResizedBitmap(Bitmap image, double downsizeScale)
        {
            return new Bitmap((int)(image.Width * downsizeScale), (int)(image.Height * downsizeScale), image.PixelFormat);
        }

        private unsafe void IdentifyClosestPixels(int x, int y, BitmapData originalData, BitmapData downscaledData, int bytesPerPixel)
        {
            byte* firstPxDS = (byte*)downscaledData.Scan0;

            // identify the surrounding pixels needed for interpolation
            float fractionalX = x * originalData.Width / (float)downscaledData.Width;
            float fractionalY = y * originalData.Height / (float)downscaledData.Height;

            int floorFracX = (int)Math.Floor(fractionalX);
            int floorFracY = (int)Math.Floor(fractionalY);

            int nearestFracX = Math.Min(floorFracX + 1, originalData.Width - 1);
            int nearestFracY = Math.Min(floorFracY + 1, originalData.Height - 1);

            //0 -> R, 1 -> G, 2 -> B
            int[] RGB = CalculateRGB(x, y, originalData, downscaledData, bytesPerPixel, fractionalX, fractionalY, floorFracX, floorFracY, nearestFracX, nearestFracY);
            SetPixel(firstPxDS, x, y, downscaledData.Stride, bytesPerPixel, Color.FromArgb(RGB[0], RGB[1], RGB[2]));
        }



        private unsafe static Color GetPixel(byte* PtrFirstPixel, int x, int y, int stride, int bytesPerPixel)
        {
            byte* addressOfPixel = PtrFirstPixel + (y * stride) + (x * bytesPerPixel);
            if (bytesPerPixel == 3) 
            {
                return Color.FromArgb(*(addressOfPixel + 2), *(addressOfPixel + 1), *(addressOfPixel)); // BGR
            }
            //Handle other pixel formats here if necessary
            throw new FormatException("Only Format24bppRgb is supported.");
        }

        private unsafe static void SetPixel(byte* PtrFirstPixel, int x, int y, int stride, int bytesPerPixel, Color color)
        {  
            byte* addressOfPixel = PtrFirstPixel + (y * stride) + (x * bytesPerPixel);
            //set color
            if (bytesPerPixel == 3)
            {
                *(addressOfPixel) = color.B;
                *(addressOfPixel + 1) = color.G;
                *(addressOfPixel + 2) = color.R;

            }
        }

        //calculate the color of a pixel in a resized image
        private static int calculateColorOfPixel(float colorPos00, float colorPos10, float colorPos01, float colorPos11, float fractionalPosX, float fractionalPosY)
        {
            return (int)calculateLinearInterpolation(
                fractionalPosY,
               calculateLinearInterpolation(fractionalPosX, colorPos00, colorPos10),
               calculateLinearInterpolation(fractionalPosX, colorPos01, colorPos11)
            );
        }


        //finding a value between two points based on a ratio
        private static float calculateLinearInterpolation(float interpolationParam, float startValue, float endValue)
        {
            return startValue + (endValue - startValue) * interpolationParam;
        }

    }
}
