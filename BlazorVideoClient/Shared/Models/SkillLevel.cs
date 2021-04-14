using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlazorVideoClient.Shared.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SkillLevel
    {
        None,
        Beginner,
        Intermediate,
        Advance
    }
}
