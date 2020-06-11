using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMAShareXCaptureOptions
{
    public class DataAccess
    {
       
        public string dbpath { get; set; }

        public DataAccess(string database)
        {
            dbpath = database;
        }
    }
}
