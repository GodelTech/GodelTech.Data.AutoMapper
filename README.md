# GodelTech.Data.AutoMapper

Library for using AutoMapper with GodelTech.Data.

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
