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
    public class Delete
    {
        public class Command : IRequest
        {
            public string Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IPhotoAccessor _photoAccessor;
            private readonly IUserAccessors _userAccessor;

            public Handler(DataContext context, IUserAccessors userAccessor,
            IPhotoAccessor photoAccessor)
            {
                _photoAccessor = photoAccessor;
                _userAccessor = userAccessor;
                _context = context;
            }

        public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u =>
            u.UserName == _userAccessor.GetCurrentUsername());
            var photo = user.Photos.FirstOrDefault(ph =>
            ph.Id == request.Id);

            if (photo == null)
                throw new RestException(HttpStatusCode.NotFound,
                new {Photo = "Not found"});
            
            if (photo.IsMain)
                throw new RestException(HttpStatusCode.BadRequest,
                new {Photo = "You cannot delete your main photo"});

            var results = _photoAccessor.DeletePhoto(photo.Id);

            if (results == null)
                throw new Exception("Problem deleting the photo");
            
            user.Photos.Remove(photo);

            var success = await _context.SaveChangesAsync() > 0;

            if (success) return Unit.Value;
            throw new Exception("Problem savingchanges");
        }
    }
}
}