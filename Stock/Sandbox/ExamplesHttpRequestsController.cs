using Microsoft.AspNetCore.Mvc;
using Stock.Dto;

namespace Stock.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExamplesHttpRequestsController : ControllerBase
    {
        private readonly ILogger<ExamplesHttpRequestsController> _logger;

        public ExamplesHttpRequestsController(ILogger<ExamplesHttpRequestsController> logger)
        {
            _logger = logger;
        }

        // FromRoute: rota com parâmetro no caminho
        [HttpGet("route/{id}")]
        public ActionResult<ItemDto> GetByRoute([FromRoute] string id)
        {
            return Ok(new ItemDto { Name = $"FromRoute id={id}", Quantity = 1 });
        }

        // FromQuery: parâmetros vindos da query string
        // Ex.: GET /examples/query?id=abc&qty=3
        [HttpGet("query")]
        public ActionResult<ItemDto> GetByQuery([FromQuery] string id, [FromQuery(Name = "qty")] int quantity = 5)
        {
            return Ok(new ItemDto { Name = $"FromQuery id={id}", Quantity = quantity });
        }

        // FromHeader: valor vindo de um header HTTP
        // Ex.: X-Request-Id: 123
        [HttpGet("header")]
        public ActionResult<ItemDto> GetByHeader([FromHeader(Name = "X-Request-Id")] string requestId)
        {
            return Ok(new ItemDto { Name = $"FromHeader requestId={requestId}", Quantity = 2 });
        }

        // FromBody: corpo JSON convertido para o DTO
        [HttpPost("body")]
        public ActionResult<ItemDto> PostBody([FromBody] ItemDto item)
        {
            return Ok(item);
        }

        // FromForm: dados enviados como form-data (application/x-www-form-urlencoded ou multipart/form-data)
        //
        // Observações:
        // - O model binding procura campos do formulário com os nomes dos parâmetros (`name`, `quantity`) e faz a conversão de tipos.
        // - Para enviar via curl: `curl -X POST -F "name=produto" -F "quantity=3" http://.../examples/form`
        // - Use multipart/form-data se também for enviar arquivos no mesmo request.
        // - Valide e sanitize os valores antes de confiar neles (ex.: limites de tamanho, formatos).
        [HttpPost("form")]
        public ActionResult<ItemDto> PostForm([FromForm] string name, [FromForm] int quantity)
        {
            return Ok(new ItemDto { Name = name, Quantity = quantity });
        }

        // Upload de arquivo via form-data (IFormFile) — exemplo assíncrono
        //
        // Observações:
        // - Requer `Content-Type: multipart/form-data`. Exemplo curl:
        //   `curl -X POST -F "file=@/caminho/para/arquivo.txt" http://.../examples/upload`
        // - `IFormFile` é um ponteiro para o arquivo enviado; o conteúdo pode ser lido via `OpenReadStream()` ou `CopyToAsync(...)`.
        // - Não carregue arquivos grandes completamente na memória: trate streams de forma streaming e aplique limites (`RequestSizeLimit` / configurações).
        // - Use `cancellationToken` para permitir cancelamento do envio pelo cliente (útil em operações longas).
        // - Sempre valide tipo MIME, extensão e tamanho; faça verificação/scan se necessário antes de persistir.
        [HttpPost("upload")]
        public async Task<ActionResult> UploadFile([FromForm] IFormFile file, CancellationToken cancellationToken)
        {
            if (file == null) return BadRequest("Nenhum arquivo enviado.");

            _logger.LogInformation("Recebido arquivo {FileName} tamanho={Length}", file.FileName, file.Length);

            // Exemplo simples: apenas lê o stream (sem salvar) de forma segura.
            // Para arquivos grandes prefira `CopyToAsync` para um destino (arquivo, blob storage, etc.).
            using var stream = file.OpenReadStream();
            var length = stream.Length;

            return Ok(new { file.FileName, length });
        }

        // FromServices: injeta um serviço do container diretamente no método
        //
        // Observações:
        // - `[FromServices]` resolve o serviço do DI para aquele método específico (ex.: `IConfiguration`).
        // - É equivalente a receber o serviço via parâmetro do construtor, mas útil para dependências pontuais.
        // - Prefira injeção por construtor para dependências usadas por vários métodos; use `[FromServices]` para casos esporádicos.
        [HttpGet("service")]
        public ActionResult<ItemDto> FromServices([FromServices] IConfiguration configuration)
        {
            var env = configuration["ASPNETCORE_ENVIRONMENT"] ?? "unknown";
            return Ok(new ItemDto { Name = $"FromServices env={env}", Quantity = 0 });
        }

        // Leitura de cookie via Request.Cookies (não existe [FromCookie] por padrão)
        //
        // Observações:
        // - Cookies são strings; podem estar ausentes ou vazios — sempre trate a ausência (`TryGetValue`).
        // - Não confie cegamente no valor do cookie: é controlado pelo cliente. Valide/assine/encripte dados sensíveis.
        // - Para cookies de autenticação use mecanismos seguros (cookie authentication, Identity) com flags `HttpOnly` e `Secure`.
        [HttpGet("cookies")]
        public ActionResult<ItemDto> FromCookies()
        {
            Request.Cookies.TryGetValue("sessionId", out var sessionId);
            return Ok(new ItemDto { Name = $"Cookie sessionId={sessionId}", Quantity = 0 });
        }
    }
}