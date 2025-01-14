using AttendanceEpiisBk.Modules.Product.Application.Port;
using AttendanceEpiisBk.Modules.Product.Domain.IRepository;

namespace AttendanceEpiisBk.Modules.Product.Application.Adapter;

public class ProductAdapter : IProductInputPort
{
    private readonly IProductOutPort _eventOutPort;
    private readonly IProductRepository _eventRepository;

    public ProductAdapter(IProductRepository repository, IProductOutPort eventOutPort)
    {
        _eventRepository = repository;
        _eventOutPort = eventOutPort;
    }

}