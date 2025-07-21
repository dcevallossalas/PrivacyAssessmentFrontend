using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using AssessmentLibrary.AssessmentModel;
using RestSharp;

namespace AssessmentLibrary.AssessmentLogic
{
    public class Assessment
    {
        public static Response getVersion(int id)
        {
            string endpoint = ConfigurationManager.AppSettings["protocol"] + "://" + ConfigurationManager.AppSettings["endpoint"];
            var client = new RestClient(endpoint);
            var request = new RestRequest("/getversion/" + id, Method.Get);

            var result = client.ExecuteGet(request);

            if (result.IsSuccessful)
            {
                Response response = JsonSerializer.Deserialize<Response>(result.Content);
                return response;
            }
            else
            {
                return new Response
                {
                    code = -1,
                    message = "Error. Status Code: " + result.StatusCode + " Status Description: " + result.ErrorMessage
                };
            }
        }

        public static Cases getCases()
        {
            string endpoint = ConfigurationManager.AppSettings["protocol"] + "://" + ConfigurationManager.AppSettings["endpoint"];
            var client = new RestClient(endpoint);
            var request = new RestRequest("/getcases", Method.Get);

            var result = client.ExecuteGet(request);

            if (result.IsSuccessful)
            {
                Cases cases = JsonSerializer.Deserialize<Cases>(result.Content);
                return cases;
            }
            else
            {
                return new Cases
                {
                    code = -1,
                    message = "Error. Status Code: " + result.StatusCode + " Status Description: " + result.ErrorMessage
                };
            }
        }

        public static Response createDocument(Document document,string path)
        {
            string endpoint = ConfigurationManager.AppSettings["protocol"] + "://" + ConfigurationManager.AppSettings["endpoint"];
            var client = new RestClient(endpoint);
            var request = new RestRequest("/createnormative", Method.Post);

            // File
            byte[] value = File.ReadAllBytes(path);
            request.AddFile("file", value, document.alias, "text/plain");
            // Json
            request.AddParameter("json", JsonSerializer.Serialize(document), ParameterType.GetOrPost);

            RestResponse result = client.Execute(request);
            if (result.IsSuccessful)
            {
                Response response = JsonSerializer.Deserialize<Response>(result.Content);
                return response;
            }
            else
            {
                return new Response
                {
                    code = -1,
                    message = "Error. Status Code: " + result.StatusCode + " Status Description: " + result.ErrorMessage
                };
            }
        }
        public static Document getDocument(int docType, int id)
        {
            string endpoint = ConfigurationManager.AppSettings["protocol"] + "://" + ConfigurationManager.AppSettings["endpoint"];
            var client = new RestClient(endpoint);
            var request = new RestRequest("/getdocument/" + docType + "/" + id, Method.Get);

            var result = client.ExecuteGet(request);

            if (result.IsSuccessful)
            {
                Document document = JsonSerializer.Deserialize<Document>(result.Content);
                return document;
            }
            else
            {
                return new Document
                {
                    code = -1,
                    message = "Error. Status Code: " + result.StatusCode + " Status Description: " + result.ErrorMessage
                };
            }
        }

        public static Documents getDocuments(int docType)
        {
            string endpoint = ConfigurationManager.AppSettings["protocol"] + "://" + ConfigurationManager.AppSettings["endpoint"];
            var client = new RestClient(endpoint);
            var request = new RestRequest("/getdocuments/" + docType, Method.Get);

            var result = client.ExecuteGet(request);

            if (result.IsSuccessful)
            {
                Documents documents = JsonSerializer.Deserialize<Documents>(result.Content);
                return documents;
            }
            else
            {
                return new Documents
                {
                    code = -1,
                    message = "Error. Status Code: " + result.StatusCode + " Status Description: " + result.ErrorMessage
                };
            }
        }

        public static Response deleteDocument(int docType, int id)
        {
            string endpoint = ConfigurationManager.AppSettings["protocol"] + "://" + ConfigurationManager.AppSettings["endpoint"];
            var client = new RestClient(endpoint);
            var request = new RestRequest("/deletedocument/" + docType + "/" + id, Method.Delete);

            var result = client.ExecuteDelete(request);

            if (result.IsSuccessful)
            {
                Response response = JsonSerializer.Deserialize<Response>(result.Content);
                return response;
            }
            else
            {
                return new Response
                {
                    code = -1,
                    message = "Error. Status Code: " + result.StatusCode + " Status Description: " + result.ErrorMessage
                };
            }
        }

        
    }
}
