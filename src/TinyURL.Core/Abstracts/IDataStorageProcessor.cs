using System.Threading.Tasks;
using TinyURL.Core.Entities;

namespace TinyURL.Core.Abstracts
{
    public interface IDataStorageProcessor
    {
        /// <summary>
        ///     
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<bool> IsUnique(string code);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<string> GetUrlByCode(string code);

        /// <summary>
        ///     
        /// </summary>
        /// <param name="hashVal"></param>
        /// <returns></returns>
        Task<string> GetCodeByHashVal(string hashVal);

        Task<int> Insert(UrlDictionary urlDictionary);

        Task<bool> UpdateCodeById(int id, string code);
    }
}
