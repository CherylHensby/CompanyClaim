using CompanyClaimsAPI.Data.Interfaces;
using CompanyClaimsAPI.Models;
using Moq;

namespace CompanyClaimsAPI.Tests
{
    [TestClass]
    public class DataLayerTests
    {

        private readonly Mock<IDataLayer> _mockedDataLayer = new Mock<IDataLayer>();
  
        [TestMethod]
        public async void DataLayer_Claims_GetClaimByUcrAsync()
        {

            // Arrange
            string _ucr = "4444";
            Claim claim1 = new Claim() { AssuredName = "", Closed = false, UCR = _ucr };


            // Act
            var claimByUcr = _mockedDataLayer.Setup(c => c.GetClaimByUcrAsync("4444")).ReturnsAsync(claim1);


            // Assert

            Assert.Equals(_ucr, claim1.UCR);

        }
    }
}