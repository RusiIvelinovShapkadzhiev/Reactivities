using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Countries
{
    public class List
    {
        public class Query : IRequest<List<Country>> { }

        public class Handler : IRequestHandler<Query, List<Country>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<Country>> Handle(Query request, CancellationToken cancellationToken)
            {
                var countries = await _context.Countries.ToListAsync();
                return countries;
            }
        }
    }
}