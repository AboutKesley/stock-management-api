using Stock.Domain.Enums;

namespace Stock.Application.Dtos;

public sealed record ItemResponse(
    int Id,
    string Name,
    int Quantity,
    ItemType Type);