namespace SilentMike.Gielda.Commision.Infrastructure.UnitTests;

using System.Reflection;
using MediatR;

[TestClass]
public sealed class MediatRUnitTests
{
    private static readonly Type NOTIFICATION_HANDLER_TYPE = typeof(INotificationHandler<>);
    private static readonly Type NOTIFICATION_TYPE = typeof(INotification);

    private static readonly List<Type> REQUEST_HANDLER_TYPES =
    [
        typeof(IRequestHandler<,>),
        typeof(IRequestHandler<>),
    ];

    private static readonly List<Type> REQUEST_TYPES =
    [
        typeof(IRequest<>),
        typeof(IRequest<object?>),
    ];

    [TestMethod]
    public void Should_Contain_Handler_For_All_Notifications()
    {
        //GIVEN
        var types = LoadTypes();

        var notificationTypes = types
            .Where(type => NOTIFICATION_TYPE.IsAssignableFrom(type))
            .ToList();

        //WHEN
        var handlerTypes = types
            .Where(type => type.GetInterfaces().Any(interfaceType => interfaceType.IsGenericType && interfaceType.GetGenericTypeDefinition() == NOTIFICATION_HANDLER_TYPE))
            .ToList();

        //THEN
        var errors = new List<string>();

        foreach (var notificationType in notificationTypes)
        {
            var existsHandler = handlerTypes
                .Any(handler => handler.GetInterfaces()
                    .Any(type => type.GenericTypeArguments
                        .Any(argument => argument == notificationType)));

            if (!existsHandler)
            {
                errors.Add($"Missing handler for notification {notificationType}");
            }
        }

        errors.Should()
            .BeEmpty();
    }

    [TestMethod]
    public void Should_Contain_Single_Handler_For_All_Requests_And_Queries()
    {
        //GIVEN
        var types = LoadTypes();

        var requestTypes = new List<Type>();

        foreach (var type in types)
        {
            var isRequestType = typeof(IBaseRequest).IsAssignableFrom(type);

            if (isRequestType)
            {
                requestTypes.Add(type);
            }
        }

        //WHEN
        var handlerTypes = new List<Type>();

        foreach (var type in types)
        {
            var handlerInterface = type.GetInterfaces()
                .Where(interfaceType => interfaceType.IsGenericType)
                .SingleOrDefault(interfaceType => REQUEST_HANDLER_TYPES.Contains(interfaceType.GetGenericTypeDefinition()));

            if (handlerInterface is not null)
            {
                handlerTypes.Add(type);
            }
        }

        //THEN
        foreach (var requestType in requestTypes)
        {
            handlerTypes.Should().ContainSingle(type =>
                    type.GetInterfaces().Any(interfaceType => interfaceType.GenericTypeArguments.Any(genericType => genericType == requestType)),
                $"Missing handler for request {requestType}");
        }
    }

    private static List<Type> LoadTypes()
    {
        var types = Assembly.Load(new AssemblyName("SilentMike.Gielda.Commision.Application")).GetTypes().ToList();
        types.AddRange(Assembly.Load(new AssemblyName("SilentMike.Gielda.Commision.Infrastructure")).GetTypes());

        return types;
    }
}
