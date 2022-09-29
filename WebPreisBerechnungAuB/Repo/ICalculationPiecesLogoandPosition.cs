using System.Collections.Generic;
using System.Threading.Tasks;
using WebPreisBerechnungAuB.Models;

namespace WebPreisBerechnungAuB.Repo
{
    public interface ICalculationPiecesLogoandPosition
    {
        double ApplicationTransferPrice(PositionLogo order, double logoSurfaceSize, int piecesOfTextilPositions);
        OneLogoAndPosition calc(int Logoid, int posId, List<PositionLogo> positionLogo);
        decimal calcTransferPrice(PositionLogo order, int piecesOfTextilPositions);
        Task<Models.Logo> CalculationLogoPrice(Models.Logo logo);
        void deleteOrderPositionLogos(int orderpositionId);
        decimal PricefromDb(PositionLogo order, int piecesOfTextilPositions);
        decimal priceOfPrint(PositionLogo order, int piecesOfTextilPositions);
        decimal PriceofTransfer(PositionLogo order, int piecesOfTextilPositions);
        decimal totalScreenprintPrice(PositionLogo order, int piecesOfTextilPositions, List<ExtraChargeList> extraChargeListPrice);
    }
}