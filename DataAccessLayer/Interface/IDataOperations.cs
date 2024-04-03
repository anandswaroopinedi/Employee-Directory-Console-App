using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interface
{
    public interface IDataOperations
    {
        public Task<List<T>> Read<T>(string filePath);
        public Task<bool> Write<T>(List<T> t, string filePath);

    }
}
