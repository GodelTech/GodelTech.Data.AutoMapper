# GodelTech.Data.AutoMapper

## Description
GodelTech.Data.AutoMapper is a .NET library that integrates AutoMapper with GodelTech.Data, providing a seamless way to map data entities. It implements the IDataMapper interface from GodelTech.Data using the AutoMapper NuGet package, allowing efficient and straightforward object-to-object mapping.

## Overview
`GodelTech.Data.AutoMapper` implements [GodelTech.Data](https://github.com/GodelTech/GodelTech.Data) `IDataMapper` interface using [AutoMapper](https://www.nuget.org/packages/AutoMapper) NuGet package. It allows to use mapping of `TEntity` to `TModel`.

```csharp
public class DataMapper : IDataMapper
{
    private readonly IMapper _mapper;

    public DataMapper(IMapper mapper)
    {
        _mapper = mapper;
    }

    public IQueryable<TDestination> Map<TDestination>(IQueryable source)
    {
        return _mapper.ProjectTo<TDestination>(source);
    }
}
```

## License
This project is licensed under the MIT License. See the LICENSE file for more details.