using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace USTVA.Services
{
    public class JsonDataProvider<T>: ILocalDataProvider<T>
    {
        private IDictionary<string, IEnumerable<T>> _jsonCollection = new Dictionary<string, IEnumerable<T>>();
        public IDictionary<string, IEnumerable<T>> JsonCollection { get { return _jsonCollection; } }

        public JsonDataProvider<T> AddSource(string alias, string path)
        {
            var stream = new FileStream(path, FileMode.Open, FileAccess.Read);

            using (var reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();

                var result = JsonConvert.DeserializeObject<IEnumerable<T>>(json);

                _jsonCollection.Add(alias, result);
            }

            return this;
        }

        public IEnumerable<T> Get(string key)
        {
            return JsonCollection[key];
        }
    }
}
