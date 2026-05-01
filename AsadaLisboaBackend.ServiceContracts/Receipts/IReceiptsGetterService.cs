using AsadaLisboaBackend.Models.DTOs.Receipt;

namespace AsadaLisboaBackend.ServiceContracts.Receipts
{
    public interface IReceiptsGetterService
    {
        public Task<ReceiptResponseDTO> GetReceipt(int receiptNumber);
        public Task<ReceiptDetailsResponseDTO> GetReceiptDetails(int receiptNumber, int index);
    }
}
