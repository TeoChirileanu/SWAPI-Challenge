using System.Threading.Tasks;

namespace SwapiUtility {
    public interface IFilmsUtility {
        Task<string> GetFilms(string characterName);
    }
}