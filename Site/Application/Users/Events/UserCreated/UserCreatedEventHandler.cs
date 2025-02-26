using Application.Data;
using Application.Emails.Commands;
using Domain.DomainEvents;
using Domain.Exceptions;
using MediatR;
using MimeKit;

namespace Application.Users.Events.UserCreated;

internal sealed class UserCreatedEventHandler(IApplicationDbContext dbContext,
    ISender sender) 
    : INotificationHandler<UserCreatedDomainEvent>
{
    public async Task Handle(UserCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var user = await dbContext.Users.FindAsync(notification.UserId, cancellationToken);
        if (user is null)
            throw new EntityNotFoundException(notification.UserId);

        var message = new MimeMessage();
        message.To.Add(new MailboxAddress(user.Email, user.Email));
        message.From.Add(new MailboxAddress("User repository", "example@mail.com"));
        message.Subject = $"Finally, {user.Name} user object is created!";
        message.Body = new TextPart("plain")
        {
            Text = $@"User object with following properties has been created!
                    Name: {user.Name}
                    Age: {user.Age}
                    Email: {user.Email}"
        };

        await sender.Send(new SendEmailCommand(message), cancellationToken);
    }
}