using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SwapiUtility.Properties;

namespace SwapiUtility {
    public class FilmsUtility : IFilmsUtility {
        private static string BaseUri => Resources.BaseUri + "people";
        private static HttpClient HttpClient => new HttpClient();

        public async Task<string> GetFilms(string characterName) {
            var filmUris = await GetFilmUris(characterName).ConfigureAwait(false);
            var filmsTitles = await GetFilmTitles(filmUris).ConfigureAwait(false);
            return filmsTitles;
        }

        private static async Task<string> GetFilmTitles(dynamic filmUris) {
            if (filmUris == null) return "none";
            var filmTitles = new Collection<string>();
            foreach (var filmUri in filmUris) {
                string filmAsJson = await HttpClient.GetStringAsync(filmUri.ToString()).ConfigureAwait(false);
                dynamic film = JsonConvert.DeserializeObject(filmAsJson);
                filmTitles.Add(film.title.ToString());
            }

            return string.Join(", ", filmTitles);
        }

        private static async Task<dynamic> GetFilmUris(string characterName) {
            var jsonResponse = await HttpClient.GetStringAsync(BaseUri).ConfigureAwait(false);
            dynamic resultObject = JsonConvert.DeserializeObject(jsonResponse);
            var results = resultObject.results;
            dynamic filmUris = null;
            foreach (var result in results)
                if (result.name.ToString() == characterName) {
                    filmUris = result.films;
                    break;
                }

            return filmUris;
        }
    }
}