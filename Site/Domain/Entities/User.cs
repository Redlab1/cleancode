namespace Domain.Entities;

public sealed class User
{
    private User(Guid id, string name, int age)
    {
        Id = id;
        Name = name;
        Age = age;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int Age { get; private set; }

    public static User Create(string name, int age)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required", nameof(name));
        
        if (age < 0)
            throw new ArgumentException("Age must be greater than or equal to zero", nameof(age));

        return new User(Guid.NewGuid(), name, age);
    }
}