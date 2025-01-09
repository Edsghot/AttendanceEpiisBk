namespace AttendanceEpiisBk.Model.Dtos.Response;

public record ResponseDto<T>
{
    public bool Success { get;set;}
    public string Message { get;set;} = string.Empty;
    public T Data { get; set; } = default!;
}