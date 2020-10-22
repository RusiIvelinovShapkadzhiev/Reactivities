using System;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;
using FluentValidation;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public DateTime CreatedOn { get; set; }
            public DateTime ModifiedOn { get; set; }
            public DateTime DeletedOn { get; set; }
            public string Name { get; set; }
            public string Notes { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public DateTime Date { get; set; }
            public string City { get; set; }
            public string Venue { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command> 
        {
            public CommandValidator()
            {
                RuleFor(x=>x.Title).NotEmpty();
                RuleFor(x=>x.Description).NotEmpty();
                RuleFor(x=>x.Date).NotEmpty();
                RuleFor(x=>x.City).NotEmpty();
                RuleFor(x=>x.Venue).NotEmpty();
                RuleFor(x=>x.Category).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IUserAccessors _userAccessor;

            public Handler(DataContext context, IUserAccessors userAccessor)
            {
                _context = context;
                _userAccessor = userAccessor;
            }

            public async Task<Unit> Handle(Command request,
            CancellationToken cancellationToken)
            {
                var activity = new Activity 
                {
                    Id = request.Id,
                    Title = request.Title,
                    Description = request.Description,
                    Category = request.Category,
                    Date = request.Date,
                    City = request.City,
                    Venue = request.Venue,
                    // Notes = request.Notes,
                    // Name = request.Name,
                    // CreatedOn = request.Date,
                    // ModifiedOn = request.Date,
                    // DeletedOn = request.Date
                    
                };

                _context.Activities.Add(activity);

                var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName ==
                _userAccessor.GetCurrentUsername());

                var attendee = new UserActivity 
                {
                    AppUser = user,
                    Activity = activity,
                    IsHost = true,
                    DateJoined = DateTime.Now
                };

                _context.UserActivities.Add(attendee);

                var success = await _context.SaveChangesAsync() > 0;

                if(success) return Unit.Value;
                throw new Exception("Problem savingchanges");
            }
        }
    }
}