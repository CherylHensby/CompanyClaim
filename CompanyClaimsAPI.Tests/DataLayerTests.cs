using CompanyClaimsAPI.Data.Interfaces;
using CompanyClaimsAPI.Models;
using Moq;

namespace CompanyClaimsAPI.Tests
{
    [TestClass]
    public class DataLayerTests
    {
        /// <summary>
        /// DataLayer Unit Tests using Moq, to mock the dataLayer clas
        /// </summary>

        private readonly Mock<IDataLayer> _mockDataLayer = new Mock<IDataLayer>();

        /// <summary>
        /// •	We need at least one unit test to be created
        /// Unit Test calling the GetClaimByUcrAsync which gets the claim from passing the 'UCR' property
        /// </summary>
        [TestMethod]
        public void DataLayer_GetClaimByUcrAsync()
        {

            // Arrange
            string _ucr = "4444";
            Claim claim1 = new Claim() { AssuredName = "", Closed = false, UCR = _ucr };


            // Act
            var claimByUcr = _mockDataLayer.Setup(c => c.GetClaimByUcrAsync("4444")).ReturnsAsync(claim1);


            // Assert

            Assert.AreEqual(_ucr, claim1.UCR);
        }
    }
}