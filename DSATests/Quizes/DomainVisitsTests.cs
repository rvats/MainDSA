using MainDSA.Quizes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DSATests.Quizes
{
    [TestClass]
    public class DomainVisitsTests
    {
        public string[] cpDomains1;
        public string[] cpDomains2;

        [TestInitialize]
        public void CreateTestData()
        {
            cpDomains1 = new string[] { "10000 google.com", "50 yahoo.com" };
            cpDomains2 = new string[] { "900 google.mail.com", "50 yahoo.com", "1 intel.mail.com", "5 wiki.org" };
        }

        [TestMethod]
        public void TestSubdomainVisitsCase1()
        {
            // Arrange 
            CreateTestData();

            // Act
            var subDomainsVisit = DomainVisits.SubdomainVisits(cpDomains1);

            // Assert
            Assert.AreEqual("10000 google.com", subDomainsVisit[0], "Different Value Expected");
            Assert.AreEqual("10050 com", subDomainsVisit[1], "Different Value Expected");
            Assert.AreEqual("50 yahoo.com", subDomainsVisit[2], "Different Value Expected");
        }

        [TestMethod]
        public void TestSubdomainVisitsCase2()
        {
            // Arrange 
            CreateTestData();

            // Act
            var subDomainsVisit = DomainVisits.SubdomainVisits(cpDomains2);

            // Assert
            Assert.AreEqual("900 google.mail.com", subDomainsVisit[0], "Different Value Expected");
            Assert.AreEqual("901 mail.com", subDomainsVisit[1], "Different Value Expected");
            Assert.AreEqual("951 com", subDomainsVisit[2], "Different Value Expected");
            Assert.AreEqual("50 yahoo.com", subDomainsVisit[3], "Different Value Expected");
            Assert.AreEqual("1 intel.mail.com", subDomainsVisit[4], "Different Value Expected");
            Assert.AreEqual("5 wiki.org", subDomainsVisit[5], "Different Value Expected");
            Assert.AreEqual("5 org", subDomainsVisit[6], "Different Value Expected");
        }
    }
}
