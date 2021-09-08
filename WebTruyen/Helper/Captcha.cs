using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace WebTruyen.Helper
{
    public class Captcha
    {
        public string captchaText;
        public Captcha()
        {
            captchaText = randomString();
        }
        private String randomString()
        {
            char[] t = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM1234567890".ToCharArray();
            Random random = new Random();
            t = t.OrderBy(x => random.Next()).ToArray();
            string text = new string(t);
            text = text.Substring(0, 6);
            return text;

        }
        private Bitmap drawImage(string txt, int w, int h)
        {
            Bitmap bt = new Bitmap(w, h);
            Graphics g = Graphics.FromImage(bt);
            SolidBrush sb = new SolidBrush(Color.White);
            g.FillRectangle(sb, 0, 0, bt.Width, bt.Height);
            System.Drawing.Font font = new System.Drawing.Font("Tahoma", 30);
            sb = new SolidBrush(Color.Blue);
            g.DrawString(txt, font, sb, bt.Width / 2 - (txt.Length / 2) * font.Size, (bt.Height / 2) - font.Size);
            // Tạo hiệu ứng cho captcha
            // vẽ dấu chấm
            int count = 0;
            Random rand = new Random();
            while (count < 1000)
            {
                sb = new SolidBrush(Color.YellowGreen);
                g.FillEllipse(sb, rand.Next(0, bt.Width), rand.Next(0, bt.Height), 4, 2);
                count++;
            }
            count = 0;
            // vẽ đường gạch ngang
            while (count < 25)
            {
                g.DrawLine(new Pen(Color.Pink), rand.Next(0, bt.Width), rand.Next(0, bt.Height), rand.Next(0, bt.Width), rand.Next(0, bt.Height));
                count++;
            }
            // End tạo hiệu ứng
            return bt;
        }
        public string Img()
        {
            // vẽ captcha lên panel 1
            Image image = (Image)drawImage(captchaText, 200, 100);
            byte[] imgBytes = turnImageToByteArray(image);
            string imgString = Convert.ToBase64String(imgBytes);
            return $"data:image/Bmp;base64,{imgString}";
        }
        private byte[] turnImageToByteArray(System.Drawing.Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            return ms.ToArray();
        }
    }
}