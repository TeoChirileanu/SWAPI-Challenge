using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SwapiUtility.Properties;

namespace SwapiUtility {
    public class CharactersUtility : ICharactersUtility {
        private static string BaseUri => Resources.BaseUri + "films";
        private static HttpClient HttpClient => new HttpClient();

        public async Task<string> GetCharacters(string filmTitle) {
            var characterUris = await GetCharacterUris(filmTitle).ConfigureAwait(false);
            var characterNames = await GetCharacterNames(characterUris).ConfigureAwait(false);
            return characterNames;
        }

        private async Task<string> GetCharacterNames(dynamic characterUris) {
            if (characterUris == null) return "none";
            var characters = new Collection<string>();
            foreach (var characterUri in characterUris) {
                string characterAsJson = await HttpClient.GetStringAsync(characterUri.ToString()).ConfigureAwait(false);
                dynamic character = JsonConvert.DeserializeObject(characterAsJson);
                characters.Add(character.name.ToString());
            }

            return string.Join(", ", characters);
        }

        private async Task<dynamic> GetCharacterUris(string filmTitle) {
            var jsonResponse = await HttpClient.GetStringAsync(BaseUri).ConfigureAwait(false);
            dynamic resultObject = JsonConvert.DeserializeObject(jsonResponse);
            var results = resultObject.results;
            dynamic charactersUris = null;
            foreach (var result in results)
                if (result.title.ToString() == filmTitle) {
                    charactersUris = result.characters;
                    break;
                }

            return charactersUris;
        }
    }
}