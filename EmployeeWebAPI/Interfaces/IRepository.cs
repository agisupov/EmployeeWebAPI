using Microsoft.AspNetCore.Mvc;

namespace EmployeeWebAPI.Interfaces
{
    public interface IRepository<T>
    {
        Task<ActionResult<List<T>>> Add(T obj);
        Task<ActionResult<List<T>>> Get();
        Task<ActionResult<List<T>>> Get(Guid id);
        Task<ActionResult<List<T>>> Update(T obj);
        Task<ActionResult<List<T>>> Delete(Guid id);
    }
}
