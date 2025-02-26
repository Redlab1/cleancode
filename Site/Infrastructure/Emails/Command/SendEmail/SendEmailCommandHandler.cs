using Application.Emails.Commands;
using MediatR;

namespace Infrastructure.Emails.Command.SendEmail;

public class SendEmailCommandHandler : IRequestHandler<SendEmailCommand>
{
    private const string PickupDirectory = @"C:\temp\maildrop";

    public async Task Handle(SendEmailCommand request, CancellationToken cancellationToken)
    {
        if (!Directory.Exists(PickupDirectory))
            Directory.CreateDirectory(PickupDirectory);

        var path = Path.Combine(PickupDirectory, Guid.NewGuid() + ".eml");
        if (File.Exists(path))
            return;

        await using var fileStream = new FileStream(path, FileMode.CreateNew);
        await request.Message.WriteToAsync(fileStream, cancellationToken);
    }
}