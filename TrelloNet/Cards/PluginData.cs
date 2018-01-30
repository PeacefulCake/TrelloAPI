using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Newtonsoft.Json;

using RestSharp;
using RestSharp.Deserializers;
using TrelloNet.Internal;

namespace TrelloNet
{
  public class PluginData
  {
    public string Id { get; set; }
    public string IdPlugin { get; set; }
    public string Scope { get; set; }
    public string IdModel { get; set; }
    public string Value { get; set; }
    public PluginDataValue ParsedValue { get; set; }
    public string Access { get; set; }

    public class PluginDataValue
    {
      public int Points { get; set; }
      public List<string> PointsHistory { get; set; }
    }

    [OnDeserialized]
    private void AfterDeserialization(StreamingContext context)
    {
      if (IdPlugin == "59d4ef8cfea15a55b0086614")
      {
        ParsedValue = JsonConvert.DeserializeObject<PluginDataValue>(Value);
      }
    }
  }
}