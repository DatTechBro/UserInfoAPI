using System.ComponentModel.DataAnnotations;

namespace UserInfoAPI.Shared.ViewModels
{
    public class ResultModel<T>
    {
        public ResultModel()
        { 
        }
        public T Data { get; set; } = default; 
        public string Message { get; set; } 
        public string ErrorMessage { get; set; } 
        public List<ValidationResult> ValidationErrors { get; set; } = new List<ValidationResult>();
        public void AddError(string error)
        {
            ValidationErrors.Add(new ValidationResult(error));
        }
        public int TotalCount { get; set; }

    }
}
