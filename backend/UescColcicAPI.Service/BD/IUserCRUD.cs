using System;
using UescColcicAPI.Core;

namespace UescColcicAPI.Services.BD.Interfaces;

public interface IUserCRUD  : IBaseCRUD<User>
{
    User? ReadByUsername(string username);
}
