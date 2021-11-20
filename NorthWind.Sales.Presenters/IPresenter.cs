namespace NorthWind.Sales.Presenters
{
    public interface IPresenter<FormatDataType>
    {
        public FormatDataType Content { get; }    
    }
}