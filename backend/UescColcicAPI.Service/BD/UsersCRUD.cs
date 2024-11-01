using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core;
using Microsoft.EntityFrameworkCore;

namespace UescColcicAPI.Services.BD
{
    public class UsersCRUD : IUserCRUD
    {
        private readonly MyDbContext _context;

        public UsersCRUD(MyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Create(User entity)
        {
            if (entity == null) {
                throw new ArgumentNullException(nameof(entity));
            }
            if (_context.Users.Any(x => x.Username == entity.Username)) {
                throw new ArgumentException("Já existe um usuário com este nome de usuário");
            }
            _context.Users.Add(entity);
            _context.SaveChanges(); // Salva as mudanças no banco de dados
        }

        public void Delete(User entity)
        {
            var user = _context.Users.FirstOrDefault(x => x.Username == entity.Username);
            if (user != null) {
                _context.Users.Remove(user);
                _context.SaveChanges(); // Salva as mudanças
            } else {
                throw new ArgumentException("Usuário não encontrado");
            }
        }

        public IEnumerable<User> ReadAll()
        {
            return _context.Users.ToList(); // Retorna todos os usuários do banco de dados
        }

        public User? ReadById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.UserId == id);
        }

        public void Update(User entity)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserId == entity.UserId);
            if (user != null) {
                user.Username = entity.Username;
                user.Password = entity.Password;
                user.Rules = entity.Rules;
                _context.SaveChanges(); // Salva as alterações no banco de dados
            } else {
                throw new ArgumentException("Usuário não encontrado");
            }
        }
    }
}