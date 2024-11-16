using GoodsTnvedApp.Core.Entities;

namespace GoodsTnvedApp.Core.Repositories;

public interface IGoodRepository
{
    Task<Good> GetAll(string code);
}