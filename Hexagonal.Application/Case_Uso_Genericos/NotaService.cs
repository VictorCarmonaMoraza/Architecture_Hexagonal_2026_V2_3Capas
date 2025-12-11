using Hexagonal.Application.Genericos;
using Hexagonal.Domain.Entities;
using Hexagonal.Domain.GenericosDomain;

namespace Hexagonal.Application.Case_Uso_Genericos
{
    public class NotaService : ICommonService<Nota>
    {
        //Repository de Genernicos
        private readonly ICommonRepository<Nota> _notaRepository;

        public NotaService(ICommonRepository<Nota> notaRepository)
        {
            _notaRepository = notaRepository;
        }

        public async Task AddItemAsync(Nota entity)
        {
            await _notaRepository.AddAsync(entity);
        }

        public async Task<IEnumerable<Nota>> GetAllItemsAsync()
        {
            return await _notaRepository.GetAllItemsAsync();
        }

        public async Task<Nota?> GetByIdAsync(int id)
        {
            return await _notaRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateItemById(Nota entity)
        {
            return await _notaRepository.updateItem(entity);
        }
    }
}
