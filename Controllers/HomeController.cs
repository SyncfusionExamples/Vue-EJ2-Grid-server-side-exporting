using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Grids;
using Syncfusion.EJ2.GridExport;

namespace asp_vue.Controllers
{
    public class HomeController : Controller
    {
        public static List<OrdersDetails> order = new List<OrdersDetails>();
        public IActionResult Index()
        {
            var order = OrdersDetails.GetAllRecords();
            ViewBag.datasource = order.ToArray();
            return View();
        }
        public ActionResult ExcelExport([FromForm] string gridModel)
        {
            GridExcelExport exp = new GridExcelExport();
            Grid gridProperty = ConvertGridObject(gridModel);
            return exp.ExcelExport<OrdersDetails>(gridProperty, OrdersDetails.GetAllRecords());
        }

        public ActionResult PdfExport([FromForm] string gridModel)
        {
            GridPdfExport exp = new GridPdfExport();
            Grid gridProperty = ConvertGridObject(gridModel);
            return exp.PdfExport<OrdersDetails>(gridProperty, OrdersDetails.GetAllRecords());
        }


        private Grid ConvertGridObject(string gridProperty)
        {
            Grid GridModel = (Grid)Newtonsoft.Json.JsonConvert.DeserializeObject(gridProperty, typeof(Grid));
            GridColumnModel cols = (GridColumnModel)Newtonsoft.Json.JsonConvert.DeserializeObject(gridProperty, typeof(GridColumnModel));
            GridModel.Columns = cols.columns;
            return GridModel;
        }

        public class GridColumnModel
        {
            public List<GridColumn> columns { get; set; }
        }

    }
    public class OrdersDetails
    {
        public static List<OrdersDetails> order = new List<OrdersDetails>();
        public OrdersDetails()
        {

        }
        public OrdersDetails(int OrderID, string CustomerId, double Freight, string ShipCity, string ShipCountry)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerId;
            this.Freight = Freight;
          
            this.ShipCity = ShipCity;
            this.ShipCountry = ShipCountry;
     
        }
        public static List<OrdersDetails> GetAllRecords()
        {
            if (order.Count() == 0)
            {
                int code = 10000;
                for (int i = 1; i < 10; i++)
                {
                    order.Add(new OrdersDetails(code + 1, "ALFKI", 2.3 * i, "Berlin", "Denmark"));
                    order.Add(new OrdersDetails(code + 2, "ANATR", 3.3 * i, "Madrid", "Brazil"));
                    order.Add(new OrdersDetails(code + 3, "ANTON", 4.3 * i, "Cholchester", "Germany"));
                    order.Add(new OrdersDetails(code + 4, "BLONP", 5.3 * i, "Marseille", "Austria"));
                    order.Add(new OrdersDetails(code + 5, "BOLID", 6.3 * i, "Tsawassen", "Switzerland"));
                    code += 5;
                }
            }
            return order;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        
        public double? Freight { get; set; }

        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }

   
    }
}
