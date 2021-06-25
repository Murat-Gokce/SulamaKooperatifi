using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace SulamaKoparatifi
{
    class Class1
    {
        public static string sqlcon = ConfigurationManager.ConnectionStrings["SulamaMdff "].ConnectionString;
    }
}
