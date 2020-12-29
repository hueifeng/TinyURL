using System;
using System.Threading.Tasks;
using TinyURL.Core;
using TinyURL.Core.Abstracts;
using TinyURL.Core.Entities;

namespace TinyURL
{
    public class TinyURL
    {
        private readonly IDataStorageProcessor _storageProcessor;

        public TinyURL(IDataStorageProcessor storageProcessor)
        {
            this._storageProcessor = storageProcessor;
        }

        /// <summary>
        /// Generate short code
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public virtual async Task<string> Generator(string url)
        {
            var hashVal = ShortUrlGenerator.MurmurHash3(url);
            var codeStr = await _storageProcessor.GetCodeByHashVal(hashVal);
            if (string.IsNullOrEmpty(codeStr))
            {
                var id = await _storageProcessor.Insert(new UrlDictionary
                {
                    HashVal = hashVal,
                    InsertAt = DateTime.Now,
                    Url = url
                });

                var code = ShortUrlGenerator.Generator(id);
                await _storageProcessor.UpdateCodeById(id, code);
                return code;
            }
            return codeStr;
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public virtual async Task<string> GetUrlByCode(string code)
        {
            return await _storageProcessor.GetUrlByCode(code);
        }
    }
}
