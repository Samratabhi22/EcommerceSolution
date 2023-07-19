using EcommerceProject.PageObjects;
using EcommerceProject.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceProject.TestScripts
{
    internal class E2ETest : BaseClass
    {
        [Test]
        public void EndToEndFlow()
        {
            String[] expectedProducts = { "iphone X", "Blackberry" };
            String[] actualProducts = new string[2];
            LoginPage login = new LoginPage(driver);
            login.validLogin("rahulshettyacademy", "learning");
            wdu.waitForPageDisplay(driver);
            ProductsPage productpage = new ProductsPage(driver);
            IList<IWebElement> products = productpage.getCards();

            foreach (IWebElement product in products)
            {

                if (expectedProducts.Contains(product.FindElement(productpage.getCardTitle()).Text))

                {
                    product.FindElement(productpage.addToCartButton()).Click();
                }

            }
            productpage.checkout();

            CheckoutPage checkoutpage = new CheckoutPage(driver);
            

           IList <IWebElement> checkoutCards = checkoutpage.getCards();

            for (int i = 0; i < checkoutCards.Count; i++)

            {
                actualProducts[i] = checkoutCards[i].Text;
            }
            Assert.AreEqual(expectedProducts, actualProducts);
            checkoutpage.checkOut();
            DeliveryLocationPage delivery=new DeliveryLocationPage(driver);
            String confirmText = delivery.selectLocation("ind");
           StringAssert.Contains("Success", confirmText);
        }
    }
}
