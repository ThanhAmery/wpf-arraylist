using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAOs
{
    public class GenericDAO<T> where T : class, new() 
    {

        private static readonly object _lock = new object();
        private static T instance;



        public static T Instance
        {
            get
            {
                lock (_lock)
                {
                    if (instance == null)
                    {
                        instance = new T();
                    }
                    return instance;
                }
            }
        }

    }
}
