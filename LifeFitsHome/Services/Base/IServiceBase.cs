using IResult = LifeFitsHome.Utilities.Results.IResult;
namespace LifeFitsHome.Services.Base
{
    public interface IServiceBase<T>
    {
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Delete(T entity);
    }
}