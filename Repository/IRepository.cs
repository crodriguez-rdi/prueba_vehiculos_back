namespace GestionVehiculos.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(); // Recupera todos los elementos de la tabla.
        Task<T> GetByIdAsync(int id); // Recupera un elemento por su id.
        Task AddAsync(T entity); // Añade un nuevo elemento.
        Task UpdateAsync(T entity); // Actualiza un elemento existente.
        Task DeleteAsync(int id); // Elimina un elemento.
    }
}