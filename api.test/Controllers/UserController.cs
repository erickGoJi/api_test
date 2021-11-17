using System.Data.SqlClient;
using api.test.ActionFilter;
using api.test.Models.ApiResponse;
using api.test.Models.User;
using AutoMapper;
using biz.test.Entities;
using biz.test.Paged;
using biz.test.Repository.User;
using biz.test.Services.Logger;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.test.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
   private readonly IMapper _mapper;
    private readonly ILoggerManager _logger;
    private readonly IUserRepository _userRepository;
    public UserController(IUserRepository userRepository,
        IMapper mapper,
        ILoggerManager logger)
    {
        _userRepository = userRepository;
        _mapper= mapper;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<ApiResponse<List<UserDto>>> GetAll()
    {
        var response = new ApiResponse<List<UserDto>>();

        try
        {
            response.Result = _mapper.Map<List<UserDto>>(_userRepository.GetAll());
        }
        catch (Exception ex)
        {
            response.Result = null;
            response.Success = false;
            response.Message = "Internal server error";
            _logger.LogError($"Something went wrong: { ex.ToString() }");
            return StatusCode(500, response);
        }

        return Ok(response);
    }

    [HttpGet("{pageNumber}/{pageSize}")]
    public ActionResult<ApiResponse<PagedList<UserDto>>> GetPaged(int pageNumber, int pageSize)
    {
        var response = new ApiResponse<PagedList<UserDto>>();

        try
        {
            response.Result = _mapper.Map<PagedList<UserDto>>
                (_userRepository.GetAllPaged(pageNumber, pageSize));
        }
        catch (Exception ex)
        {
            response.Result = null;
            response.Success = false;
            response.Message = ex.ToString();
            _logger.LogError($"Something went wrong: { ex.ToString() }");
            return StatusCode(500, response);
        }

        return Ok(response);
    }

    [HttpGet("{id}", Name = "GetUser")]
    public ActionResult<ApiResponse<UserDto>> GetById(int id)
    {
        var response = new ApiResponse<UserDto>();

        try
        {
            response.Result = _mapper.Map<UserDto>(_userRepository.Find(c => c.Id == id));
        }
        catch (Exception ex)
        {
            response.Result = null;
            response.Success = false;
            response.Message = "Internal server error";
            _logger.LogError($"Something went wrong: { ex.ToString() }");
            return StatusCode(500, response);
        }

        return Ok(response);
    }

    [HttpPost]
    [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
    public ActionResult<ApiResponse<UserDto>> Create(UserDto item)
    {
        var response = new ApiResponse<UserDto>();

        try
        {
            if (_userRepository.Exists(c => c.Email == item.Email))
            {
                response.Success = false;
                response.Message = $"Email: { item.Email } Already Exists";
                return BadRequest(response);
            }

            User user = _userRepository.Add(_mapper.Map<User>(item));
            response.Result = _mapper.Map<UserDto>(user);
        }
        catch (Exception ex)
        {
            response.Result = null;
            response.Success = false;
            response.Message = ex.ToString();
            _logger.LogError($"Something went wrong: { ex.ToString() }");
            return StatusCode(500, response);
        }

        return StatusCode(201, response);
    }

    [HttpPut("Recovery_password", Name = "Recovery_password")]
    public async Task<ActionResult<ApiResponse<UserDto>>> Recovery_password(string email)
    {
        var response = new ApiResponse<UserDto>();

        try
        {
            var _user = _mapper.Map<User>(_userRepository.Find(c => c.Email == email));

            if (_user != null)
            {

                var guid = Guid.NewGuid().ToString().Substring(0, 7);
                var password = _userRepository.HashPassword("$" + guid);

                _user.Password = password;
                _user.UpdatedBy = _user.Id;
                _user.UpdatedDate = DateTime.Now;

                _userRepository.Update(_mapper.Map<User>(_user), _user.Id);

                StreamReader reader = new StreamReader(Path.GetFullPath("TemplateMail/Email.html"));
                string body = string.Empty;
                body = reader.ReadToEnd();
                body = body.Replace("{user}", _user.Name + " " + _user.LastName + " " + _user.MotherName);
                body = body.Replace("{username}", $"{_user.Email}");
                body = body.Replace("{pass}", "$" + guid);

                _userRepository.SendMail(_user.Email, body, "Recovery password");

                response.Result = _mapper.Map<UserDto>(_user);
                response.Success = true;
                response.Message = "success";
            }
            else
            {
                response.Success = false;
                response.Message = "Hubo un error";

            }

        }
        catch (Exception ex)
        {
            response.Result = null;
            response.Success = false;
            response.Message = ex.ToString();
            _logger.LogError($"Something went wrong: { ex.ToString() }");
            return StatusCode(500, response);
        }

        return Ok(response);
    }

    [HttpPut("Change_password", Name = "Change_password")]
    public ActionResult<ApiResponse<UserDto>> Change_password(string email, string password)
    {
        var response = new ApiResponse<UserDto>();

        try
        {
            var _user = _mapper.Map<User>(_userRepository.Find(c => c.Email == email));

            if (_user != null)
            {
                var guid = Guid.NewGuid().ToString().Substring(0, 7);
                var passwordNew = _userRepository.HashPassword(password);

                _user.Password = passwordNew;
                _user.UpdatedBy = _user.Id;
                _user.UpdatedDate = DateTime.Now;
                _userRepository.Update(_mapper.Map<User>(_user), _user.Id);

                response.Result = _mapper.Map<UserDto>(_user);
                response.Result.Token = _userRepository.BuildToken(_user);
                response.Success = true;
                response.Message = "success";

                StreamReader reader = new StreamReader(Path.GetFullPath("TemplateMail/Email.html"));
                string body = string.Empty;
                body = reader.ReadToEnd();
                body = body.Replace("{user}", _user.Name + " " + _user.LastName + " " + _user.MotherName);
                body = body.Replace("{username}", $"{_user.Email}");
                body = body.Replace("{pass}", password);
                _userRepository.SendMail(_user.Email, body, "Change password");
            }
            else
            {
                response.Success = false;
                response.Message = "Usuario y/o contraseña incorrecta";

            }

        }
        catch (Exception ex)
        {
            response.Result = null;
            response.Success = false;
            response.Message = "Internal server error";
            _logger.LogError($"Something went wrong: { ex.ToString() }");
            return StatusCode(500, response);
        }

        return Ok(response);
    }

    [HttpPost("Login", Name = "Login")]
    public async Task<ActionResult<ApiResponse<UserReturnDto>>> Login(string email, string password)
    {
        var response = new ApiResponse<UserReturnDto>();

        try
        {
            var _user = _mapper.Map<User>(_userRepository.Find(c => c.Email == email));
            if (_user != null)
            {
                if (_userRepository.VerifyPassword(_user.Password, password))
                {
                    var userData = _mapper.Map<UserDto>(_user);
                    UserReturnDto userReturnDto = new UserReturnDto()
                    {
                        Email = userData.Email,
                        Password = userData.Password,
                        Id = userData.Id,
                        LastName = userData.LastName,
                        MotherName = userData.MotherName,
                        Name = userData.Name,
                        RoleId = userData.RoleId,
                        Token = userData.Token,
                        //Branch = _iRHTrabRepository.GetBranchId(userData.ClabTrab.Value),
                        //BranchName = _iRHTrabRepository.GetBranchName(userData.ClabTrab.Value),
                    };
                    response.Result = userReturnDto;
                    response.Result.Token = _userRepository.BuildToken(_user);
                    response.Success = true;
                    response.Message = "Success";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Usuario y/o contraseña incorrecta";
                }
            }
            else
            {
                response.Success = false;
                response.Message = "Usuario y/o contraseña incorrecta";

            }

        }
        catch (Exception ex)
        {
            response.Result = null;
            response.Success = false;
            response.Message = "Internal server error";
            _logger.LogError($"Something went wrong: { ex.ToString() }");
            return StatusCode(500, response);
        }

        return Ok(response);
    }

    [HttpPut("{id}")]
    [ServiceFilterAttribute(typeof(ValidationFilterAttribute))]
    public ActionResult<ApiResponse<UserDto>> Update(int id, UserDto item)
    {
        var response = new ApiResponse<UserDto>();

        try
        {
            var user = _userRepository.Find(c => c.Id == id);

            if (user != null)
            {
                response.Message = $"User id { id } Not Found";
                return NotFound(response);
            }

            var userUpdate = _mapper.Map<User>(item);
            _userRepository.Update(userUpdate, item.Id);
            _userRepository.Save();
        }
        catch (Exception ex)
        {
            response.Result = null;
            response.Success = false;
            response.Message = "Internal server error";
            _logger.LogError($"Something went wrong: { ex.ToString() }");
            return StatusCode(500, response);
        }

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public ActionResult<ApiResponse<UserDto>> Delete(int id)
    {
        var response = new ApiResponse<UserDto>();

        try
        {
            var user = _userRepository.Find(c => c.Id == id);

            if (user == null)
            {
                response.Message = $"User id { id } Not Found";
                return NotFound(response);
            }

            _userRepository.Delete(user);
        }
        catch (DbUpdateException ex)
        {
            var sqlException = ex.GetBaseException() as SqlException;
            if (sqlException != null)
            {
                var number = sqlException.Number;
                if (number == 547)
                {
                    response.Result = null;
                    response.Success = false;
                    response.Message = "Operation Not Permitted";
                    _logger.LogError("Operation Not Permitted");
                    return StatusCode(490, response);
                }
            }
        }
        catch (Exception ex)
        {
            response.Result = null;
            response.Success = false;
            response.Message = "Internal server error";
            _logger.LogError($"Something went wrong: { ex.ToString() }");
            return StatusCode(500, response);
        }

        return Ok(response);
    }
}