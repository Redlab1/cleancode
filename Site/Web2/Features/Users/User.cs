using System.Net.Mail;

namespace Web2.Features.Users;

public sealed class User
{
    private User(Guid id, string name, int age, string email)
    {
        Id = id;
        Name = name;
        Age = age;
        Email = email;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Email { get; private set; }

    public static User Create(string name, int age, string email)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required", nameof(name));

        if (age < 0)
            throw new ArgumentException("Age must be greater than or equal to zero", nameof(age));

        try
        {
            // Used to check if mailadress is valid
            var unused = new MailAddress(email);
        }
        catch
        {
            throw new ArgumentException("Email is not valid", nameof(email));
        }

        return new User(Guid.NewGuid(), name, age, email);
    }
}