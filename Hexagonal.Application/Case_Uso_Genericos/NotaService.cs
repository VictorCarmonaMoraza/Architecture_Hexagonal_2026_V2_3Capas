using Hexagonal.Application.Genericos;
using Hexagonal.Domain.Entities;
using Hexagonal.Domain.GenericosDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task UpdateItemById(Nota entity)
        {
            await _notaRepository.updateItem(entity);
        }
    }
}
