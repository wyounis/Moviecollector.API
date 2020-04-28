using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MovieCollector.StarWarsAPIWrapper.Adapters.Interfaces
{
    public interface IWebAdapter
    {
        Task<TType> GetAsync<TType>(string requestUri);
    }
}
