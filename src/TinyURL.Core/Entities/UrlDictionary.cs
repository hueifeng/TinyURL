using System;

namespace TinyURL.Core.Entities
{
    public class UrlDictionary
    {
        public int Id { get; set; }

        /// <summary> 
        ///     Short url code
        /// </summary>
        public string Code { get; set; }

        public string HashVal { get; set; }

        /// <summary>
        ///     The URL that needs to be converted
        /// </summary>
        public string Url { get; set; }

        public DateTime InsertAt { get; set; }
    }
}
