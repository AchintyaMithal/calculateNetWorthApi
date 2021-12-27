using System.Collections.Generic;
using NUnit.Framework;
using Module_3.Models;
using Module_3.Services;
using Module_3.Repository;
using Module_3.Controllers;
using Moq;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
namespace Networthtests
{
    public class Tests
    {
        public List<PortfolioDetails> portFolioDetails;
        private readonly Mock<ICalculateNetWorthService> netWorthservice = new Mock<ICalculateNetWorthService>();
        private readonly Mock<ISellAssetsRepository> sellrepo = new Mock<ISellAssetsRepository>();
        private int networth;
        private readonly CalculateNetWorthController networthController;
        AssetSaleResponse assetSaleResponse;
        private PortfolioDetails portfolioDetails;
        private readonly CalculateNetWorthService netservice;
        private readonly SellAssetsRepository sellasset;
        public Tests()
        {
            networthController = new CalculateNetWorthController(netWorthservice.Object, sellrepo.Object);
        }

        [SetUp]
        public void Setup()
        {
            networth = 10789;

            assetSaleResponse = new AssetSaleResponse() { SaleStatus = true, NetWorth = 12456 };
            portFolioDetails = new List<PortfolioDetails>(){
                new PortfolioDetails
                {
                    portFolioid = 123,
                    MutualFundList = new List<MutualFundDetails>()
                    {
                        new MutualFundDetails{MutualFundName = "HDFC", MutualFundUnits=1},
                        new MutualFundDetails{MutualFundName = "AXIS", MutualFundUnits=1}
                    },
                    StockList = new List<StockDetails>()
                    {
                        new StockDetails{StockCount = 1, StockName = "HDFC"},
                        new StockDetails{StockCount = 1, StockName = "AXIS"}
                    },
                    AssetNameToBeSold = "HDFC",
                    AssetTypeToBeSold ="Stock",
                    NetWorth = 30030
                },
                new PortfolioDetails
                {
                    portFolioid = 12345,
                    MutualFundList = new List<MutualFundDetails>()
                    {
                        new MutualFundDetails{MutualFundName = "Cred", MutualFundUnits=1},
                        new MutualFundDetails{MutualFundName = "Viva", MutualFundUnits=1}
                    },
                    StockList = new List<StockDetails>()
                    {
                        new StockDetails{StockCount = 1, StockName = "BTC"},
                        new StockDetails{StockCount = 2, StockName = "ETH"}
                    },
                    AssetNameToBeSold = "Cred",
                    AssetTypeToBeSold = "MutualFund",
                    NetWorth = 1250

                }
            };

        }
        // TestCases for networthService
        [TestCase("12345")]
        public void GetDetailsByValidId_Returns_PortfolioDetails(int id)
        {
            netWorthservice.Setup(x => x.GetPortFolioDetailsByID(It.IsAny<int>())).Returns((int id) => portFolioDetails.FirstOrDefault(e => e.portFolioid == id));
            var res = networthController.GetNetWorth(id);
            ObjectResult okresult = res as ObjectResult;
            Assert.AreEqual(200, okresult.StatusCode);

        }

        [TestCase("1234")]
        public void GetDetailsByInvalidId_Returns_Null(int id)
        {
            netWorthservice.Setup(x => x.GetPortFolioDetailsByID(It.IsAny<int>())).Returns((int Id) => portFolioDetails.FirstOrDefault(e => e.portFolioid == id));
            var res = networthController.GetNetWorth(id);
            ObjectResult okresult = res as ObjectResult;
            Assert.AreEqual(404, okresult.StatusCode);
        }

        [Test]
        public void CalculateNetworthWhenObjecthasvalues_Return_Networth()
        {   
            netWorthservice.Setup(x => x.CalculateNetWorth(portFolioDetails[0])).Returns(networth);
            PortfolioDetails port = new PortfolioDetails();
            port = portFolioDetails[0];
            var result = netservice.CalculateNetWorth(port);
            Assert.AreEqual(result, networth);
        }


        // Tests for Sell Repository
        [Test]
        public void TestforObjecthasvaluesinRepo()
        {
            //PortfolioDetails port = new PortfolioDetails();
            //port = portFolioDetails[0];
            sellrepo.Setup(x => x.SellAsset(portfolioDetails)).Returns(assetSaleResponse);
            PortfolioDetails port = new PortfolioDetails();

            var res = sellasset.SellAsset(port);
            // ObjectResult okresult = res as ObjectResult;
            Assert.AreEqual(res, assetSaleResponse);

        }
        [Test]
        public void TestforObjecthasNovaluesinRepo()
        {
            PortfolioDetails port = new PortfolioDetails();
            port = portFolioDetails[0];
            sellrepo.Setup(x => x.SellAsset(portfolioDetails)).Returns(() => null);
            Class cl = new Class();
            var result = networthController.SellAsset(cl);
            ObjectResult res = result as ObjectResult;
            Assert.AreEqual(404, res.StatusCode);
        }



    }
}