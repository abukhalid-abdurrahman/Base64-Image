using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Base64Image
{
    static class Program
    {
        static Bitmap Base64StringToBitmap(this string
                                           base64String)
        {
            Bitmap bmpReturn = null;

            byte[] byteBuffer = Convert.FromBase64String(base64String);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);

            memoryStream.Position = 0;

            bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);

            memoryStream.Close();
            memoryStream = null;
            byteBuffer = null;
            return bmpReturn;
        }

        static void Main(string[] args)
        {
            string base64Image = "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";
            Bitmap bmp = Base64StringToBitmap(base64Image);
            bmp.Save("image.jpg", ImageFormat.Jpeg);
        }
    }
}
