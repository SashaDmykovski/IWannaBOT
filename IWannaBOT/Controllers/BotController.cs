using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace IWannaBOT.Controllers
{
    [ApiController]
    [Route("bot")]
    public class BotController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string _botToken;
        private readonly string _chatId;

        public BotController(IHttpClientFactory clientFactory, IConfiguration config)
        {
            _clientFactory = clientFactory;
            _botToken = config["Telegram:BotToken"] ?? string.Empty;
            _chatId = config["Telegram:ChatId"] ?? string.Empty;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] MessageDto dto)
        {
            if (string.IsNullOrEmpty(_botToken) || string.IsNullOrEmpty(_chatId))
                return BadRequest("Bot token or chat id not configured.");

            if (string.IsNullOrWhiteSpace(dto?.Message))
                return BadRequest("Message is empty.");

            var success = await SendTelegramMessage(dto.Message);

            return success ? Ok() : StatusCode(500, "Failed to send message.");
        }

        public class MessageDto
        {
            public string Message { get; set; }
        }

        private async Task<bool> SendTelegramMessage(string text)
        {
            var client = _clientFactory.CreateClient();
            var url = $"https://api.telegram.org/bot{_botToken}/sendMessage";

            var payload = new { chat_id = _chatId, text = text };
            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);

            return response.IsSuccessStatusCode;
        }
    }
}