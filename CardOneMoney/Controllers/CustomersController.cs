using CardOneMoney.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CardOneMoney.Controllers
{
    public class CustomersController : Controller
    {
        private const string apiUri = "http://localhost:52057/api/";
        // GET: Customer
        public ActionResult Index()
        {
            IEnumerable<CustomerViewModel> customers = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUri);
                var response = client.GetAsync("customers");
                response.Wait();

                var result = response.Result;
                if (result.IsSuccessStatusCode)
                {
                    var task = result.Content.ReadAsAsync<IList<CustomerViewModel>>();
                    task.Wait();

                    customers = task.Result;
                }
            }

            return View(customers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerViewModel customer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUri+ "customer");

                //HTTP POST
                var postTask = client.PostAsJsonAsync<CustomerViewModel>("customers", customer);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }

            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(customer);
        }
        public ActionResult Edit(int CustomerID)
        {
            CustomerViewModel customer = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUri);
                //HTTP GET
                var responseTask = client.GetAsync("customers?CustomerID=" + CustomerID.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<CustomerViewModel>();
                    readTask.Wait();

                    customer = readTask.Result;
                }
            }

            return View(customer);
        }
        [HttpPost]
        public ActionResult Edit(CustomerViewModel customer)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUri + "customers");

                //HTTP POST
                var putTask = client.PutAsJsonAsync<CustomerViewModel>("customers", customer);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }
            return View(customer);
        }
        public ActionResult Delete(int customerID)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUri);

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("customers/" + customerID.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}