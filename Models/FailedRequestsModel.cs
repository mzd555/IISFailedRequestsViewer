using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Microsoft.Extensions.Configuration;

namespace FailedRequestViewer.Models
{
    public class FailedRequestsModel
    {
        readonly IConfiguration _configuration;
        public FailedRequestsModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public byte[] GetFile(string filename)
        {
            var logPath = _configuration.GetSection("appSettings").GetChildren().First(a => a.Key == "LogPath").Value;
            return File.ReadAllBytes(logPath + "/" + filename);
        }

        public IEnumerable<FailedRequestExtended> GetFailedRequestsWithInOFS()
        {
            var requests = GetFailedRequests();
            return requests
                    .Where(r => r.BaseRequest.Url.Contains("api.onfile.legal"));

        }
        public IEnumerable<FailedRequestExtended> GetFailedRequests()
        {
            var logPath = _configuration.GetSection("appSettings").GetChildren().First(a => a.Key == "LogPath").Value;
            var files = new DirectoryInfo(logPath).GetFiles("*.xml");
            var result = new List<FailedRequestExtended>();
            var serializer = new XmlSerializer(typeof(FailedRequest));

            files.ToList().ForEach(f =>
            {
                var reader = File.OpenRead(f.FullName);
                result.Add(new FailedRequestExtended((FailedRequest)serializer.Deserialize(reader), f.Name));
            });

            return result;
        }
    }
}