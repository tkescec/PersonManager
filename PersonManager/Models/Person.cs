using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace PersonManager.Models
{
    public class Person
    {
        [JsonProperty(PropertyName = "id")]
        public string? Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "LastName")]
        public string LastName { get; set; }
    }
}
