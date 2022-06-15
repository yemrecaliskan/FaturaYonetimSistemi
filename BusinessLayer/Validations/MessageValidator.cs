using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validations
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().MinimumLength(3);
            RuleFor(x => x.SenderMail).NotEmpty().MinimumLength(3);
            RuleFor(x => x.MessageContent).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Subject).NotEmpty().MinimumLength(2);            
        }
    }
}
