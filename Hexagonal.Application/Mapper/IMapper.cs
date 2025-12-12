namespace Hexagonal.Application.Mapper
{
    public interface IMapper<Data_Entrada,Data_Salida>
    {
        public Data_Salida Map(Data_Entrada data_entrada);
    }
}
