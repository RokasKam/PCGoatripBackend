using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using Academy.Core.Interfaces;
using Academy.Core.Requests.User;
using Academy.Core.Responses.Places;
using Academy.Core.Responses.User;
using Academy.Domain.Entities;
using Academy.Domain.Exceptions;

using AutoMapper;
using ValidationException = Academy.Domain.Exceptions.ValidationException;

namespace Academy.Core.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    private static readonly Encoding HashEncoding = Encoding.UTF8;

    public AuthService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public HashPasswordResponse HashPassword(string password)
    {
        using var hmac = new HMACSHA512();

        var response = new HashPasswordResponse(
            PasswordSalt: hmac.Key,
            PasswordHash: hmac.ComputeHash(HashEncoding.GetBytes(password))
        );

        return response;
    }

    public UserResponse Login(LoginRequest login)
    {
        var user = _userRepository.GetByEmailOrDefault(login.Email);

        if (user is null)
        {
            throw new ValidationException("Incorrect user email");
        }
        
        using var hmac = new HMACSHA512(user.PasswordSalt);
        var computedHash = hmac.ComputeHash(HashEncoding.GetBytes(login.Password));

        if (!computedHash.SequenceEqual(user.PasswordHash))
        {
            throw new Exception("Incorrect user password");
        }
        var response = _mapper.Map<UserResponse>(user);
        return response;
    }

    public RegistrationResponse Register(RegisterRequest register)
    {
        var registerUser = _mapper.Map<User>(register);
        var registerResult = new RegistrationResponse();
        var existingUser = _userRepository.GetByEmailOrDefault(registerUser.Email);
        if (existingUser is not null)
        {
            registerResult.IsRegistered = false;
            throw new ValidationException("User with this email exists");
        }
        var password = HashPassword(register.Password);
        registerUser.PasswordHash = password.PasswordHash;
        registerUser.PasswordSalt = password.PasswordSalt; 
        _userRepository.PostUser(registerUser);
        return registerResult;
    }
}