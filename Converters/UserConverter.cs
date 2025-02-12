using ElPalacio.Domain.Entities;
using ElPalacio.Domain.IConverter;
using ElPalacio.Domain.ViewModel;
using ElPalacio.Domain.ViewModel.Requests;

namespace ElPalacio.Domain.Converters
{
    public class UserConverter : IConverter<User, UserRequestViewModel, UserViewModel>, IUserConverter
    {
        public UserViewModel Convert(User User)
        {
            var UserViewModel = new UserViewModel
            {
                Id = User.Id,
                FullName = User.FullName,
                Email = User.Email,
                Address = User.Address,
                Active = User.Active,
            };

            return UserViewModel;
        }

        public List<UserViewModel> ConvertList(IEnumerable<User> user)
        {
            return user.Select(b =>
            {
                var model = new UserViewModel
                {
                    Id = b.Id,
                    FullName = b.FullName,
                    Email = b.Email,
                    Address = b.Address,
                    Active = b.Active,
                };

                return model;
            }).ToList();
        }
        public User PrepareAddData(UserRequestViewModel viewModel)
        {
            return new User()
            {
                FullName = viewModel.FullName,
                Email = viewModel.Email,
                Address = viewModel.Address,
                Active = viewModel.Active,
                Password = viewModel.Password,
                CreatedAt = DateTime.Now,
            };
        }

        public User PrepareUpdateData(User entity, UserRequestViewModel viewModel)
        {
            entity.FullName = viewModel.FullName;
            entity.Email = viewModel.Email;
            entity.Address = viewModel.Address;
            entity.Active = viewModel.Active;
            entity.Password = viewModel.Password;
            entity.UpdatedAt = DateTime.Now;

            return entity;
        }
    }
}
