using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Application.Errors;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Photos
{
    public class SetMain
    {
        public class Command : IRequest
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IUserAccessors _userAccesor;
            public Handler(DataContext context, IUserAccessors userAccesor)
            {
                _userAccesor = userAccesor;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => 
                x.UserName == _userAccesor.GetCurrentUsername());
                var photo = user.Photos.FirstOrDefault(ph =>
                ph.Id == request.Id);
                if (photo == null)
                    throw new RestException(HttpStatusCode.NotFound,
                    new {Photo = "Not found"});
                
                var currentMain = user.Photos.FirstOrDefault(x => x.IsMain);
                currentMain.IsMain = false;
                photo.IsMain = true;

                var success = await _context.SaveChangesAsync() > 0;

                if (success) return Unit.Value;
                throw new Exception("Problem savingchanges");
            }
        }
    }
}