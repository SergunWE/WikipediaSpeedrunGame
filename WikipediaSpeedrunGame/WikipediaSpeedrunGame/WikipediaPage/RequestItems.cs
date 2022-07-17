using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace WikipediaSpeedrunGame
{
   public class RequestItems<T>
    {
       [JsonProperty("items")]
       public T[] Items { get; set; }
    }
}
