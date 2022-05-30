using TS.Model.Entities;
using TS.Model.ViewModels;

namespace TS.Model.Mappers;

public static class UserMapper
{
    // public static User toEntity(this UserViewModel userViewModel)
    // {
    //     var user = new User
    //     {
    //         Id = userViewModel.Id,
    //         Username = userViewModel.Username,
    //         Password = userViewModel.Password,
    //         FirstName = userViewModel.FirstName,
    //         LastName = userViewModel.LastName
    //     };
    //
    //     return user;
    // }

    public static UserViewModel ToViewModel(this User user)
    {
        var userViewModel = new UserViewModel
        {
            Id = user.Id,
            Username = user.Username,
            Password = user.Password,
            FirstName = user.FirstName,
            LastName = user.LastName
        };

        return userViewModel;
    }

    public static User ToEntity(this UserCreationViewModel userCreationViewModel)
    {
        var user = new User
        {
            Username = userCreationViewModel.Username,
            Password = userCreationViewModel.Password
        };

        return user;
    }

    public static User ToEntity(this UserUpdateViewModel userUpdateViewModel)
    {
        var user = new User
        {
            FirstName = userUpdateViewModel.FirstName,
            LastName = userUpdateViewModel.LastName
        };

        return user;
    }
}