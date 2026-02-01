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
    /// <summary>
    /// Class Assessment
    /// It has available a set of methods in order to interconnect to the backend component
    /// </summary>
    public class Assessment
    {
        // Generates a file for a set of values case items
        public static Response generateFiles(List<CaseItem> values)
        {
            string endpoint = ConfigurationManager.AppSettings["protocol"] + "://" + ConfigurationManager.AppSettings["endpoint"];
            var client = new RestClient(endpoint);
            var request = new RestRequest("/generatefiles", Method.Post);

            // Json
            request.AddParameter("json", JsonSerializer.Serialize(values), ParameterType.GetOrPost);

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

        // Generates a view with the text corresponding to a set of type, subtype and id component
        public static Response generateView(int type, int subtype, int id)
        {
            string endpoint = ConfigurationManager.AppSettings["protocol"] + "://" + ConfigurationManager.AppSettings["endpoint"];
            var client = new RestClient(endpoint);
            var request = new RestRequest("/generateview/" + type + "/" + subtype + "/" + id, Method.Get);

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

        // Generates a query to be executed by GPT
        public static Response generateQuery(GptQuery gptQuery)
        {
            string endpoint = ConfigurationManager.AppSettings["protocol"] + "://" + ConfigurationManager.AppSettings["endpoint"];
            var client = new RestClient(endpoint);
            var request = new RestRequest("/generatequery", Method.Post);

            // Json
            request.AddParameter("json", JsonSerializer.Serialize(gptQuery), ParameterType.GetOrPost);

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

        // Deletes a case of analysis given a determined id
        public static Response deleteCase(int id)
        {
            string endpoint = ConfigurationManager.AppSettings["protocol"] + "://" + ConfigurationManager.AppSettings["endpoint"];
            var client = new RestClient(endpoint);
            var request = new RestRequest("/deletecase/" + id, Method.Delete);

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

        // Creates a new document corresponding to a law or a normative
        public static Response createCase(Document document)
        {
            string endpoint = ConfigurationManager.AppSettings["protocol"] + "://" + ConfigurationManager.AppSettings["endpoint"];
            var client = new RestClient(endpoint);
            var request = new RestRequest("/createcase", Method.Post);

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

        // Gets the corresponding case corresponding to a normative or a law
        public static Document getCase(int idNormative, int idLaw)
        {
            string endpoint = ConfigurationManager.AppSettings["protocol"] + "://" + ConfigurationManager.AppSettings["endpoint"];
            var client = new RestClient(endpoint);
            var request = new RestRequest("/getcase/" + idNormative + "/" + idLaw, Method.Get);

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

        // Gets the current version of an id case
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

        // Gets all possible cases of analysis
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

        // Creates a document corresponding to a law or normative in a given path
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

        // Gets a document according to its type and id
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

        // Gets all possible documents according to its type
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

        // Deletes a document according to its type and id
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