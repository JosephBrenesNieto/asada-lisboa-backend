using AsadaLisboaBackend.Models.DTOs.Receipt;
using AsadaLisboaBackend.ServiceContracts.Receipts;

namespace AsadaLisboaBackend.Services.Receipts
{
    public partial class ReceiptsGetterService : IReceiptsGetterService
    {
        public Task<ReceiptResponseDTO> GetReceipt(int receiptNumber)
        {
            return GetReceiptInternal(receiptNumber);
        }

        public Task<ReceiptDetailsResponseDTO> GetReceiptDetails(int receiptNumber, int index)
        {
            return GetReceiptDetailsInternal(receiptNumber, index);
        }
    }
}
