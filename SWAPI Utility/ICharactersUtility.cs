using System.Threading.Tasks;

namespace SwapiUtility {
    public interface ICharactersUtility {
        Task<string> GetCharacters(string filmTitle);
    }
}