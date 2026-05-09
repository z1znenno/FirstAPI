namespace FirstAPI.Models.Responses
{
    public class TokenResponse
    {
        public int StatusCode { get; set; }
        public string? Token { get; set; }

        public TokenResponse(int statusCode, string token)
        {
            StatusCode = statusCode;
            Token = token;
        }
    }
}