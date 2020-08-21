using System;

namespace ViewModel.Interfaces.Repositories
{
    public interface IUserInfoRepository
    {
        Guid GetUserIdFromToken();
    }
}