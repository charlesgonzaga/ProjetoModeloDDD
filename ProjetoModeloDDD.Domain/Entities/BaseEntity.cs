using ProjetoModeloDDD.Domain.DTOs.InputModels;

namespace ProjetoModeloDDD.Domain.Entities
{
    public abstract class BaseEntity<TPK>
    {
        public TPK Id { get; set; }
    }
}
