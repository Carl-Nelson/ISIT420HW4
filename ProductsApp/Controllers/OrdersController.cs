
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Mvc;  // need to add that 

namespace ProductsApp.Controllers
{
    public class OrdersController : ApiController
    {

        OrdersDBEntities ordersDB = new OrdersDBEntities();

        //the names for many of the tables are weird. Tables shouldn't have table in the name dang it
        public IEnumerable<string> GetSalespeople()
        {
            var result =
               (from salespeople in ordersDB.SalesPersonTables
                select salespeople.FirstName + " " + salespeople.LastName).AsEnumerable();

            return result;
        }

        public IEnumerable<string> GetStores()
        {
            var result =
                (from stores in ordersDB.StoreTables
                select stores.City).AsEnumerable();

            return result;
        }

        public int GetEmployeePerformance(string employeeName)
        {
            var result =
                (from order in ordersDB.Orders
                 where (order.SalesPersonTable.FirstName + " " + order.SalesPersonTable.LastName) == employeeName
                 select order.pricePaid).Sum();

            return result;
        }

        public int GetStorePerformance(string storeCity)
        {
            var result =
                (from order in ordersDB.Orders
                 where order.StoreTable.City == storeCity
                 select order.pricePaid).Sum();

            return result;
        }
        
        [Route("api/Orders/BestMarkups")]
        public IEnumerable<object> GetBestMarkups()
        {
            var result =
                from order in ordersDB.Orders
                group order by order.StoreTable.City into bestStores
                orderby bestStores.Count(x => x.pricePaid > 13) descending
                select new { City = bestStores.Key, Count = bestStores.Count(x => x.pricePaid > 13) };

            return result;
        }

    }
   
}
