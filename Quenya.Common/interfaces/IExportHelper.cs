using Quenya.Domain;

namespace Quenya.Common.interfaces
{
    public interface IExportHelper
    {
        public StatusMessage ExportToPdf(Overview data);
    }
}
