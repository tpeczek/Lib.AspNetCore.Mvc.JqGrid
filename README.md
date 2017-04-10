# Lib.AspNetCore.Mvc.JqGrid
[![NuGet Lib.AspNetCore.Mvc.JqGrid.Infrastructure](https://badge.fury.io/nu/Lib.AspNetCore.Mvc.JqGrid.Infrastructure.svg)](http://badge.fury.io/nu/Lib.AspNetCore.Mvc.JqGrid.Infrastructure) [![NuGet Lib.AspNetCore.Mvc.JqGrid.Core](https://badge.fury.io/nu/Lib.AspNetCore.Mvc.JqGrid.Core.svg)](http://badge.fury.io/nu/Lib.AspNetCore.Mvc.JqGrid.Core) [![NuGet Lib.AspNetCore.Mvc.JqGrid.DataAnnotations](https://badge.fury.io/nu/Lib.AspNetCore.Mvc.JqGrid.DataAnnotations.svg)](http://badge.fury.io/nu/Lib.AspNetCore.Mvc.JqGrid.DataAnnotations) [![NuGet Lib.AspNetCore.Mvc.JqGrid.Helper](https://badge.fury.io/nu/Lib.AspNetCore.Mvc.JqGrid.Helper.svg)](http://badge.fury.io/nu/Lib.AspNetCore.Mvc.JqGrid.Helper)


A set of libraries which provide support for [Guriddo jqGrid](http://guriddo.net/) and [free jqGrid](https://github.com/free-jqgrid/jqGrid) usage in ASP.NET Core.

<a href='https://pledgie.com/campaigns/33551'><img alt='Click here to lend your support to: Lib.AspNetCore.Mvc.JqGrid and make a donation at pledgie.com !' src='https://pledgie.com/campaigns/33551.png?skin_name=chrome' border='0' ></a>

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

## Demos

There is a demo project available [here](https://github.com/tpeczek/Demo.AspNetCore.JqGrid).

## Donating
Lib.AspNetCore.Mvc.JqGrid is a personal open source project. If Lib.AspNetCore.Mvc.JqGridc has been helpful to you, consider donating. Donating helps support Lib.AspNetCore.Mvc.JqGrid.

<a href='https://pledgie.com/campaigns/33551'><img alt='Click here to lend your support to: Lib.AspNetCore.Mvc.JqGrid and make a donation at pledgie.com !' src='https://pledgie.com/campaigns/33551.png?skin_name=chrome' border='0' ></a>

## Copyright and License

Copyright © 2016 - 2017 Tomasz Pęczek

Licensed under the [MIT License](https://github.com/tpeczek/Lib.AspNetCore.Mvc.JqGrid/blob/master/LICENSE.md)
