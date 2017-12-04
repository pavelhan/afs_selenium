using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSelenium
{
    public static class TestCasesData
    {
        public static List<TestCaseData> TestCases
        {
            get
            {
                var testCases = new List<TestCaseData>();

                using (var fs = File.OpenRead(@"users.csv"))
                using (var sr = new StreamReader(fs))
                {
                    string line = string.Empty;
                    while (line != null)
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            string[] split = line.Split(new char[] { ',' },
                                StringSplitOptions.None);

                            String userName = split[0];
                            String password= split[1];

                            var testCase = new TestCaseData(userName).Returns(password);
                            testCases.Add(testCase);
                        }
                    }
                }

                return testCases;
            }
        }

    }
}
