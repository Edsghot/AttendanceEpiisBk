using AttendanceEpiisBk.Model.Dtos.Response;

namespace AttendanceEpiisBk.Configuration.Shared;

public class BasePresenter<T> : IBasePresenter<T>
{
    public virtual ResponseDto<T>? GetResponse { get; set; }

    public void Success(T data, string message = "Operacion exitosa!")
    {
        GetResponse = new ResponseDto<T>
        {
            Success = true,
            Message = message,
            Data = data
        };
    }

    public void SuccessMessage(string message = "Operacion exitosa")
    {
        GetResponse = new ResponseDto<T>
        {
            Success = true,
            Message = message,
            Data = default
        };
    }
    public void NotFound(string message = "No se encontro la data")
{
    GetResponse = new ResponseDto<T>
    {
        Success = true,
        Message = message,
        Data = typeof(T) == typeof(IEnumerable<object>) ? (T)(object)new List<object>() : default(T)
    };
}

    public void Error(string message)
    {
        GetResponse = new ResponseDto<T>
        {
            Success = false,
            Message = message,
            Data = default
        };
    }
}