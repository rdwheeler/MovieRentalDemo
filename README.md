# Commerce

This is a boilerplate project intended as a launchpad for general commerce-oriented projects. It demonstrates what we feel are the current state-of-the-art patterns and practices we will probably use in any such project. The goal is a toolbox with the *most likely* patterns we would use. As such it includes minimal versions of:
Domain-driven Design, CQRS, and just enough inter-service messaging.

- `Domain-driven Design` The highest level division of the application's logic is into an Interface layer and an Infrastructure layer. We just want the bones of this pattern for now, to facilitate breaking down business requirements into user-facing things and backend activities.
  - The Interface: each entry point should represent a use case, stuff the user would want to do.
  - Infrastructure: all the tools/utilities/resources (repositories, external services, message brokers, etc) that will perform the activities necessary to accomplish use cases.

- `Command and Query Responsibility Segregation` This framework makes us separate components into command and query parts. That may be bloat at first, but getting into this pattern early makes thigs simpler as the app grows.

- `Microservices` We should be able to logically divide tools in Infrastructure into discrete projects, independently deployable and loosely coupled to their consumers.

# Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download/dotnet/6.0): 6.0.100-preview.5.21271.2
- [nodejs](https://nodejs.org/en/download): v15.5.1
- [tye](https://github.com/dotnet/tye): 0.8.0-alpha.21301.1+0fed0b38e730cd07caf0a90287090638c110b77d
  - Follow the guidance at https://github.com/dotnet/tye/blob/647a608892/docs/getting_started.md#working-with-ci-builds
  - Specifically, running `dotnet tool install -g Microsoft.Tye --version "0.8.0-*" --add-source https://pkgs.dev.azure.com/dnceng/public/_packaging/dotnet5/nuget/v3/index.json`
- [dapr](https://dapr.io/): 1.2.0
- [dev cert](https://docs.microsoft.com/en-us/dotnet/core/additional-tools/self-signed-certificates-guide) To trust the default ID server certificate, run 'dotnet dev-certs https --trust'

# Technical stacks
- ✔️ **[`.NET Core 6`](https://dotnet.microsoft.com/download)** - .NET Framework and .NET Core, including ASP.NET and ASP.NET Core
- ✔️ **[`MVC Versioning API`](https://github.com/microsoft/aspnet-api-versioning)** - Set of libraries which add service API versioning to ASP.NET Web API, OData with ASP.NET Web API, and ASP.NET Core
- ✔️ **[`YARP`](https://github.com/microsoft/reverse-proxy)** - A toolkit for developing high-performance HTTP reverse proxy applications
- ✔️ **[`MediatR`](https://github.com/jbogard/MediatR)** - Simple, unambitious mediator implementation in .NET
- ✔️ **[`EF Core`](https://github.com/dotnet/efcore)** - Modern object-database mapper for .NET. It supports LINQ queries, change tracking, updates, and schema migrations
- ✔️ **[`FluentValidation`](https://github.com/FluentValidation/FluentValidation)** - Popular .NET validation library for building strongly-typed validation rules
- ✔️ **[`Swagger & Swagger UI`](https://github.com/domaindrivendev/Swashbuckle.AspNetCore)** - Swagger tools for documenting API's built on ASP.NET Core
- ✔️ **[`serilog`](https://github.com/serilog/serilog)** - Simple .NET logging with fully-structured events
- ✔️ **[`Dapr dotnet-sdk`](https://github.com/dapr/dotnet-sdk)** - Dapr SDK for .NET
- ✔️ **[`RestEase`](https://github.com/canton7/RestEase)** - Easy-to-use typesafe REST API client library for .NET Standard 1.1 and .NET Framework 4.5 and higher, which is simple and customisable
- ✔️ **[`Polly`](https://github.com/App-vNext/Polly)** - Polly is a .NET resilience and transient-fault-handling library that allows developers to express policies such as Retry, Circuit Breaker, Timeout, Bulkhead Isolation, and Fallback in a fluent and thread-safe manner
- ✔️ **[`Scrutor`](https://github.com/khellang/Scrutor)** - Assembly scanning and decoration extensions for Microsoft.Extensions.DependencyInjection
- ✔️ **[`opentelemetry-dotnet`](https://github.com/open-telemetry/opentelemetry-dotnet)** - The OpenTelemetry .NET Client
- ✔️ **[`BFF`](https://github.com/DuendeSoftware/BFF)** - Framework for ASP.NET Core to secure SPAs using the Backend-for-Frontend (BFF) pattern
# Starting the APIs

```
$ cd microservices
$ tye run
```

- Public Apis:

> Tye Dashboard: [http://localhost:8000](http://localhost:8000)
>
> Play around at [restclient.http](microservices/restclient.http). Test uname/pass 'bob'/'bob'.

<table>
  <thead>
    <th>No.</th>
    <th>Service name</th>
    <th>Service uri</th>
  </thead>
  <tbody>
    <tr>
      <td>1</td>
      <td>YARP Gateway (downstream)</td>
      <td><a href="http://localhost:5000">http://localhost:5000</a></td>
    </tr>
    <tr>
      <td>2</td>
      <td>identity server</td>
      <td><a href="https://localhost:5001">https://localhost:5001</a></td>
    </tr>
    <tr>
      <td>4</td>
      <td>product (upstream service)</td>
      <td><a href="http://localhost:5003">http://localhost:5003</a></td>
    </tr>
    <tr>
      <td>5</td>
      <td>customer (upstream service)</td>
      <td><a href="http://localhost:5004">http://localhost:5004</a></td>
    </tr>
    <tr>
      <td>6</td>
      <td>setting (upstream service)</td>
      <td><a href="http://localhost:5005">http://localhost:5005</a></td>
    </tr>
    <tr>
      <td>6</td>
      <td>rental (upstream service)</td>
      <td><a href="http://localhost:5006">http://localhost:5006</a></td>
    </tr>
  </tbody>
</table>

# Additional parts
## Public CRUD interface

Generic reusable CRUD interface

### Common

```csharp
public record ResultModel<T>(T Data, bool IsError = false, string? ErrorMessage = default);
```

```csharp
public interface ICommand<T> : IRequest<ResultModel<T>> {}
```

```csharp
public interface IQuery<T> : IRequest<ResultModel<T>> {}
```

### ✔️ Retrieve

```csharp
// input model for list query (paging, filtering and sorting)
public interface IListQuery<TResponse> : IQuery<TResponse>
{
  public List<string> Includes { get; init; }
  public List<FilterModel> Filters { get; init; }
  public List<string> Sorts { get; init; }
  public int Page { get; init; }
  public int PageSize { get; init; }
}
```

```csharp
// output model with items, total items, page and page size
public record ListResponseModel<T>(List<T> Items, long TotalItems, int Page, int PageSize);
```

```csharp
public interface IItemQuery<TId, TResponse> : IQuery<TResponse>
{
  public List<string> Includes { get; init; }
  public TId Id { get; init; }
}
```

### Create

```csharp
public interface ICreateCommand<TRequest, TResponse> : ICommand<TResponse>, ITxRequest
{
    public TRequest Model { get; init; }
}
```

### Update

```csharp
public interface IUpdateCommand<TRequest, TResponse> : ICommand<TResponse>, ITxRequest
{
  public TRequest Model { get; init; }
}
```

### Delete

```csharp
public interface IDeleteCommand<TId, TResponse> : ICommand<TResponse> where TId : struct
{
  public TId Id { get; init; }
}
```

## Dapr components
### Service Invocation

- RestEase with Dapr handler.

### Event Bus

```csharp
public interface IEventBus
{
  Task PublishAsync<TEvent>(TEvent @event, string[] topics = default, CancellationToken token = default) where TEvent : IDomainEvent;

  Task SubscribeAsync<TEvent>(string[] topics = default, CancellationToken token = default) where TEvent : IDomainEvent;
}
```

- Dapr provider

### ✔️ Transactional Outbox

```csharp
public class OutboxEntity
{
    [JsonInclude]
    public Guid Id { get; private set; }

    [JsonInclude]
    public DateTime OccurredOn { get; private set; }

    [JsonInclude]
    public string Type { get; private set; }

    [JsonInclude]
    public string Data { get; private set; }

    public OutboxEntity()
    {
        // used by System.Text.Json to deserialize data
    }

    public OutboxEntity(Guid id, DateTime occurredOn, IDomainEvent @event)
    {
        Id = id.Equals(Guid.Empty) ? Guid.NewGuid() : id;
        OccurredOn = occurredOn;
        Type = @event.GetType().FullName;
        Data = JsonConvert.SerializeObject(@event);
    }

    public virtual IDomainEvent RecreateMessage(Assembly assembly) => (IDomainEvent)JsonConvert.DeserializeObject(Data, assembly.GetType(Type)!);
}
```

- Dapr provider
