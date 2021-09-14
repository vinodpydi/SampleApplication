using SampleApplication.Models;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace SampleApplication.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmployeeResult()
        {

            Employee model = new Employee
            {
                FirstName = Request["FirstName"],
                LastName = Request["LastName"]
            };

            //In this way also we can serialize and deserialize


            ////serialize an Employee object to JSON string
            //ViewBag.json = JsonConvert.SerializeObject(model);

            ////deserialize a JSON string back to Employee object
            //Employee emp = JsonConvert.DeserializeObject<Employee>(ViewBag.json);


            //return View("Index", model);

            //Another way where we can convert to JSON

            if (!string.IsNullOrEmpty(model.FirstName) && !string.IsNullOrEmpty(model.LastName))
            {
                var dataSerialize = new JavaScriptSerializer().Serialize(model);
                var path = Server.MapPath("~/App_Data/");

                // Write that JSON to txt file,  
                System.IO.File.WriteAllText(path + "output.json", dataSerialize);
                TempData["msg"] = "Json file Generated! check the file in your App_Data folder";
                return View("Index", model);
            }
            else
            {
                TempData["msg"] = "Please enter the FirstName/LastName";
                return View("Index", model);
            }
        }
    }
}