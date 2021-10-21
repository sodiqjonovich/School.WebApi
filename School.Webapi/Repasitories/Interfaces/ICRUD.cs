namespace School.Webapi.Repasitories.Interfaces
{
    public interface ICRUD<T>:ICreate<T>,IRead<T>,
        IUpdate<T>,IDelete<T>
    {
    }
}
