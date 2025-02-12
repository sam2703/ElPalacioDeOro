using ElPalacio.Domain.Entities;
using ElPalacio.Domain.Manager;
using ElPalacio.Domain.ViewModel;
using ElPalacio.Domain.ViewModel.Requests;

namespace ElPalacio.Domain.IManager
{
    public interface IUserManager : IBaseManager<User, UserRequestViewModel, UserViewModel>
    {
    }
}
