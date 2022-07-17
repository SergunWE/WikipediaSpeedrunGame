using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WikipediaSpeedrunGame
{
    public class PageInfo
    {
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("page_id")]
        public int PageId { get; set; }
        [JsonProperty("rev")]
        public int Rev { get; set; }
        [JsonProperty("tid")]
        public string Tid { get; set; }
        [JsonProperty("namespace")]
        public int Namespace { get; set; }
        [JsonProperty("user_id")]
        public int UserId { get; set; }
        [JsonProperty("user_text")]
        public string UserText { get; set; }
        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }
        [JsonProperty("comment")]
        public string Comment { get; set; }
        [JsonProperty("tags")]
        public string[] Tags { get; set; }
        [JsonProperty("restrictions")]
        public string[] Restrictions { get; set; }
        [JsonProperty("page_language")]
        public string PageLanguage { get; set; }
        [JsonProperty("redirect")]
        public bool Redirect { get; set; }
        [JsonProperty("page_deleted")]
        public string PageDeleted { get; set; }
    }
}
