using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Webservice.REST
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class TutorialService
    {
        private static List<string> lst = new List<string>
        {
            "Arrays",
            "Queues",
            "Stacks",
            "Boozer",
            "DyadyaSeva",
            "OksanaGnida",
            "Vitaliy"
        };

        [WebGet(UriTemplate = "/Tutorial")]
        public string GetAllTutorials() { return String.Join(",", lst); }

        [WebGet(UriTemplate = "/Tutorial/{TutorialId}")]
        public string GetTutorialByID(string TutorialId)
        {
            int pid;
            if (!int.TryParse(TutorialId, out pid)) {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            return lst[pid];
        }

        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            UriTemplate = "/Tutorial", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]

        public void AddTutorial(string str) { lst.Add(str); }
        
        [WebInvoke(Method = "DELETE", RequestFormat = WebMessageFormat.Json,
            UriTemplate = "/Tutorial/{TutorialId}", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]

        public void DeleteTutorial(string TutorialId)
        {
            int pid;
            if (!int.TryParse(TutorialId, out pid)) {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            lst.RemoveAt(pid);
        } 
    } 
}



