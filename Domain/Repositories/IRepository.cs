using ResultMonad;

namespace CleanModel.Domain.Repositories;

public interface IRepository<Model, CreateModel>
{
  Result<Model> Create(CreateModel createModel);
  Result<Model> Update(Guid guid, CreateModel createModel);
  Result<Model> Find(Guid guid);
  Result<List<Model>> GetAll();
}
