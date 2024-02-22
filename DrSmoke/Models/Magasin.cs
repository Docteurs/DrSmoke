using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DrSmoke.Models
{
    class Magasin
    {
        [JsonPropertyName("uuid")]
        public string Uuid { get; set; } = string.Empty;

        [JsonPropertyName("adresse")]
        public string Adresse { get; set; } = string.Empty;

        [JsonPropertyName("code_postal")]
        public int Code_postal { get; set; }

        [JsonPropertyName("imgUrl")]
        public string ImgUrl {  get; set; } = string.Empty;

        [JsonPropertyName("ville")]
        public string Ville {  get; set; } = string.Empty;

        [JsonPropertyName("horaireLundi")]
        public string HoraireLundi { get; set; } = string.Empty;

        [JsonPropertyName("horaireMardi")]
        public string HoraireMardi {  get; set; } = string.Empty;

        [JsonPropertyName("horaireMercredi")]
        public string HoraireMercredi {  get; set; } = string.Empty;

        [JsonPropertyName("horaireJeudi")]
        public string HoraireJeudi {  get; set; } = string.Empty;

        [JsonPropertyName("horaireVendredi")]
        public string HoraireVendredi {  get; set; } = string.Empty;

        [JsonPropertyName("horaireSamedi")]
        public string HoraireSamedi {  get; set; } = string.Empty;

        [JsonPropertyName("horaireDimanche")]
        public string HoraireDimanche {  get; set; } = string.Empty;
    }
}
