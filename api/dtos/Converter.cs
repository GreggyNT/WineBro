using api.Entities;
using Mapster;

namespace api.dtos;

public static class Converter<T,V>
{
    public static V ToDto(T value) => value.Adapt<V>();
    public static T FromDto(V value) => value.Adapt<T>();
}