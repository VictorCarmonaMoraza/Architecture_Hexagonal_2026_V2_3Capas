namespace Hexagonal.Application.Port_Primary
{
    //la entrada sera un DTO y la salida un modelo
    public interface IAddService<Entrada_data_DTO,Salida_data_Modelo>
    {
        //Haremos una insercion asincrona
        Task AddAsync(Entrada_data_DTO dto);
    }
}
