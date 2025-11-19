namespace SLK.TryEdu.Abstract;

public interface IEntity<TypeOfKey>
{
    TypeOfKey Id { get; set; }
}