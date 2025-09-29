using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using skterminal_fuel_skids_api.Configurations.CustomHttpResponses;
using skterminal_fuel_skids_api.Configurations.Databases;
using skterminal_fuel_skids_api.Utils.Validations;

namespace skterminal_fuel_skids_api.Repositories.GenericContract
{
  public class GenericRepository<T> : IGenericRepository<T> where T : class
  {
    private readonly DataContextEntityFramework _contextEntityFramework;
    private readonly IMapper _mapper;

    public GenericRepository(DataContextEntityFramework contextEntityFramework, IMapper mapper)
    {
      _contextEntityFramework = contextEntityFramework;
      _mapper = mapper;
    }

    public async Task<List<TResult>> GetAllEnabledAsync<TResult>()
    {
      var response = await _contextEntityFramework.Set<T>()
        .Where(x => EF.Property<bool>(x, "Enabled") == true)
        .ProjectTo<TResult>(_mapper.ConfigurationProvider)
        .OrderBy(x => EF.Property<string>(x!, "CreationDate"))
        .ToListAsync();

      if (response == null)
        throw new NoContentException("No se ha encontrado ningún resultado ");

      return response;
    }

    public async Task<List<TResult>> GetAllEnabledAndVisibleAsync<TResult>()
    {
      var response = await _contextEntityFramework.Set<T>()
        .Where(x => EF.Property<bool>(x, "Enabled") == true &&
                    EF.Property<bool>(x, "Visible"))
        .ProjectTo<TResult>(_mapper.ConfigurationProvider)
        .OrderBy(x => EF.Property<string>(x!, "CreationDate"))
        .ToListAsync();

      if (response == null)
        throw new NoContentException("No se ha encontrado ningún resultado");

      return response;
    }

    public async Task<TResult?> GetByIdAsync<TResult>(Guid? id)
    {
      var result = await _contextEntityFramework.Set<T>().FindAsync(id);
      if (result is null)
        return default;

      return _mapper.Map<TResult>(result);
    }

    public async Task<T> AddAsync(T source)
    {
      try
      {
        await _contextEntityFramework.AddAsync(source);
      }
      catch (DbUpdateException ex)
      {
        throw new KeyValueDuplicatedException($"El valor u objeto que se intenta insertar ya existe en la base de datos. Más detalles: {ex}");
      }
      await _contextEntityFramework.SaveChangesAsync();

      return source;
    }

    public async Task<TResult> AddAsync<TSource, TResult>(TSource source)
    {
      throw new NotImplementedException();
    }

    public async Task<T?> GetAsync(Guid? id)
    {
      if (id is null)
        throw new Exception("No Key Provided");

      return await _contextEntityFramework.Set<T>().FindAsync(id);
    }

    public async Task<bool> Exists(Guid id)
    {
      var entity = await GetByIdAsync<T>(id);
      return entity != null;
    }

    public async Task UpdateAsync(T entity)
    {
      _contextEntityFramework.Update(entity);
      await _contextEntityFramework.SaveChangesAsync();
    }

    public async Task UpdateAsync<TSource>(Guid id, TSource source)
    {
      var entity = await GetAsync(id);

      if (entity == null)
        throw new NoContentException("No se encontro la entidad");

      _mapper.Map(source, entity);
      _contextEntityFramework.Update(entity);
      await _contextEntityFramework.SaveChangesAsync();
    }

    #region DeleteMethods
    public async Task DeleteAsync(Guid id)
    {
      var entity = await GetAsync(id);
      if (entity != null)
      {
        _contextEntityFramework.Set<T>().Remove(entity);
        await _contextEntityFramework.SaveChangesAsync();
      }
    }

    public async Task SoftDeleteAsync(Guid id, bool value)
    {
      var entity = await GetAsync(id);

      if (entity == null)
        throw new NoContentException("No se encontro la entidad");

      var enabledProperty = entity.GetType().GetProperty("Enabled");
      if (!enabledProperty.IsDifferentToNull())
        throw new NoContentException("Hubo un error al obtener el campo Enabled de la base de datos");

      enabledProperty!.SetValue(entity, value);

      _contextEntityFramework.Update(entity);
      await _contextEntityFramework.SaveChangesAsync();
    }
    #endregion
  }
}
