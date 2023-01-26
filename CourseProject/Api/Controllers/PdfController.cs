namespace Api.Controllers
{
    using Service.Services.Interfaces;

    using Microsoft.AspNetCore.Mvc;

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
