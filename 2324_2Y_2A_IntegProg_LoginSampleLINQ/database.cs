using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2324_2Y_2A_IntegProg_LoginSampleLINQ
{
    internal static class database
    {
        public static LoginSampleDataContext _lsDC = new LoginSampleDataContext(
                Properties.Settings.Default._2324_1A_LoginSampleConnectionString);
        public static DateTime cDT = DateTime.Now;
    }
}
