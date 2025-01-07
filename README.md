# Lib.AspNetCore.Mvc.JqGrid
[![NuGet Lib.AspNetCore.Mvc.JqGrid.Helper](https://badge.fury.io/nu/Lib.AspNetCore.Mvc.JqGrid.Helper.svg)](http://badge.fury.io/nu/Lib.AspNetCore.Mvc.JqGrid.Helper)

A set of libraries which provide support for [Guriddo jqGrid](http://guriddo.net/) and [free jqGrid](https://github.com/free-jqgrid/jqGrid) usage in ASP.NET Core.

This is ASP.NET Core evolution of jqGrid related functionality from [Lib.Web.Mvc](https://github.com/tpeczek/Lib.Web.Mvc/).

- **Lib.AspNetCore.Mvc.JqGrid.Infrastructure** - Classes, enumerations and constants representing jqGrid options. Shared by all libraries.
- **Lib.AspNetCore.Mvc.JqGrid.Core** - The core functionality. If you prefer to write your own JavaScript instead of using strongly typed helper, but you still want some support on the server side for requests and responses this is what you want.
- **Lib.AspNetCore.Mvc.JqGrid.DataAnnotations** - Custom data annotations which allow for providing additional metadata when working with strongly typed helper.
- **Lib.AspNetCore.Mvc.JqGrid.Helper** - The strongly typed helper.

## Getting Started

All the packages are available on [NuGet](https://www.nuget.org/packages/Lib.AspNetCore.Mvc.JqGrid.Helper/). You can drag all packages at once by installing the top level one.

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

## Documentation

The documentation is available [here](https://tpeczek.github.io/Lib.AspNetCore.Mvc.JqGrid/).

## Demos

The demo project is available [here](https://github.com/tpeczek/Demo.AspNetCore.JqGrid).

## Donating

My blog and open source projects are result of my passion for software development, but they require a fair amount of my personal time. If you got value from any of the content I create, then I would appreciate your support by [sponsoring me](https://github.com/sponsors/tpeczek) (either monthly or one-time).

## Copyright and License

Copyright © 2016 - 2025 Tomasz Pęczek

Licensed under the [MIT License](https://github.com/tpeczek/Lib.AspNetCore.Mvc.JqGrid/blob/master/LICENSE.md)
