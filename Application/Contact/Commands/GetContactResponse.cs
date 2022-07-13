using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Application.Contact.Commands
{
    public class GetContactResponse
    {
        public ContactModel Contact { get; set; }
    }
}
