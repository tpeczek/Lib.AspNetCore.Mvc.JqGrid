# Lib.AspNetCore.Mvc.JqGrid

Lib.AspNetCore.Mvc.JqGrid is a set of libraries which provide support for [Guriddo jqGrid](http://guriddo.net/) and [free jqGrid](https://github.com/free-jqgrid/jqGrid) usage in ASP.NET Core.

## Getting Started

Lib.AspNetCore.Mvc.JqGrid is available on NuGet. You can drag all packages at once by installing the top level one.

```
PM> Install-Package Lib.AspNetCore.Mvc.JqGrid.Helper
```

But you can also install only the needed packages if you don't require the full functionality.

```
PM> Install-Package Lib.AspNetCore.Mvc.JqGrid.Core
```

```
PM> Install-Package Lib.AspNetCore.Mvc.JqGrid.DataAnnotations
```

### Json.NET support

Since ASP.NET Core 3.0, Json.NET is no longer the default JSON framework. The default is now System.Text.Json. The same is the case for Lib.AspNetCore.Mvc.JqGrid.

If yur application requires Newtonsoft.Json-specific features and uses Newtonsoft.Json integration, you need to enable it for Lib.AspNetCore.Mvc.JqGrid as well.

To use Json.NET with Lib.AspNetCore.Mvc.JqGrid:
- Add a package reference to Lib.AspNetCore.Mvc.JqGrid.NewtonsoftJson.

```
<Project Sdk="Microsoft.NET.Sdk.Web">
  ...
  <ItemGroup>
    ...
    <PackageReference Include="Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version="3.0.0" />
    <PackageReference Include="Lib.AspNetCore.Mvc.JqGrid.NewtonsoftJson" Version="3.0.0" />
  </ItemGroup>
  ...
</Project>
```

- Update `Startup.ConfigureServices` to call `AddNewtonsoftJqGrid`.

```
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        ...

        services.AddControllersWithViews();
                .AddNewtonsoftJson();

        services.AddJqGrid();
                .AddNewtonsoftJqGrid();

        ...
    }

    ...
}
```

## Demos

The demo project is available on [GitHub](https://github.com/tpeczek/Demo.AspNetCore.JqGrid).

## Donating

My blog and open source projects are result of my passion for software development, but they require a fair amount of my personal time. If you got value from any of the content I create, then I would appreciate your support by [buying me a coffee](https://www.buymeacoffee.com/tpeczek).

<a href="https://www.buymeacoffee.com/tpeczek"><img src="https://www.buymeacoffee.com/assets/img/custom_images/black_img.png" style="height: 41px !important;width: 174px !important;box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;-webkit-box-shadow: 0px 3px 2px 0px rgba(190, 190, 190, 0.5) !important;"  target="_blank"></a>
