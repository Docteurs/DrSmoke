using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DrSmoke.Models
{
    internal class MagasinEtProduit 
    {
        [JsonPropertyName("uuid")]
        public string Uuid { get; set; } = string.Empty;
        [JsonPropertyName("uuid_admin")]
        public string Uuid_admin { get; set; } = string.Empty;
        [JsonPropertyName("categorie_produit")]
        public string Categorie_produit {  get; set; } = string.Empty;
        [JsonPropertyName("nom_produit")]
        public string Nom_produit { get; set; } = string.Empty;
        [JsonPropertyName("descriptif")]
        public string Descriptif {  get; set; } = string.Empty;
        [JsonPropertyName("quantite")]
        public int Quantite { get; set; }
        [JsonPropertyName("ung_prix")]
        public string Ung_prix {  get; set; } = string.Empty;
        [JsonPropertyName("troisg_prix")]
        public string Troisg_prix { get; set; } = string.Empty;
        [JsonPropertyName("cingg_prix")]
        public string Cingg_prix { get; set; } = string.Empty;
        [JsonPropertyName("dixg_prix")]
        public string Dixg_prix { get; set; } = string.Empty;
        [JsonPropertyName("vingtg_prix")]
        public string Vingtg_prix { get; set; } = string.Empty;
        [JsonPropertyName("uuid_magasin")]
        public string Uuid_magasin {  get; set; } = string.Empty;

    }
}
