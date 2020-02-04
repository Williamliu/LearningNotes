using System;
using Xunit;
using Barton.WebPortal.Controllers.Utility;

namespace Barton.UnitTest
{
    public class ValidationHelperTest
    {
        [Theory(DisplayName = "电话正则表达式")]
        [InlineData("+16048889999")]
        [InlineData("+861328674567")]

        //[InlineData("604-888-9999")]
        //[InlineData("(+01)604-666-8888")]
        //[InlineData("604.622.9999")]
        //[InlineData("60468-88666")]
        //[InlineData("60468.88666")]
        //[InlineData("60468 88666")]
        //[InlineData("(00852)3345-3566")]
        //[InlineData("(+852)3345-3566")]
        //[InlineData("001-778.888.9999")]
        public void IsMatch(string phone)
        {
            Assert.True(ValidationHelper.IsMatch(phone, EDataType.Phone));
        }
    }
}
