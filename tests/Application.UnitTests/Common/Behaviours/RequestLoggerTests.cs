using Exile_Pinboard.Application.Common.Behaviours;
using Exile_Pinboard.Application.Common.Interfaces;
using Exile_Pinboard.Application.WidgetDefinitions.Commands.CreateWidgetDefinition;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;

namespace Exile_Pinboard.Application.UnitTests.Common.Behaviours;

public class RequestLoggerTests
{
    private Mock<ILogger<CreateWidgetDefinitionCommand>> _logger = null!;
    private Mock<IUser> _user = null!;
    private Mock<IIdentityService> _identityService = null!;

    [SetUp]
    public void Setup()
    {
        _logger = new Mock<ILogger<CreateWidgetDefinitionCommand>>();
        _user = new Mock<IUser>();
        _identityService = new Mock<IIdentityService>();
    }

    [Test]
    public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
    {
        _user.Setup(x => x.Id).Returns(Guid.NewGuid().ToString());

        var requestLogger = new LoggingBehaviour<CreateWidgetDefinitionCommand>(_logger.Object, _user.Object, _identityService.Object);

        await requestLogger.Process(new CreateWidgetDefinitionCommand { Name = "Item price", Code = "item-price" }, new CancellationToken());

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Once);
    }

    [Test]
    public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
    {
        var requestLogger = new LoggingBehaviour<CreateWidgetDefinitionCommand>(_logger.Object, _user.Object, _identityService.Object);

        await requestLogger.Process(new CreateWidgetDefinitionCommand { Name = "Item price", Code = "item-price" }, new CancellationToken());

        _identityService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Never);
    }
}
