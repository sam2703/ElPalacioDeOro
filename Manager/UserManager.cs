using ElPalacio.Domain.Entities;
using ElPalacio.Domain.IConverter;
using ElPalacio.Domain.IManager;
using ElPalacio.Domain.IRepository;
using ElPalacio.Domain.ViewModel;
using ElPalacio.Domain.ViewModel.Requests;

namespace ElPalacio.Domain.Manager
{
    public class UserManager : BaseManager<User, UserRequestViewModel, UserViewModel>, IUserManager
    {
        private readonly IUserRepository _repository;
        private readonly IUserConverter _converter;

        public UserManager(IUserConverter converter, IUserRepository repository) : base(converter, repository)
        {
            _converter = converter;
            _repository = repository;
        }
    }
}