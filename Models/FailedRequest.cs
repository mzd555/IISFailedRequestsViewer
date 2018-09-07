/* 
 Licensed under the Apache License, Version 2.0

 http://www.apache.org/licenses/LICENSE-2.0
 */
using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace FailedRequestViewer.Models
{
    [XmlRoot(ElementName = "Provider", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
    public class Provider
    {
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "Guid")]
        public string Guid { get; set; }
    }

    [XmlRoot(ElementName = "TimeCreated", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
    public class TimeCreated
    {
        [XmlAttribute(AttributeName = "SystemTime")]
        public string SystemTime { get; set; }
    }

    [XmlRoot(ElementName = "Correlation", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
    public class Correlation
    {
        [XmlAttribute(AttributeName = "ActivityID")]
        public string ActivityID { get; set; }
    }

    [XmlRoot(ElementName = "Execution", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
    public class Execution
    {
        [XmlAttribute(AttributeName = "ProcessID")]
        public string ProcessID { get; set; }
        [XmlAttribute(AttributeName = "ThreadID")]
        public string ThreadID { get; set; }
    }

    [XmlRoot(ElementName = "System", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
    public class System
    {
        [XmlElement(ElementName = "Provider", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
        public Provider Provider { get; set; }
        [XmlElement(ElementName = "EventID", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
        public string EventID { get; set; }
        [XmlElement(ElementName = "Version", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
        public string Version { get; set; }
        [XmlElement(ElementName = "Level", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
        public string Level { get; set; }
        [XmlElement(ElementName = "Opcode", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
        public string Opcode { get; set; }
        [XmlElement(ElementName = "Keywords", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
        public string Keywords { get; set; }
        [XmlElement(ElementName = "TimeCreated", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
        public TimeCreated TimeCreated { get; set; }
        [XmlElement(ElementName = "Correlation", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
        public Correlation Correlation { get; set; }
        [XmlElement(ElementName = "Execution", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
        public Execution Execution { get; set; }
        [XmlElement(ElementName = "Computer", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
        public string Computer { get; set; }
    }

    [XmlRoot(ElementName = "Data", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
    public class Data
    {
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "EventData", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
    public class EventData
    {
        [XmlElement(ElementName = "Data", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
        public List<Data> Data { get; set; }
    }

    [XmlRoot(ElementName = "RenderingInfo", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
    public class RenderingInfo
    {
        [XmlElement(ElementName = "Opcode", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
        public string Opcode { get; set; }
        [XmlAttribute(AttributeName = "Culture")]
        public string Culture { get; set; }
        [XmlElement(ElementName = "Keywords", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
        public Keywords Keywords { get; set; }
        [XmlElement(ElementName = "Description", Namespace = "http://schemas.microsoft.com/win/2006/06/iis/freb")]
        public List<Description> Description { get; set; }
    }

    [XmlRoot(ElementName = "ExtendedTracingInfo", Namespace = "http://schemas.microsoft.com/win/2004/08/events/trace")]
    public class ExtendedTracingInfo
    {
        [XmlElement(ElementName = "EventGuid", Namespace = "http://schemas.microsoft.com/win/2004/08/events/trace")]
        public string EventGuid { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }

    [XmlRoot(ElementName = "Event", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
    public class Event
    {
        [XmlElement(ElementName = "System", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
        public System System { get; set; }
        [XmlElement(ElementName = "EventData", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
        public EventData EventData { get; set; }
        [XmlElement(ElementName = "RenderingInfo", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
        public RenderingInfo RenderingInfo { get; set; }
        [XmlElement(ElementName = "ExtendedTracingInfo", Namespace = "http://schemas.microsoft.com/win/2004/08/events/trace")]
        public ExtendedTracingInfo ExtendedTracingInfo { get; set; }
        [XmlAttribute(AttributeName = "xmlns")]
        public string Xmlns { get; set; }
    }

    [XmlRoot(ElementName = "Keywords", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
    public class Keywords
    {
        [XmlElement(ElementName = "Keyword", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
        public string Keyword { get; set; }
    }

    [XmlRoot(ElementName = "Description", Namespace = "http://schemas.microsoft.com/win/2006/06/iis/freb")]
    public class Description
    {
        [XmlAttribute(AttributeName = "Data")]
        public string Data { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "failedRequest")]
    public class FailedRequest
    {
        [XmlElement(ElementName = "Event", Namespace = "http://schemas.microsoft.com/win/2004/08/events/event")]
        public List<Event> Event { get; set; }
        [XmlAttribute(AttributeName = "url")]
        public string Url { get; set; }
        [XmlAttribute(AttributeName = "siteId")]
        public string SiteId { get; set; }
        [XmlAttribute(AttributeName = "appPoolId")]
        public string AppPoolId { get; set; }
        [XmlAttribute(AttributeName = "processId")]
        public string ProcessId { get; set; }
        [XmlAttribute(AttributeName = "verb")]
        public string Verb { get; set; }
        [XmlAttribute(AttributeName = "remoteUserName")]
        public string RemoteUserName { get; set; }
        [XmlAttribute(AttributeName = "userName")]
        public string UserName { get; set; }
        [XmlAttribute(AttributeName = "tokenUserName")]
        public string TokenUserName { get; set; }
        [XmlAttribute(AttributeName = "authenticationType")]
        public string AuthenticationType { get; set; }
        [XmlAttribute(AttributeName = "activityId")]
        public string ActivityId { get; set; }
        [XmlAttribute(AttributeName = "failureReason")]
        public string FailureReason { get; set; }
        [XmlAttribute(AttributeName = "statusCode")]
        public string StatusCode { get; set; }
        [XmlAttribute(AttributeName = "triggerStatusCode")]
        public string TriggerStatusCode { get; set; }
        [XmlAttribute(AttributeName = "timeTaken")]
        public string TimeTaken { get; set; }
        [XmlAttribute(AttributeName = "freb", Namespace = "http://www.w3.org/2000/xmlns/")]
        public string Freb { get; set; }
    }

}
