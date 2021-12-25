using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Module_3.Services;
using Module_3.Models;
using Microsoft.Extensions.Configuration;
using Module_3.Repository;

namespace Module_3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculateNetWorthController : ControllerBase
    {
        private readonly ICalculateNetWorthService _netWorthService;
        private readonly ISellAssetsRepository _sellAssetRepository;


        public CalculateNetWorthController(ICalculateNetWorthService netWorthService, 
            ISellAssetsRepository sellAssetRepository)
        {
            _netWorthService = netWorthService;
            _sellAssetRepository = sellAssetRepository;
        }
        //[HttpGet("portFolioid")]
        ////[Route("netWorth")]
        //public ActionResult Get(int portFolioId)
        //{
        //    PortfolioDetails portFolioDetails = new PortfolioDetails();
        //    try
        //    {
        //        if (portFolioId <= 0)
        //        {
        //            return NotFound("ID can't be 0 or less than 0");
        //        }
        //        portFolioDetails = _netWorthService.GetPortFolioDetailsByID(portFolioId);
        //        if (portFolioDetails == null)
        //        {
        //            return NotFound("Sorry, We don't have a portfolio with that ID");
        //        }
        //        else
        //        {
        //            return Ok(portFolioDetails);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return new StatusCodeResult(500);
        //    }
        //}

        [HttpGet]
        [Route("netWorth")]
        public ActionResult GetNetWorth( int portFolioId)
        {
            PortfolioDetails portFolioDetails = new PortfolioDetails();
            try
            {
                if (portFolioId <= 0)
                {
                    return NotFound("ID can't be 0 or less than 0");
                }
                portFolioDetails = _netWorthService.GetPortFolioDetailsByID(portFolioId);
                if (portFolioDetails == null)
                {
                    return NotFound("Sorry, We don't have a portfolio with that ID");
                }
                else
                {
                    int netWorth = _netWorthService.CalculateNetWorth(portFolioDetails);
                    portFolioDetails.NetWorth = netWorth;
                    
                    return Ok(portFolioDetails);
                }
            }
            catch (Exception )
            {
                return new StatusCodeResult(500);
            }
           
        }

        [HttpPost]
        [Route("sellAsset")]

        public IActionResult SellAsset([FromBody] Class c)
        {
            PortfolioDetails portfolioDetails = new PortfolioDetails();
            
            portfolioDetails = _netWorthService.GetPortFolioDetailsByID(c.portFolioId);
            portfolioDetails.AssetTypeToBeSold = c.AssetType;
            portfolioDetails.AssetNameToBeSold = c.AssetName;
            AssetSaleResponse assetSaleResponse = _sellAssetRepository.SellAsset(portfolioDetails);

            if (assetSaleResponse != null)
            {
                return Ok(assetSaleResponse);
               // return NoContent();
            }

            return NoContent();
        }
    }
}
