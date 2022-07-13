using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using MediatR;

namespace Application.Contact.Commands
{
    public class GetContactCommand: IRequest<GetContactResponse>
    {
        public int id { get; set; } 
    }
    public class GetContactCommandHandler : IRequestHandler<GetContactCommand, GetContactResponse>
    {
        public readonly MyDbContext _db;
        public GetContactCommandHandler(MyDbContext db)
        { 
            _db = db;
        }


        public Task<GetContactResponse> Handle(GetContactCommand request, CancellationToken cancellationToken)
        {

            var response = new GetContactResponse();    
            var query = _db.contacts.Where(a => a.Id == request.id).FirstOrDefault();
            response.Contact = new ContactModel();
            response.Contact.Id = query.Id;
            response.Contact.Name = query.Name;
            response.Contact.Number = query.Number;
            return Task.FromResult(response);
            throw new NotImplementedException();
        }
    }
}
