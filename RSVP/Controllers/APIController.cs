using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace RSVP.Controllers
{
    public class APIController : Controller
    {
        const string userAgent = "Mozilla / 5.0(Windows NT 6.1; Win64; x64; rv: 47.0) Gecko / 20100101 Firefox / 47.0";

        //GET list of characters

        [HttpGet]
        public ActionResult ListCharacters()
        {
            //I grabbed 5 GoT characters I knew the names of, threw them into an array, 
            //requested each one individually, and added them to the character ViewBag
            string[] requestArray = new string[] {
                "https://www.anapioficeandfire.com/api/characters/1022", //Theon
                "https://www.anapioficeandfire.com/api/characters/238", //Cersei
                "https://www.anapioficeandfire.com/api/characters/957", //Jon Snow
                "https://www.anapioficeandfire.com/api/characters/583", //Sansa
                "https://www.anapioficeandfire.com/api/characters/271" //Daenerys
            };

            foreach (string requestString in requestArray)
            {
                HttpWebRequest request = WebRequest.CreateHttp(requestString);
                request.UserAgent = userAgent;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader data = new StreamReader(response.GetResponseStream());
                    string stringData = data.ReadToEnd();
                    JObject characters = JObject.Parse(stringData);
                    ViewBag.Characters += characters+",";
                }
            }
            ViewBag.Characters = JObject.Parse("{characters: [" + ViewBag.Characters + "]}");

            foreach (var i in ViewBag.Characters["characters"])
            {
                foreach (var a in i["allegiances"])
                {
                    HttpWebRequest request = WebRequest.CreateHttp(a.ToString());
                    request.UserAgent = userAgent;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        StreamReader data = new StreamReader(response.GetResponseStream());
                        string stringData = data.ReadToEnd();
                        JObject allegiances = JObject.Parse(stringData);
                        ViewBag.Allegiances += allegiances["name"] + ", ";
                    }
                }
                i["allegiances"] = ViewBag.Allegiances;

                foreach (var b in i["books"])
                {
                    HttpWebRequest request = WebRequest.CreateHttp(b.ToString());
                    request.UserAgent = userAgent;
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        StreamReader data = new StreamReader(response.GetResponseStream());
                        string stringData = data.ReadToEnd();
                        JObject books = JObject.Parse(stringData);
                        ViewBag.Books += books["name"] + ", ";
                    }
                }
                i["books"] = ViewBag.Books;
            }

            return View();
        }
    }
}