using Microsoft.VisualStudio.TestTools.UnitTesting;
using GyCodeTemplate.Models.ViewModels;
using GyCodeTemplate.Service.Interface;

namespace GyCodeTemplate.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private IUserInfoService _service;
        [TestMethod]
        public void TestMethod1()
        {
            VUserListCondition input = new VUserListCondition();
            input.offset = 1;
            input.limit = 5;

            //VUserList list=_service.GetUserInfoList(input);

        }
    }
}
