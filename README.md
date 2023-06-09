# Dependency Injection Extensions 

[![Build & Deploy NuGet](https://github.com/bnayae/Bnaya.Extensions.DependencyInjection/actions/workflows/Deploy.yml/badge.svg)](https://github.com/bnayae/Bnaya.Extensions.DependencyInjection/actions/workflows/Deploy.yml)  

[![NuGet](https://img.shields.io/nuget/v/Bnaya.Extensions.DependencyInjection.svg)](https://www.nuget.org/packages/Bnaya.Extensions.DependencyInjection/) 


## Keyed Dependency Injection using .NET

You can register your components as:

``` cs
builder.Services.AddKeyedSingleton<IFunctionality, AFunctionality>("A");
builder.Services.AddKeyedSingleton<IFunctionality, BFunctionality>("B");
```

And use it as follow:

``` cs
[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly IKeyed<IFunctionality> _selector;

    public TestController(IKeyed<IFunctionality> selector)
    {
        _selector = selector;
    }

    [HttpGet("a")]
    public string GetA()
    {
        return _selector["A"].Id; // throw if "A" not registered
    }

    [HttpGet("b")]
    public string GetB()
    {
        if(_selector.TryGet("B", out IFunctionality val))
            return val.Id;
        return "Not registered";
    }
}
```


