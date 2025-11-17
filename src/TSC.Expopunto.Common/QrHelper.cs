using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using ZXing;
using ZXing.ImageSharp.Rendering;

namespace TSC.Expopunto.Common
{
    public static class QrHelper
    {
        public static byte[] Generar(string data)
        {
            var writer = new BarcodeWriter<Image<Rgba32>>
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 200,
                    Width = 200,
                    Margin = 0
                },
                Renderer = new ImageSharpRenderer<Rgba32>()
            };

            using Image<Rgba32> img = writer.Write(data);

            using var ms = new MemoryStream();
            img.Save(ms, new PngEncoder());

            return ms.ToArray();
        }
    }
}
