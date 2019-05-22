namespace BikeStore.Data.Model
{
    public interface IProcessResult<T> where T : class
    {
        T Content { get; set; }
        string ErrorDescription { get; set; }
        bool HasError { get; set; }
    }

}