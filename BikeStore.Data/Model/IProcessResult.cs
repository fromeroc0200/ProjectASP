namespace BikeStore.Data.Model
{
    public interface IProcessResult<T> where T :  class
    {
        T Content { get; set; }
        string Description { get; set; }
        bool HasError { get; set; }
    }

    public interface IProcessResult : IProcessResult<object> { }


}