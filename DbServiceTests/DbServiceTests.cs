using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace DbService.Tests;

[TestFixture()]
public class DbServiceTests
{
    DbService service;

    [SetUp]
    public void SetUp()
    {
        service = new DbService();
    }

    [Test()]
    [Repeat(100)]
    public async Task GetAllDataAsyncTest_Success()
    {
        var data = await service.GetAllDataAsync();
        Assert.IsNotNull(data);
    }
}