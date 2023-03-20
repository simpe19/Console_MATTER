using Console_MATTER.Contexts;
using Console_MATTER.Models;
using Console_MATTER.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Console_MATTER.Services
{
    internal class MatterService
    {
        private static DataContext _context = new DataContext();

        public static async Task SaveAsync(Matter matter)
        {
            var _matterEntity = new MatterEntity
            {
                Email = matter.Email,
                Department = matter.Department,
                MatterType = matter.MatterType,
                Comment = matter.Comment,
                Status = matter.Status,
                CreatedAt = DateTime.Now,
            };

            var _userEntity = await _context.Users.FirstOrDefaultAsync(x => x.FirstName == matter.FirstName && x.LastName == matter.LastName && x.PhoneNumber == matter.PhoneNumber);
            if (_userEntity != null)
                _matterEntity.UserID = _userEntity.Id;
            else
                _matterEntity.User = new UserEntity
                {
                    FirstName = matter.FirstName,
                    LastName = matter.LastName,
                    PhoneNumber = matter.PhoneNumber
                };

            _context.Add(_matterEntity);
            await _context.SaveChangesAsync();
        }

        public static async Task<IEnumerable<Matter>> GetAllAsync()
        {
            var _matters = new List<Matter>();

            foreach (var _matter in await _context.Matters.Include(x => x.User).ToListAsync())
                _matters.Add(new Matter
                {
                    Id = _matter.Id,
                    Department = _matter.Department,
                    MatterType = _matter.MatterType,
                    Comment = _matter.Comment,
                    CreatedAt = DateTime.Now,
                    FirstName = _matter.User.FirstName,
                    LastName = _matter.User.LastName,
                    Email = _matter.Email,
                    PhoneNumber = _matter.User.PhoneNumber,
                    Status = _matter.Status
                });

            return _matters;
        }

        public static async Task<Matter> GetAsync(string email)
        {
            var _matter = await _context.Matters.Include(x => x.User).FirstOrDefaultAsync(x => x.Email == email);
            if (_matter != null)
                return new Matter
                {
                    Id = _matter.Id,
                    Department = _matter.Department,
                    MatterType = _matter.MatterType,
                    Comment = _matter.Comment,
                    CreatedAt = _matter.CreatedAt,
                    FirstName = _matter.User.FirstName,
                    LastName = _matter.User.LastName,
                    Email = _matter.Email,
                    PhoneNumber = _matter.User.PhoneNumber,
                    Status = _matter.Status
                };

            else
                return null!;
        }
        public static async Task<IEnumerable<Matter>> GetClosedAsync()
        {
            var _matters = new List<Matter>();

            foreach (var _matter in await _context.Matters.Where(x => x.Status == MatterStatus.Closed).Include(x => x.User).ToListAsync())
                _matters.Add(new Matter
                {
                    Id = _matter.Id,
                    Department = _matter.Department,
                    MatterType = _matter.MatterType,
                    Comment = _matter.Comment,
                    Status = _matter.Status
                });

            return _matters;
        }
    

        public static async Task UpdateAsync(Matter matter)
        {
            var _matterEntity = await _context.Matters.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == matter.Id);
            if (_matterEntity != null)
            {

                if (!string.IsNullOrEmpty(matter.Email))
                    _matterEntity.Email = matter.Email;

                if (!string.IsNullOrEmpty(matter.Department))
                    _matterEntity.Department = matter.Department;

                if (!string.IsNullOrEmpty(matter.MatterType))
                    _matterEntity.MatterType = matter.MatterType;

                if (!string.IsNullOrEmpty(matter.Comment))
                    _matterEntity.Comment = matter.Comment;

                if (!string.IsNullOrEmpty(matter.Status))
                    _matterEntity.Status = matter.Status;

                if (!string.IsNullOrEmpty(matter.FirstName) || !string.IsNullOrEmpty(matter.LastName) || !string.IsNullOrEmpty(matter.Email) || !string.IsNullOrEmpty(matter.PhoneNumber))
                {
                    var _userEntity = await _context.Users.FirstOrDefaultAsync(x => x.FirstName == matter.FirstName && x.LastName == matter.LastName && x.PhoneNumber == matter.PhoneNumber);
                    if (_userEntity != null)
                        _matterEntity.UserID = _userEntity.Id;
                    else
                        _matterEntity.User = new UserEntity
                        {
                            FirstName = matter.FirstName,
                            LastName = matter.LastName,
                            PhoneNumber = matter.PhoneNumber
                        };
                }

                    _context.Update(_matterEntity);
                    await _context.SaveChangesAsync();
            }
        }

        public static async Task DeleteAsync(string email)
            {
                var matter = await _context.Matters.Include(x => x.User).FirstOrDefaultAsync(x => x.Email == email);
                if (matter != null)
                {
                    _context.Remove(matter);
                    await _context.SaveChangesAsync();
                }
            }
    }
}



