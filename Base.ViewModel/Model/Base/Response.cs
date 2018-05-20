namespace Base.ViewModel.Model.Base
{
    public class Response<TDataResponse>
    {
        public TDataResponse Data { get; set; }
        public bool Success { get; set; }
        public string[] Errors { get; set; }
    }
}
