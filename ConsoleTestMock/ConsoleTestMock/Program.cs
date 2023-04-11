using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace ConsoleTestMock
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var author = new Mock<IAuthor>();
            author.SetupGet(p => p.Id).Returns(1);
            author.SetupGet(p => p.FirstName).Returns("Joydip");
            author.SetupGet(p => p.LastName).Returns("Kanjilal");
          var obj=  author.Object;
            Assert.AreEqual("Joydip", author.Object.FirstName);*/
            var mockObj = new Mock<Article>();
            mockObj.Setup(x => x.GetPublicationDate(It.IsAny<int>())).Returns((int x) => DateTime.Now);
            mockObj.Verify(t => t.GetPublicationDate(It.IsAny<int>()));

        }
    }
}
