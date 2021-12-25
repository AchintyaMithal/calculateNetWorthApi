using NUnit.Framework;
using Module_3.Controllers;
using Module_3.Repository;
using Module_3.Models;
using Module_3.Services;
using System.Collections.Generic;
namespace NetWorthTests
{
    //public class CalculateNetWorthApiTests
    //{
    //    public List<PortfolioDetails> _portFolioDetails;
    //    public Cal netWorthProvider;
    //    private readonly Mock<INetWorthRepository> netWorthRepository = new Mock<INetWorthRepository>();
    //    private readonly Mock<INetWorthProvider> networthProviderMock = new Mock<INetWorthProvider>();
    //    public double networth;
    //    NetWorth netWorth;
    //    public NetWorthController networthController;
    //    AssetSaleResponse assetSaleResponse;

    //    public CalculateNetWorthApiTests()
    //    {
    //        netWorthProvider = new NetWorthProvider(netWorthRepository.Object);
    //        networthController = new NetWorthController(networthProviderMock.Object);
    //    }

    //    [SetUp]
    //    public void Setup()
    //    {

    //        networth = 10789.97;
    //        netWorth = new NetWorth();
    //        netWorth.Networth = networth;
    //        assetSaleResponse = new AssetSaleResponse() { SaleStatus = true, Networth = 12456.44 };
    //        _portFolioDetails = new List<PortFolioDetails>(){
    //            new PortFolioDetails
    //            {
    //                PortFolioId = 123,
    //                MutualFundList = new List<MutualFundDetails>()
    //                {
    //                    new MutualFundDetails{MutualFundName = "Cred", MutualFundUnits=3},
    //                    new MutualFundDetails{MutualFundName = "Viva", MutualFundUnits=5}
    //                },
    //                StockList = new List<StockDetails>()
    //                {
    //                    new StockDetails{StockCount = 1, StockName = "BTC"},
    //                    new StockDetails{StockCount = 6, StockName = "ETH"}
    //                }
    //            },
    //            new PortFolioDetails
    //            {
    //                PortFolioId = 12345,
    //                MutualFundList = new List<MutualFundDetails>()
    //                {
    //                    new MutualFundDetails{MutualFundName = "Cred", MutualFundUnits=1},
    //                    new MutualFundDetails{MutualFundName = "Viva", MutualFundUnits=1}
    //                },
    //                StockList = new List<StockDetails>()
    //                {
    //                    new StockDetails{StockCount = 1, StockName = "BTC"},
    //                    new StockDetails{StockCount = 2, StockName = "ETH"}
    //                }
    //            }
    //        };
    //    }

        public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}