
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
        [Route("api/Orders/Salespeople")]
        public IEnumerable<string> GetSalespeople()
        {
            var result =
               (from sales in ordersDB.Orders
                select sales.SalesPersonTable.FirstName + " " + sales.SalesPersonTable.LastName).Distinct().AsEnumerable();

            return result;
        }

        [Route("api/Orders/Stores")]
        public IEnumerable<string> GetStores()
        {
            var result =
                (from stores in ordersDB.Orders
                select stores.StoreTable.City).Distinct().AsEnumerable();

            return result;
        }

        [Route("api/Orders/EmployeePerformance")]
        public IHttpActionResult GetEmployeePerformance(string employeeName)
        {
            var result =
                (from order in ordersDB.Orders
                 where (order.SalesPersonTable.FirstName + " " + order.SalesPersonTable.LastName) == employeeName
                 select order.pricePaid).Sum();

            return Ok(result);
        }

        [Route("api/Orders/StorePerformance")]
        public IHttpActionResult GetStorePerformance(string storeCity)
        {
            var result =
                (from order in ordersDB.Orders
                 where order.StoreTable.City == storeCity
                 select order.pricePaid).Sum();

            return Ok(result);
        }
        
        [Route("api/Orders/BestMarkups")]
        public IHttpActionResult GetBestMarkups()
        {
            var result =
                (from order in ordersDB.Orders
                group order by order.StoreTable.City into bestStores
                orderby bestStores.Count(x => x.pricePaid > 13) descending
                select new { City = bestStores.Key, Count = bestStores.Count(x => x.pricePaid > 13) }).AsEnumerable();

            return Ok(result);
        }

    }
   
}
