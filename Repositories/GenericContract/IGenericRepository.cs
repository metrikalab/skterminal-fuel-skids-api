namespace skterminal_fuel_skids_api.Repositories.GenericContract
{
  public interface IGenericRepository<T> where T : class
  {
    Task<List<TResult>> GetAllEnabledAsync<TResult>();
    Task<List<TResult>> GetAllEnabledAndVisibleAsync<TResult>();
    Task<TResult?> GetByIdAsync<TResult>(Guid? id);
    Task<T> AddAsync(T source);
    Task<TResult> AddAsync<TSource, TResult>(TSource source);
    Task<T?> GetAsync(Guid? id);
    Task UpdateAsync(T entity);
    Task UpdateAsync<TSource>(Guid id, TSource source);
    Task<bool> Exists(Guid id);

    #region DeleteMethods
    Task DeleteAsync(Guid id);
    Task SoftDeleteAsync(Guid id, bool value);
    #endregion
  }
}
