using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using salesOrderApi.Entity;
using salesOrderApi.Repository.IRepository;
using PdfSharpCore;
using PdfSharpCore.Pdf;
using TheArtOfDev.HtmlRenderer.PdfSharp;

namespace salesOrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IWebHostEnvironment environment;

        public InvoiceController(IInvoiceRepository invoiceRepository, IWebHostEnvironment environment)
        {
            _invoiceRepository = invoiceRepository;
            this.environment = environment;
        }

        [HttpGet ("GetAllHeader")]
        public async Task<List<InvoiceHeader>> GetAllHeader()
        {
            return await _invoiceRepository.GetAllInvoiceHeader();
        }

        [HttpGet ("GetHeaderByCode")]
        public async Task<InvoiceHeader> GetInvoiceHeaderByCode(string invoiceNo)
        {
            return await _invoiceRepository.GetInvoiceHeaderByCode(invoiceNo);
        }

        [HttpGet ("GetAllDetailByCode")]
        public async Task<List<InvoiceDetail>> GetAllDetailByCode(string invoiceNo)
        {
            return await _invoiceRepository.GetAllInvoiceDetailByCode(invoiceNo);
        }

        [HttpPost ("Save")]
        public async Task<ResponseType> Save([FromBody] InvoiceInput invoiceEntity)
        {
            return await _invoiceRepository.Save(invoiceEntity);
        }

        [HttpDelete("Remove")]
        public async Task<ResponseType> Remove(string InvoiceNo)
        {
            return await _invoiceRepository.Remove(InvoiceNo);

        }

        [HttpGet("generatepdf")]
        public async Task<IActionResult> GeneratePDF(string InvoiceNo)
        {
            var document = new PdfDocument();
            string imgurl = "data:imgage/png;base64," + GetBase64String() + "";

            string[] copies = { "Customer copy", "Company Copy" };
            for (int i = 0; i < copies.Length; i++)
            {
                InvoiceHeader header = await this._invoiceRepository.GetInvoiceHeaderByCode(InvoiceNo);
                List<InvoiceDetail> details = await this._invoiceRepository.GetAllInvoiceDetailByCode(InvoiceNo);
                string htmlContent = "<div style='width:100%; text-aling:center'>";
                htmlContent += "<img style='width:80px; height:80%' src='" + imgurl + "' />";
                htmlContent += "<h2>" + copies[i] + "</h2>";
                htmlContent += "<h2> Welcome to Enzo Sanabria</h2>";


                if(header != null)
                {
                    htmlContent += "<h2> Invoice No:" + header.InvoiceNo + "& Invoice Date:" + header.InvoiceDate + "</h2>";
                    htmlContent += "<h3> Customer : " + header.CustomerName + "</h3>";
                    htmlContent += "<p>" + header.DeliveryAddress + "</p>";
                    htmlContent += "<h3> Contact : 9898989898 & Email :ts@in.com </h3>";
                    htmlContent += "<div/>";
                }

                htmlContent += "<table style='width:100%; border: 1px solid #000'>";
                htmlContent += "<thead style='font-weight:bold'>";
                htmlContent += "<tr>";
                htmlContent += "<td style='border:1px solid: #000'> Product Code </td>";
                htmlContent += "<td style='border:1px solid #000'> Qty </td>";
                htmlContent += "<td style='border:1px solid #000'>Price</td >";
                htmlContent += "<td style='border:1px solid #000'>Total</td>";
                htmlContent += "</tr>";
                htmlContent += "</thead >";

                htmlContent += "<tbody>";
                if (details != null && details.Count > 0)
                {
                    details.ForEach(item =>
                    {
                        htmlContent += "<tr>";
                        htmlContent += "<td>" + item.ProductCode + "</td>";
                        htmlContent += "<td>" + item.ProductName + "</td>";
                        htmlContent += "<td>" + item.Qty + "</td >";
                        htmlContent += "<td>" + item.SalesPrice + "</td>";
                        htmlContent += "<td> " + item.Total + "</td >";
                        htmlContent += "</tr>";
                    });
                }
                htmlContent += "</tbody>";

                htmlContent += "</table>";
                htmlContent += "</div>";

                htmlContent += "<div style='text-align:right'>";
                htmlContent += "<h1> Summary Info </h1>";
                htmlContent += "<table style='border:1px solid #000;float:right' >";
                htmlContent += "<tr>";
                htmlContent += "<td style='border:1px solid #000'> Summary Total </td>";
                htmlContent += "<td style='border:1px solid #000'> Summary Tax </td>";
                htmlContent += "<td style='border:1px solid #000'> Summary NetTotal </td>";
                htmlContent += "</tr>";
                if (header != null)
                {
                    htmlContent += "<tr>";
                    htmlContent += "<td style='border: 1px solid #000'> " + header.Total + " </td>";
                    htmlContent += "<td style='border: 1px solid #000'>" + header.Tax + "</td>";
                    htmlContent += "<td style='border: 1px solid #000'> " + header.NetTotal + "</td>";
                    htmlContent += "</tr>";
                }
                htmlContent += "</table>";
                htmlContent += "</div>";

                htmlContent += "</div>";

                PdfGenerator.AddPdfPages(document, htmlContent, PageSize.A4);

            }
            byte[]? response = null;
            using (MemoryStream ms = new MemoryStream())
            {
                document.Save(ms);
                response = ms.ToArray();
            }
            string Filename = "Invoice_" + InvoiceNo + ".pdf";
            return File(response, "application/pdf", Filename);

        }

        [HttpGet ("generateaddresspdf")]
        public async Task<IActionResult> generateaddresspdf()
        {
            var document = new PdfDocument();
            List<InvoiceHeader> invoiceList = await this._invoiceRepository.GetAllInvoiceHeader();
            int processCount =0;
            int breakcount = 0;
            string htmlContent = String.Empty;
            invoiceList.ForEach(item =>
            {
                htmlContent += "<div style='width:100%;padding:5px;margin:5px;border:1px solid #ccc'>";
                htmlContent += "<h1>" + item.CustomerName + " [<b>" + item.InvoiceNo + "</b>]</h1>";
                htmlContent += "<h2>" + item.DeliveryAddress + "</h2>";
                htmlContent += "<h2>Payable Amount" + item.NetTotal + "</h2>";
                htmlContent += "</div>";
                processCount++;
                breakcount++;
                if (breakcount == 4)
                {

                    PdfGenerator.AddPdfPages(document, htmlContent, PageSize.A4);
                    breakcount = 0;
                    htmlContent = String.Empty;
                }
                else if (processCount == invoiceList.Count)
                {
                    PdfGenerator.AddPdfPages(document, htmlContent, PageSize.A4);
                }
            });
            byte[]? response = null;
            using (MemoryStream ms = new MemoryStream())
            {
                document.Save(ms);
                response = ms.ToArray();
            }
            string Filename = "Invoice_Address.pdf";
            return File(response, "application/pdf", Filename);
        }

        [HttpGet("GenPDFwithImage")]
        public async Task<IActionResult> GenPDFwithImage()
        {
            var document = new PdfDocument();
            string htmlelement = "<div style='width:100%'>";
            // string imgeurl = "https://res.cloudinary.com/demo/image/upload/v1312461204/sample.jpg";
            //string imgeurl = "https://" + HttpContext.Request.Host.Value + "/Uploads/common/logo.jpeg";
            string imgeurl = "data:image/png;base64, " + GetBase64String() + "";
            htmlelement += "<img style='width:80px;height:80%' src='" + imgeurl + "'   />";
            htmlelement += "<h2>Welcome to Nihira Techiees</h2>";
            htmlelement += "</div>";
            PdfGenerator.AddPdfPages(document, htmlelement, PageSize.A4);
            byte[] response = null;
            using (MemoryStream ms = new MemoryStream())
            {
                document.Save(ms);
                response = ms.ToArray();
            }
            return File(response, "application/pdf", "PDFwithImage.pdf");

        }

        [NonAction]
        public string GetBase64String()
        {
            string filePath = this.environment.WebRootPath + "\\Uploads\\common\\logo.jpeg";
            byte[] imgArray = System.IO.File.ReadAllBytes(filePath);
            string base64 = Convert.ToBase64String(imgArray);
            return base64;
        }


    }
}
