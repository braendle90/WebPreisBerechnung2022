using Microsoft.EntityFrameworkCore;
using WebPreisBerechnungAuB.Data;
using WebPreisBerechnungAuB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebPreisBerechnungAuB.Repo
{
    public class CalculationPiecesLogoandPosition : ICalculationPiecesLogoandPosition
    {

        private ApplicationDbContext _context;

        public CalculationPiecesLogoandPosition(ApplicationDbContext context)
        {
            this._context = context;
        }





        public OneLogoAndPosition calc(int Logoid, int posId, List<PositionLogo> positionLogo)
        {


            var positionLogosList = positionLogo
                .Where(x => x.Logo.Id == Logoid)
                .Where(x => x.Position.Id == posId)
                .ToList();

            /*int posId = 1; *///Diese id ist die ID für die Position z.B. Br.Links

            var orderListe = new List<Order>();

            var positionAndLogo = positionLogosList
                 .Where(x => x.Logo.Id == Logoid)
                .FirstOrDefault();


            WebPreisBerechnungAuB.Models.Logo logo = null;
            Position position = null;


            foreach (var item in positionLogosList)
            {
                if (item.Position.Id == posId)
                {
                    logo = positionAndLogo.Logo;
                    position = item.Position;
                    orderListe.Add(item.OrderPositionLogo.Order);
                }
            }

            int StückZahlTexitlien = 0;
            foreach (var item in orderListe)
            {
                StückZahlTexitlien += item.NumberOfPieces;
            }

            var onedataset = new OneLogoAndPosition
            {
                Logo = logo,
                Position = position,
                Pieces = StückZahlTexitlien,
                PositionLogoList = positionLogosList
            };


            if (StückZahlTexitlien == 0)
            {
                return null;
            }

            return onedataset;

        }


        public decimal priceOfPrint(PositionLogo order, int piecesOfTextilPositions)
        {
            var OneLogoandPositionPrice = PricefromDb(order, piecesOfTextilPositions);

            var price = order.OrderPositionLogo.Order.NumberOfPieces * OneLogoandPositionPrice;


            return price;

        }

        public decimal totalScreenprintPrice(PositionLogo order, int piecesOfTextilPositions, List<ExtraChargeList> extraChargeListPrice)
        {
            var priceExtra = extraChargeListPrice.Sum(x => x.ExtraCharge.ChargePrice);

            var OneLogoandPositionPrice = PricefromDb(order, piecesOfTextilPositions);

            var price = order.OrderPositionLogo.Order.NumberOfPieces * OneLogoandPositionPrice;

            price = price + priceExtra;


            return price;
        }

        public async Task<WebPreisBerechnungAuB.Models.Logo> CalculationLogoPrice(WebPreisBerechnungAuB.Models.Logo logo)
        {
            var pricePerScreen = await _context.ExtraCharge.Where(x => x.Id == 1).FirstOrDefaultAsync();

            logo.LogoPrice = logo.Color.NumberOfColors * pricePerScreen.ChargePrice;
            logo.PricePerScreen = pricePerScreen.ChargePrice;

            _context.Update(logo);
            await _context.SaveChangesAsync();

            return logo;
        }


        public decimal PriceofTransfer(PositionLogo order, int piecesOfTextilPositions)
        {
            decimal price = 0.0m;

            var TransferHight = order.Logo.SurfaceHight;
            var TransferWidth = order.Logo.SurfaceWidht;
            var piecesOfTextil = order.OrderPositionLogo.Order.NumberOfPieces;

            var logoSurfaceSize = TransferHight * TransferWidth;
            order.Logo.LogoSurfaceSize = logoSurfaceSize;


            WebPreisBerechnungAuB.Models.Logo logoupdate = order.Logo;
            logoupdate.LogoSurfaceSize = logoSurfaceSize;
            decimal calcPrice = (decimal)calcTransferPrice(order, piecesOfTextilPositions);




            // á Price for Apllication the Transfer to the Textil 

            // decimal applicationPrice = (decimal)ApplicationTransferPrice(order, logoSurfaceSize, piecesOfTextilPositions);




            var LogoPriceWithApplication = ((calcPrice / piecesOfTextil) + 0) * piecesOfTextil;
            logoupdate.TransferLogoPrice = LogoPriceWithApplication;



            _context.Update(logoupdate);
            _context.SaveChanges();

            return LogoPriceWithApplication;
        }

        public double ApplicationTransferPrice(PositionLogo order, double logoSurfaceSize, int piecesOfTextilPositions)
        {

            double price;

            //var modelFromDB = _context.ApplicationTransfer
            //    .Where(x => x.From <= logoSurfaceSize)
            //    .Where(x => x.To >= logoSurfaceSize)
            //    .Where(x => x.PiecesFrom <= piecesOfTextilPositions)
            //    .Where(x => x.PiecesFrom >= piecesOfTextilPositions)
            //    .FirstOrDefault();

            var modelFromDB = _context.ApplicationTransfer
                    .Where(x => x.From <= logoSurfaceSize && x.To >= logoSurfaceSize)
                    .Where(x => x.PiecesFrom <= piecesOfTextilPositions && x.PiecesTo >= piecesOfTextilPositions)
                    .FirstOrDefault();

            price = modelFromDB.ApplicationPrice;

            return price;
        }

        public decimal PricefromDb(PositionLogo order, int piecesOfTextilPositions)
        {
            var numberOfColors = order.Logo.Color.NumberOfColors;

            if (order.OrderPositionLogo.Order.TextilColor.IsPriceHigher)
            {
                numberOfColors += 1;
            }




            var priceTable = _context.PriceTable
                .Include(x => x.Range)
                .Include(x => x.Texil)
                .Include(x => x.NumberColors)
                .Where(x => x.Range.RangeFrom <= piecesOfTextilPositions)
                .Where(x => x.Range.RangeTo >= piecesOfTextilPositions)
                .Where(x => x.Texil == order.OrderPositionLogo.Order.Textil)
                .Where(x => x.NumberColors.NumberOfColors == numberOfColors)
                .FirstOrDefault();

            decimal price = priceTable.Price;

            var changeIsLogoStorage = _context.Logos.Where(x => x == order.Logo).FirstOrDefault();


            // Setzt die Schablonen Lagerstand Auf Lagernd 

            //if (order.Logo.isLogoStorage == false /*|| order.Logo.isOld == false*/)
            //{

            //    var numberofColors = order.Logo.Color.NumberOfColors;
            //    var LogoCost = numberofColors * 52;
            //    var piecesOfOrder = order.OrderPositionLogo.Order.NumberOfPieces;
            //    price = ((price * piecesOfOrder) + LogoCost) / piecesOfOrder;

            //    //change the Storage to True wenn the Order is submited

            //    changeIsLogoStorage.isLogoStorage = true;

            //}

            _context.Update(changeIsLogoStorage);
            _context.SaveChanges();


            return price;
        }

        public decimal calcTransferPrice(PositionLogo order, int piecesOfTextilPositions)
        {




            var hight = order.Logo.SurfaceHight / 10;
            var width = order.Logo.SurfaceWidht / 10;

            var surfaceSize = hight * width;

            var PiecesOfLogoOnSamePositionSize = surfaceSize * piecesOfTextilPositions;

            var logoSurfaceSizeWithPieces = (order.OrderPositionLogo.Order.NumberOfPieces * surfaceSize);

            var multiply = _context.PriceTableTransfer
                .Include(x => x.RangeLogo)
                .Where(x => x.RangeLogo.SurfaceSizeFrom <= PiecesOfLogoOnSamePositionSize)
                .Where(x => x.RangeLogo.SurfaceSizeTo >= PiecesOfLogoOnSamePositionSize)
                .FirstOrDefault();


            decimal priceTansfer = ((decimal)logoSurfaceSizeWithPieces / 10) * (decimal)multiply.Price;

            if (multiply.Price >= 0.19)
            {
                priceTansfer += 25;
            }

            return priceTansfer;



        }

        public void deleteOrderPositionLogos(int orderpositionId)
        {

            var delteOrderPosition = _context.OrderPositionLogos
                .Include(x => x.Order)
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == orderpositionId);

            delteOrderPosition.Order = null;

            _context.OrderPositionLogos.Update(delteOrderPosition);

            _context.SaveChanges();


        }




    }



}
