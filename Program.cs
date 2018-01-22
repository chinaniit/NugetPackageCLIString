using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace NugetPackageCLIString
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = System.IO.File.ReadAllText(Path.Combine(Directory.GetCurrentDirectory(), "source.txt"));
            var dest = Path.Combine(Directory.GetCurrentDirectory(), "dest.txt");

            List<string> sb = new List<string>();
            var reg = new Regex(@"  <package id=""(.*?)"" version=""(.*?)"" targetFramework=""net451"" />");
            foreach(Match match in reg.Matches(source))
            {
                var m = "install-package " + match.Groups[1] + " -v " + match.Groups[2];
                sb.Add(m);
                Console.WriteLine(m);
            }
            if (File.Exists(dest))
            {
                File.Delete(dest);
            }
            File.AppendAllText(dest, string.Join("\r\n", sb));
            Console.ReadKey();
        }
    }
}
