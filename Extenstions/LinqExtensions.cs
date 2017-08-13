using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using USTVA.Entities;
using USTVA.ViewModels;

namespace USTVA.Extenstions
{
    public static class LinqExtensions
    {
        /// <summary>
        /// Transforms an Enumerable source that contains collections of incidents to a collection of dictionaries.
        /// The key will be a the year, and value will be a collection of incidents for that year respectively.
        /// </summary>
        /// <param name="source"></param>
        /// <returns>A a collection of Dictionaries</returns>
        public static IEnumerable<Dictionary<string, IEnumerable<Incident>>> ToIncidentDictionary(this IEnumerable<IEnumerable<Incident>> source)
        {
            foreach (var collection in source)
            {
               var year = collection.Select(x => x.DateTime.Year).First();

                yield  return new Dictionary<string, IEnumerable<Incident>>
                {
                    {$"{year}",  collection}
                };
            }     
        }
    }
}
