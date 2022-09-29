using OrderingSystem.Domain;
using OrderingSystem.Domain.Enums;
using OrderingSystem.Json;
using PdfSharpCore;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;

namespace OrderingSystem.Services;

public class PdfService
{
    private static ItemJsonLogic _itemJsonLogic = new ItemJsonLogic();
    
    private static XFont _companyNameFont = new XFont("Arial", 15, XFontStyle.Bold);
    private static XFont _addressFont = new XFont("JetBrains Mono", 10, XFontStyle.Regular);
    private static XFont _divider = new XFont("JetBrains Mono", 10, XFontStyle.Bold);
    private static XFont _billNumberFont = new XFont("JetBrains Mono", 8, XFontStyle.Bold);
    public static void CreatePdfBill(Bill bill)
    {
        var document = new PdfDocument();
        var page = document.AddPage();
        page.Size = PageSize.A6;

        var gfx = XGraphics.FromPdfPage(page);
        gfx.DrawString(bill.Company.Name, _companyNameFont, XBrushes.Black, new XRect(0,0,page.Width, 10), XStringFormats.TopCenter);
        gfx.DrawString(bill.Company.Street, _addressFont, XBrushes.Black, new XRect(0,15,page.Width, 10), XStringFormats.TopCenter);
        gfx.DrawString($"{bill.Company.ZipCode} {bill.Company.City}", _addressFont, XBrushes.Black, new XRect(0,25,page.Width, 10), XStringFormats.TopCenter);
        gfx.DrawString("________________________________________________________________________", _divider, XBrushes.Black, new XRect(0,27,page.Width, 5), XStringFormats.TopCenter);
        gfx.DrawString($"Bill-Number: {bill.BillNumber.ToString()}", _billNumberFont, XBrushes.Black, new XRect(5,40,page.Width, 5), XStringFormats.TopLeft);
        gfx.DrawString($"Register: {bill.RegisterId.ToString()}", _billNumberFont, XBrushes.Black, new XRect(5,50,page.Width, 5), XStringFormats.TopLeft);
        gfx.DrawString($"Date and Time: {bill.PrintDate}", _billNumberFont, XBrushes.Black, new XRect(5,60,page.Width, 5), XStringFormats.TopLeft);
        gfx.DrawString("Article", _billNumberFont, XBrushes.Black, new XRect(5,95,page.Width, 5), XStringFormats.TopLeft);
        gfx.DrawString("Price", _billNumberFont, XBrushes.Black, new XRect(110,95,page.Width, 5), XStringFormats.TopLeft);
        gfx.DrawString("Amount", _billNumberFont, XBrushes.Black, new XRect(150,95,page.Width, 5), XStringFormats.TopLeft);
        gfx.DrawString("Sum", _billNumberFont, XBrushes.Black, new XRect(200,95,page.Width, 5), XStringFormats.TopLeft);
        gfx.DrawString("_____________________________________", _divider, XBrushes.Black, new XRect(5,100,page.Width, 5), XStringFormats.TopLeft);

        var y = 115;
        foreach (var kvpItem in bill.SortedItems)
        {
            var item = _itemJsonLogic.GetSingle(kvpItem.Key);
            gfx.DrawString($"{item.Name}", _billNumberFont, XBrushes.Black, new XRect(5,y,page.Width, 5), XStringFormats.TopLeft);
            gfx.DrawString($"{String.Format("{0:0.00}", item.PriceInclTax)}", _billNumberFont, XBrushes.Black, new XRect(110,y,page.Width, 5), XStringFormats.TopLeft);
            gfx.DrawString($"{kvpItem.Value}", _billNumberFont, XBrushes.Black, new XRect(150,y,page.Width, 5), XStringFormats.TopLeft);
            gfx.DrawString($"{String.Format("{0:0.00}",item.PriceInclTax * kvpItem.Value)}", _billNumberFont, XBrushes.Black, new XRect(200,y,page.Width, 5), XStringFormats.TopLeft);
            y += 15;
        }
        
        gfx.DrawString("_____________________________________", _divider, XBrushes.Black, new XRect(5,300,page.Width, 5), XStringFormats.TopLeft);
        
        gfx.DrawString($"Incl. Tax: {String.Format("{0:0.00}",bill.Sum)}", _billNumberFont, XBrushes.Black, new XRect(5,310,page.Width, 5), XStringFormats.TopLeft);
        gfx.DrawString($"Excl. Tax: {String.Format("{0:0.00}",bill.SumExclTax)}", _billNumberFont, XBrushes.Black, new XRect(5,320,page.Width, 5), XStringFormats.TopLeft);
        gfx.DrawString($"Tax:       {String.Format("{0:0.00}",bill.Sum - bill.SumExclTax)}", _billNumberFont, XBrushes.Black, new XRect(5,330,page.Width, 5), XStringFormats.TopLeft);
        gfx.DrawString($"Method:    {bill.PaymentMethod}", _billNumberFont, XBrushes.Black, new XRect(5,340,page.Width, 5), XStringFormats.TopLeft);
        gfx.DrawString(bill.Company.UIdNumber, _billNumberFont, XBrushes.Black, new XRect(0,360,page.Width, 5), XStringFormats.TopCenter);
        
        document.Save($"C:/OrderingSystem/BillsPdfs/bill{bill.BillNumber}.pdf");
        
        
    }
}