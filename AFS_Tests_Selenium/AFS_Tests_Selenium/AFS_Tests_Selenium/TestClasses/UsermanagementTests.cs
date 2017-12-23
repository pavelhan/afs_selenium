using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AFS_Tests_Selenium
{
    class UsermanagementTests : BaseTest
    {
        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "|DataDirectory|\\usersCreation.csv", "usersCreation#csv",
                DataAccessMethod.Sequential), DeploymentItem("usersCreation.csv"), DeploymentItem("chromedriver.exe")]
        public void createNewUser()
        {

        }
    }
}
