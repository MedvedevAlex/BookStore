namespace ViewModel.Models.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; } = true;
        public string ErrorMessage { get; set; }
    }
}
