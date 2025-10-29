using Avalonia;

namespace Avae.Printables
{
    public static class Extensions
    {
        public static AppBuilder UseXpsPrintables(this AppBuilder builder)
        {
            var implementation = Printable.Default;
            if(implementation is null)
                throw new ArgumentNullException(nameof(implementation), "UsePrintables must be set before.");

            if (implementation is PrintingService service)
            {
                string ConvertXpsToPdf(string file)
                {
                    var path = Path.GetTempPath() + "temp.pdf";
                    PdfSharp.Xps.XpsConverter.Convert(file, path, 0);
                    return path;
                }
                service.Conversions.Add(".xps", (file) => Task.FromResult(ConvertXpsToPdf(file)));
                service.Entries.Add(".xps", (title, file) => Task.FromResult<PrinterBase>(new PdfPrinter(PrintingService.GetActiveWindow(), title, ConvertXpsToPdf(file))));
            }

            return builder;
        }
    }
}
