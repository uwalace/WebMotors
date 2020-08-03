using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMotors.App.Models.Domain
{
	public class Anuncio
	{
        [JsonProperty(PropertyName = "ID")]
        public int ID { get; set; }

        [JsonProperty(PropertyName = "Marca")]
        public string Marca { get; set; }

        [JsonProperty(PropertyName = "Modelo")]
        public string Modelo { get; set; }

        [JsonProperty(PropertyName = "Versao")]
        public string Versao { get; set; }

        [JsonProperty(PropertyName = "Ano")]
        public int Ano { get; set; }

        [JsonProperty(PropertyName = "Quilometragem")]
        public int Quilometragem { get; set; }

        [JsonProperty(PropertyName = "Observacao")]
        public string Observacao { get; set; }
    }
}
