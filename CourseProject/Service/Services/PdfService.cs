using DinkToPdf.Contracts;
using DinkToPdf;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using Models.Entities;

namespace Service.Services
{
    public class PdfService : IPdfService
    {
        private readonly IConverter converter;
        private readonly IAnimeService animeService;

        public PdfService(IConverter converter, IAnimeService animeService)
        {
            this.converter = converter;
            this.animeService = animeService;
        }

        public byte[] CreatePdf()
        {
            var globalSettings = new GlobalSettings
            {
                ColorMode = ColorMode.Color,
                Orientation = Orientation.Portrait,
                PaperSize = PaperKind.A4,
                Margins = new MarginSettings { Top = 10 },
                DocumentTitle = "PDF Report"
            };
            var objectSettings = new ObjectSettings
            {
                PagesCount = true,
                HtmlContent = this.GetHTMLString(),
                WebSettings = { DefaultEncoding = "utf-8" },
                HeaderSettings = { FontName = "Arial" },
                FooterSettings = { FontName = "Arial" }
            };
            var pdf = new HtmlToPdfDocument()
            {
                GlobalSettings = globalSettings,
                Objects = { objectSettings }
            };

            return this.converter.Convert(pdf);
        }

        private IEnumerable<Anime> animes =>
            this.animeService.GetAll();

        private IEnumerable<IGrouping<string, Anime>> animeYearGroupings =>
            this.animes.GroupBy(a => a.StartDate is DateTime date ?
                date.Year.ToString() : "Not Yet Aired");

        private string GetHTMLString() =>
$@"<html>
    <head>
        <style>
            .header {{
                text-align: center;
                color: green;
                padding-bottom: 35px;
            }}

            table {{
                width: 80%;
                border-collapse: collapse;
                margin: 0 auto;
            }}

            td, th {{
                border: 1px solid gray;
                padding: 15px;
                font-size: 22px;
                text-align: center;
            }}

            table th {{
                background-color: green;
                color: white;
            }}
        </style>
    </head>
    <body>
        <div class='header'><h1>This is the generated PDF report!!!</h1></div>
        <table align='center'>
            <tr>
                <th>Entity</td>
                <th>Count</th>
            </tr>
            <tr>
                <td>Animes</td>
                <td>{ this.animes.Count() }</td>
            </tr>
        </table>

        <table align='center'>
            <tr>
                <th>Year</td>
                <th>Animes</th>
            </tr>
            { trTagForAnimeYear() }
        </table>
    </body>
</html>";

        private string trTagForAnimeYear()
        {
            var trs = this.animeYearGroupings.Select(x =>
                $@"
                    <tr>
                        <td>{x.Key}</td>
                        <td>{x.Count()}</td>
                    </tr>
                ");

            return string.Join("\n", trs);
        }
    }
}