using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace CrearQR
{
    class Program
    {
        static void Main(string[] args)
        {
            //Install-Package iTextSharp -Version 5.5.13.3
            Document doc = new Document(PageSize.A4);
            PdfWriter.GetInstance(doc, new FileStream(@"C:\Zamir\ejemplo3.pdf", FileMode.Create));

            doc.Open();            

            BarcodePDF417 barcodePDF417 = new BarcodePDF417();
            barcodePDF417.SetText("Esto es otro ejemplo de código de barras");
            Image codePDF417Image = barcodePDF417.GetImage();
            codePDF417Image.ScaleAbsolute(500, 200);
            doc.Add(codePDF417Image);

            BarcodeQRCode barcodeQRCode = new BarcodeQRCode("Un ejemplo de código qr", 1000, 1000, null);
            Image codeQRImage = barcodeQRCode.GetImage();
            codeQRImage.ScaleAbsolute(200, 200);
            doc.Add(codeQRImage);

            doc.Close();
        }
    }
}
