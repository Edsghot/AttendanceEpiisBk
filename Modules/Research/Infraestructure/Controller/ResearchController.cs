using Microsoft.AspNetCore.Mvc;
using AttendanceEpiisBk.Modules.Research.Application.Port;
using AttendanceEpiisBk.Modules.Teacher.Application.Port;

namespace AttendanceEpiisBk.Modules.Research.Infraestructure.Controller;

[Route("api/[controller]")]
[ApiController]
public class ResearchController : ControllerBase
{
    private readonly IResearchInputPort _researchInputPort;
    private readonly IResearchOutPort _researchOutPort;

    public ResearchController(IResearchInputPort inputPort, IResearchOutPort outPort)
    {
        _researchInputPort = inputPort;
        _researchOutPort = outPort;
    }

    [HttpGet("GetAllResearchProject")]
    public async Task<IActionResult> GetAllResearchProject()
    {
        await _researchInputPort.GetAllResearchProject();
        var response = _researchOutPort.GetResponse;

        return Ok(response);
    }

    [HttpGet("GetAllScientificArticle")]
    public async Task<IActionResult> GetAllScientificArticle()
    {
        await _researchInputPort.GetAllScientificArticle();
        var response = _researchOutPort.GetResponse;

        return Ok(response);
    }

    [HttpGet("pecanoSrc")]
    public IActionResult PecanoSrc()
    {
        var response = new
        {
            message = "ok",
            success = true,
            data = new[]
            {
                // Comprobante correcto
                new
                {
                    NomTipoDocumento = "Factura Electronica",
                    AbrevTipoDocumento = "FA",
                    SerieCompra = "F001",
                    NumCompra = "0001234567",
                    DocumentoProveedor = "20554545743",
                    TipoDocumento = 2,
                    RazonSocial = "REPSOL COMERCIAL S.A.C.",
                    Sucursal = "Av. Javier Prado Este 1234, San Isidro, Lima",
                    FechaEmision = "2024-10-24",
                    FechaVencimiento = "2024-11-11",
                    Moneda = "N",
                    Condicion = "R",
                    Observacion = "Compra de combustibles",
                    Scop = "1234567890",
                    TotalGravadas = 150000.00m,
                    TotalExoneradas = 0.00m,
                    TotalOtrosTributos = 0.00m,
                    TotalPercepcion = 0.00m,
                    TotalIGV = 27000.00m,
                    TotalPagar = 177000.00m,
                    Compras = new[]
                    {
                        new
                        {
                            codigo = "1001",
                            serie = "SERIE001",
                            Tieneserie = true,
                            cantidad = 5000,
                            descripcion = "Gasolina 95",
                            API = 35.00m,
                            temp = 20.0m,
                            precioUnitario = 30.00m,
                            Fise = 0.00m,
                            dscto = 0.00m,
                            ISC = 0.00m,
                            tieneIGV = 1,
                            IGV = 5400.00m,
                            Tratamiento = 10,
                            subTotal = 150000.00m,
                            total = 177000.00m
                        },
                        new
                        {
                            codigo = "1002",
                            serie = "SERIE002",
                            Tieneserie = true,
                            cantidad = 3000,
                            descripcion = "Diesel B5",
                            API = 32.00m,
                            temp = 20.0m,
                            precioUnitario = 25.00m,
                            Fise = 0.00m,
                            dscto = 0.00m,
                            ISC = 0.00m,
                            tieneIGV = 1,
                            IGV = 4500.00m,
                            Tratamiento = 10,
                            subTotal = 75000.00m,
                            total = 88500.00m
                        }
                    },
                    TipoDocReferencia = "Guía de Remisión",
                    CorrelativoReferencia = "GR-123456",
                    FechaEmisionReferencia = "2024-10-22",
                    PlacaTransportista = "ABC-123",
                    LicenciaTransportista = "L-12345678",
                    MarcaTransportista = "VOLVO"
                },
                // Comprobante con error: DocumentoProveedor demasiado largo
                new
                {
                    NomTipoDocumento = "Factura Electronica",
                    AbrevTipoDocumento = "FA",
                    SerieCompra = "F002",
                    NumCompra = "0001234568",
                    DocumentoProveedor = "205545457432055454574320554545743", // Error: demasiado largo
                    TipoDocumento = 2,
                    RazonSocial = "PETROPERU S.A.",
                    Sucursal = "Av. Canaval y Moreyra 123, San Isidro, Lima",
                    FechaEmision = "2024-10-24",
                    FechaVencimiento = "2024-11-11",
                    Moneda = "N",
                    Condicion = "R",
                    Observacion = "Compra de combustibles",
                    Scop = "1234567890",
                    TotalGravadas = 200000.00m,
                    TotalExoneradas = 0.00m,
                    TotalOtrosTributos = 0.00m,
                    TotalPercepcion = 0.00m,
                    TotalIGV = 36000.00m,
                    TotalPagar = 236000.00m,
                    Compras = new[]
                    {
                        new
                        {
                            codigo = "2001",
                            serie = "SERIE003",
                            Tieneserie = true,
                            cantidad = 7000,
                            descripcion = "Gasolina 98",
                            API = 36.00m,
                            temp = 20.0m,
                            precioUnitario = 35.00m,
                            Fise = 0.00m,
                            dscto = 0.00m,
                            ISC = 0.00m,
                            tieneIGV = 1,
                            IGV = 6300.00m,
                            Tratamiento = 10,
                            subTotal = 200000.00m,
                            total = 236000.00m
                        },
                        new
                        {
                            codigo = "2002",
                            serie = "SERIE004",
                            Tieneserie = true,
                            cantidad = 4000,
                            descripcion = "Diesel B5 S50",
                            API = 33.00m,
                            temp = 20.0m,
                            precioUnitario = 28.00m,
                            Fise = 0.00m,
                            dscto = 0.00m,
                            ISC = 0.00m,
                            tieneIGV = 1,
                            IGV = 5040.00m,
                            Tratamiento = 10,
                            subTotal = 112000.00m,
                            total = 131040.00m
                        }
                    },
                    TipoDocReferencia = "Guía de Remisión",
                    CorrelativoReferencia = "GR-123457",
                    FechaEmisionReferencia = "2024-10-22",
                    PlacaTransportista = "DEF-456",
                    LicenciaTransportista = "L-87654321",
                    MarcaTransportista = "SCANIA"
                },
                // Comprobante con error: Scop con longitud incorrecta
                new
                {
                    NomTipoDocumento = "Factura Electronica",
                    AbrevTipoDocumento = "FA",
                    SerieCompra = "F003",
                    NumCompra = "0001234569",
                    DocumentoProveedor = "20554545743",
                    TipoDocumento = 2,
                    RazonSocial = "PRIMAX S.A.",
                    Sucursal = "Av. La Marina 456, San Miguel, Lima",
                    FechaEmision = "2024-10-24",
                    FechaVencimiento = "2024-11-11",
                    Moneda = "N",
                    Condicion = "R",
                    Observacion = "Compra de combustibles",
                    Scop = "123456789012", // Error: debe tener exactamente 10 caracteres
                    TotalGravadas = 180000.00m,
                    TotalExoneradas = 0.00m,
                    TotalOtrosTributos = 0.00m,
                    TotalPercepcion = 0.00m,
                    TotalIGV = 32400.00m,
                    TotalPagar = 212400.00m,
                    Compras = new[]
                    {
                        new
                        {
                            codigo = "3001",
                            serie = "SERIE005",
                            Tieneserie = true,
                            cantidad = 6000,
                            descripcion = "Gasohol 90",
                            API = 34.00m,
                            temp = 20.0m,
                            precioUnitario = 30.00m,
                            Fise = 0.00m,
                            dscto = 0.00m,
                            ISC = 0.00m,
                            tieneIGV = 1,
                            IGV = 5400.00m,
                            Tratamiento = 10,
                            subTotal = 180000.00m,
                            total = 212400.00m
                        },
                        new
                        {
                            codigo = "3002",
                            serie = "SERIE006",
                            Tieneserie = true,
                            cantidad = 5000,
                            descripcion = "Diesel B5 S50",
                            API = 32.00m,
                            temp = 20.0m,
                            precioUnitario = 27.00m,
                            Fise = 0.00m,
                            dscto = 0.00m,
                            ISC = 0.00m,
                            tieneIGV = 1,
                            IGV = 4860.00m,
                            Tratamiento = 10,
                            subTotal = 135000.00m,
                            total = 158220.00m
                        }
                    },
                    TipoDocReferencia = "Guía de Remisión",
                    CorrelativoReferencia = "GR-123458",
                    FechaEmisionReferencia = "2024-10-22",
                    PlacaTransportista = "GHI-789",
                    LicenciaTransportista = "L-11223344",
                    MarcaTransportista = "MERCEDES"
                }
            }
        };
        return Ok(response);
    }


    // GET api/<ResearchController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<ResearchController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<ResearchController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<ResearchController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}