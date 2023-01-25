using Microsoft.AspNetCore.Mvc;
using Service.Services.Interfaces;

namespace Api.Controllers
{
    [Route("api/v1/pdf")]
    [ApiController]
    public class PdfController : ControllerBase
    {
        private readonly IPdfService pdfService;

        public PdfController(IPdfService pdfService) =>
            this.pdfService = pdfService;

        [HttpGet]
        public IActionResult Pdf() =>
            File(this.pdfService.CreatePdf(), "application/pdf", "report.pdf");
    }
}
