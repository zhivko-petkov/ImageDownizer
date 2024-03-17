# ImageDownsizer 🖼️
University WinForm image downsize application

# Description ℹ️
C# WinForms application which down-sizes images. The app users can select an image using the standard open file dialog, enter a downscaling factor (real number), and produce a new downscaled image. WinForm includes image file upload, save, select downsize % and image box (presents processed image). 

# Architecture 🔨
There are 3 services which are ConsequentialService, ConsequentialBitmapService and ParallelService which include the business logic of our functionalities. I use the needed objects for properly decoding and loading the image in its file format. After that, I used bilinear interpolation to downsize the image. 

# Used algorithms and materials 🧾
https://www.codeproject.com/Articles/5312360/2-D-Interpolation-Functions

https://www.omnicalculator.com/math/bilinear-interpolation

https://www.cambridgeincolour.com/tutorials/image-resize-for-web.htm

https://medium.com/@sim30217/bilinear-interpolation-e41fc8b63fb4