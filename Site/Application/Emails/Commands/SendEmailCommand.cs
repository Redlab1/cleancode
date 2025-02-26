using MediatR;
using MimeKit;

namespace Application.Emails.Commands;

public sealed record SendEmailCommand(MimeMessage Message) : IRequest;