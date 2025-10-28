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

#if WINDOWS10_0_19041_0_OR_GREATER
            if (implementation is PrintingService service)
            {
                PrinterBase XpsToPdf(string title, string file)
                {
                    var path = Path.GetTempPath() + "temp.pdf";
                    PdfSharp.Xps.XpsConverter.Convert(file, path, 0);
                    return new PdfPrinter(PrintingService.GetActiveWindow(), title, path);
                }

                service.Entries.Add(".xps", XpsToPdf);
            }
#endif
            return builder;
        }
    }
}
