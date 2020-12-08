using Quenya.Domain;

namespace Quenya.Common.interfaces
{
    public interface IExportHelper
    {
        StatusMessage ExportToPdf(Overview data);
    }
}
