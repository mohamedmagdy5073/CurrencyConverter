using Application.Extensions;
using Application.Identity.Dtos;
using Application.Identity.Interfaces;
using Application.Shared.Dtos;
using Application.Shared.Helpers;
using AutoMapper;
using Core.Shared.Exceptions;
using Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Identity
{
    public class IdentityWithJwtService : IIdentityService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JWT _jwt;
        private readonly IMapper _mapper;

        public IdentityWithJwtService(UserManager<AppUser> userManager,
                                      RoleManager<IdentityRole> roleManager,
                                      IOptions<JWT> jwt, IMapper mapper)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwt = jwt.Value;
            _mapper = mapper;
        }

        public async Task<AuthDto> RegisterAsync(RegisterDto model)
        {
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
                throw new BadRequestException("Email is already registered!");

            if (await _userManager.FindByNameAsync(model.Username) is not null)
                throw new BadRequestException("Username is already registered!");

            var user = _mapper.Map<AppUser>(model);

            HandleErrorsIfExists(await _userManager.CreateAsync(user, model.Password));

            HandleErrorsIfExists(await _userManager.AddToRoleAsync(user, Roles.User));

            var jwtSecurityToken = await CreateJwtToken(user);

            return PrepareAuthDto(user, new List<string> { Roles.User }, jwtSecurityToken);
        }

        private void HandleErrorsIfExists(IdentityResult result)
        {
            if (!result.Succeeded)
            {
                var errorsAsText = new StringBuilder();
                result.Errors.ToList().ForEach(error =>
                {
                    errorsAsText.Append(error.Description);
                    errorsAsText.Append("\n");
                });
                throw new BadRequestException(errorsAsText.ToString());
            }
        }

        private AuthDto PrepareAuthDto(AppUser user, List<string> roles, JwtSecurityToken jwtToken)
        {
            return new AuthDto()
            {
                Username = user.UserName,
                Email = user.Email,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                ExpiresOn = jwtToken.ValidTo,
                Roles = roles,
                IsAuthenticated = true
            };
        }

        public async Task<AuthDto> GetTokenAsync(LoginDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user is null || !await _userManager.CheckPasswordAsync(user, model.Password))
                throw new BadRequestException("Email or Password is incorrect!");

            var jwtSecurityToken = await CreateJwtToken(user);
            var roles = (await _userManager.GetRolesAsync(user)).ToList();

            return PrepareAuthDto(user, roles, jwtSecurityToken);
        }

        public async Task<bool> AddRoleAsync(AddRoleToUserDto model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null || !await _roleManager.RoleExistsAsync(model.Role))
                throw new BadRequestException("Invalid user ID or Role");

            if (await _userManager.IsInRoleAsync(user, model.Role))
                throw new BadRequestException("User already assigned to this role");

            HandleErrorsIfExists(await _userManager.AddToRoleAsync(user, model.Role));

            return true;
        }

        public async Task<string> RemoveRoleAsync(AddRoleToUserDto model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user is null || !await _roleManager.RoleExistsAsync(model.Role))
                throw new BadRequestException("Invalid user ID or Role");

            if (!await _userManager.IsInRoleAsync(user, model.Role))
                throw new BadRequestException("User not assigned to this role");

            if (model.Role == Roles.User)
                throw new BadRequestException("Cannot delete this role!");

            HandleErrorsIfExists(await _userManager.RemoveFromRoleAsync(user, model.Role));

            return "Role removed succefully";
        }

        private async Task<JwtSecurityToken> CreateJwtToken(AppUser user)
        {
            var claims = await GetClaims(user);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddDays(_jwt.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

        private async Task<IEnumerable<Claim>> GetClaims(AppUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            return new[]
            {
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim("uid", user.Id)
                    }
            .Union(userClaims)
            .Union(roleClaims);
        }

        public async Task<PagedResponse<UserDto>> GetUsersAsync(int pageNumber = 1, int pageSize = 20)
        {
            IQueryable<UserDto> users = _userManager.Users.Select(u => new UserDto()
            {
                Id = u.Id,
                FirstName = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                PhoneNumber = u.PhoneNumber,
                UserName = u.UserName
            }).OrderBy(a => a.FirstName);

            if (users is null)
                throw new NotFoundException("No users yet!");

            return (await PagedList<UserDto>.ToPagedListAsync(users, pageNumber, pageSize)).ToPagedResponse();
        }
    }
}
