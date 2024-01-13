namespace Reportes.CLS
{
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;

    public class CrystalReportExporter
    {
        public void ExportToPDF(ReportDocument report, string filePath)
        {
            ExportOptions exportOptions = new ExportOptions();
            DiskFileDestinationOptions diskFileDestination = new DiskFileDestinationOptions();
            diskFileDestination.DiskFileName = filePath;
            exportOptions.ExportFormatType = ExportFormatType.PortableDocFormat; // XPS format
            exportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
            exportOptions.ExportDestinationOptions = diskFileDestination;
            report.Export(exportOptions);
        }
    }

}
