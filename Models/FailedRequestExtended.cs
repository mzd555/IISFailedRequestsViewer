using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Net;

namespace FailedRequestViewer.Models
{
    public class FailedRequestExtended
    {
        private readonly FailedRequest _original;
        private readonly string _filename;
        public FailedRequestExtended(FailedRequest original, string filename)
        {
            _original = original;
            _filename = filename;
        }

        public FailedRequest BaseRequest
        {
            get
            {
                return _original;
            }
        }

        public string Headers
        {
            get{
                return GetContent("GENERAL_REQUEST_HEADERS","Headers");
            }
        }

        public string Response
        {
            get
            {
                return GetContent("GENERAL_RESPONSE_ENTITY_BUFFER", "Buffer");
            }
        }

        public string Request
        {
            get
            {
                var data = GetContent("GENERAL_REQUEST_ENTITY", "Buffer");
                return WebUtility.UrlDecode(data);
            }
        }

          public string RemoteAddress
        {
            get
            {
                return GetContent("GENERAL_ENDPOINT_INFORMATION", "RemoteAddress");
            }
        }

        public DateTime TimeCreated 
        {
            get
            {
                return DateTime.Parse(this.BaseRequest.Event.First().System.TimeCreated.SystemTime).ToLocalTime();
            }
        }

        public string Filename { get { return _filename; } }

        public string GetContent(string Opcode, string container)
        {
            var item = this.BaseRequest.Event.ToList().Where(e => e.RenderingInfo.Opcode == Opcode).FirstOrDefault();
            if (item != null)
                return item.EventData.Data.Where(d => d.Name == container).First().Text;

            return string.Empty;
        }
        
    }
}
