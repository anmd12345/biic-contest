namespace BIIC_Contest.Services.I
{
    internal interface IBaseService
    {
        dynamic toDto(dynamic model);
        dynamic toModel(dynamic dto);
        dynamic toDtos(dynamic models);
        dynamic toModels(dynamic dtos);

    }
}
