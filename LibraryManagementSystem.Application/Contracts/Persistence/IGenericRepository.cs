using LibraryManagementSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Application.Contracts.Persistence
{
    /// <summary>
    /// Implementer les IGenericRepository 
    /// </summary>
    /// <typeparam name="T">Prend un Type de BaseEntity</typeparam>
    public  interface IGenericRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// Permet de recuperer toutes les informations 
        /// </summary>
        /// <returns>Une liste du Type passer</returns>
        Task<IReadOnlyList<T>> GetAllAsync();

        /// <summary>
        /// Permet de recuperer un type en lui passant son ID
        /// </summary>
        /// <param name="id">Id de l'entité</param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id); 

        Task<T> CreateAsync (T entity);

        Task UpdateAsync (T entity);

        Task DeleteAsync (int id);
        
    }
}
