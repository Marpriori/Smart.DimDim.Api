using Newtonsoft.Json;
using Smart.Dimdim.Models;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web.Mvc;

namespace Smart.Dimdim.WebMvc.Controllers
{
    public class LoginController : Controller
    {
        public Login login;
        public LoginController()
        {
            login = new Login();
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            return View(login);
        }

          //
        // POST: /Login/Create
        [HttpPost]
        public ActionResult Index(Login login)
        {
            try
            {

                var token = EfetuarLogin(login);
               


                return View(login);
            }
            catch
            {
                return View();
            }
        }

        private Token EfetuarLogin(Login login)
        {
            var webAddr = "http://smart-dimdim-api.azurewebsites.net/api/Token";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(login);

                streamWriter.Write(json);
                streamWriter.Flush();
            }

            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<Token>(result);
            }
        }
    }
}
