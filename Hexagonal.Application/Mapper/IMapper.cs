namespace Hexagonal.Application.Mapper
{
    public interface IMapper<data_entrada_DTO, Data_Salida_Model>
    {
        public Data_Salida_Model Map(data_entrada_DTO dto);
    }
}
