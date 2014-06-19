using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HDF5DotNet;

namespace RdrExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            H5.Open();
            Console.WriteLine("HDF5 Verion: {0}.{1}.{2}", H5.Version.Major, H5.Version.Minor, H5.Version.Release);
            H5.Close();
        }
    }
}
