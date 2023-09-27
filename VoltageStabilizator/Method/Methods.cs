using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voltage_Stablizer
{
    public class Methods
    {
        private readonly string folder = "../../../Data/datafile.json";
        public string Reader()
        {
            StreamReader reader = new StreamReader(folder);
            var data = reader.ReadToEnd();
            reader.Close();
            return data;
        }

        public void Writer()
        {
            StreamWriter writer = new StreamWriter(folder);
            writer.Write("");
            writer.Close();
        }
    }
}
