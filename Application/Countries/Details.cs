using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Linq;

namespace Application.Countries
{
    public class Details
    {
        public class DetailsID
        {
            public class Query : IRequest<Country>
            {
                public Guid Id { get; set; }
            }

            public class Handler : IRequestHandler<Query, Country>
            {
                private readonly DataContext _context;
                public Handler(DataContext context)
                {
                    _context = context;
                }

                public async Task<Country> Handle(Query request, CancellationToken cancellationToken)
                {
                    var country = await _context.Countries.FindAsync(request.Id);
                    return country;
                }
            }
        }

        public class DetailsReligion 
        {
            public class Query : IRequest<List<Country>>
            {
                public string Religion { get; set; }
            }

            public class Handler : IRequestHandler<Query, List<Country>> 
            {
                private readonly DataContext _context;
                public Handler(DataContext context)
                {
                    _context = context;
                }

                public async Task<List<Country>> Handle(Query request, CancellationToken cancellationToken)
                {
                    var countries = await _context.Countries
                    .Where(c => c.Religion == request.Religion).ToListAsync();
                    return countries;
                }
            }
        }
    }
}











// public class ValuesController : ApiController
// {
    // EXPLANATION: See the view for the buttons which call these WebApi actions. For WebApi controllers, 
    //          there can only be one action for a given HTTP verb (GET, POST, etc) which has the same method signature, (even if the param names differ) so
    //          you can't have Get(string height) and Get(string width), but you can have Get(int height) and Get(string width).
    //          It isn't a particularly good idea to do that, but it is true. The key names in the query string must match the
    //          parameter names in the action, and the match is NOT case sensitive. This demo app allows you to test each of these
    //          rules, as follows:
    // 
    // When you send an HTTP GET request with no parameters (/api/values) then the Get() action will be called.
    // When you send an HTTP GET request with a height parameter (/api/values?height=5) then the Get(int height) action will be called.
    // When you send an HTTP GET request with a width parameter (/api/values?width=8) then the Get(string width) action will be called.
    // When you send an HTTP GET request with height and width parameters (/api/values?height=3&width=7) then the 
    //          Get(string height, string width) action will be called.
    // When you send an HTTP GET request with a depth parameter (/api/values?depth=2) then the Get() action will be called
    //          and the depth parameter will be obtained from Request.GetQueryNameValuePairs().
    // When you send an HTTP GET request with height and depth parameters (/api/values?height=4&depth=5) then the Get(int height) 
    //          action will be called, and the depth parameter would need to be obtained from Request.GetQueryNameValuePairs().
    // When you send an HTTP GET request with width and depth parameters (/api/values?width=3&depth=5) then the Get(string width) 
    //          action will be called, and the depth parameter would need to be obtained from Request.GetQueryNameValuePairs().
    // When you send an HTTP GET request with height, width and depth parameters (/api/values?height=7&width=2&depth=9) then the 
    //          Get(string height, string width) action will be called, and the depth parameter would need to be obtained from 
    //          Request.GetQueryNameValuePairs().
    // When you send an HTTP GET request with a width parameter, but with the first letter of the parameter capitalized (/api/values?Width=8) 
    //          then the Get(string width) action will be called because the case does NOT matter.
    // NOTE: If you were to uncomment the Get(string height) action below, then you would get an error about there already being  
    //          a member named Get with the same parameter types. The same goes for Get(int id).
    //
    // ANOTHER NOTE: Using the nullable operator (e.g. string? paramName) you can make optional parameters. It would work better to
    //          demonstrate this in another ApiController, since using nullable params and having a lot of signatures is a recipe
    //          for confusion.

    // GET api/values
    // public IEnumerable<string> Get()
    // {
    //     return Request.GetQueryNameValuePairs().Select(pair => "Get() => " + pair.Key + ": " + pair.Value);
    //     //return new string[] { "value1", "value2" };
    // }

    // //// GET api/values/5
    // //public IEnumerable<string> Get(int id)
    // //{
    // //    return new string[] { "Get(height) => height: " + id };
    // //}

    // // GET api/values?height=5
    // public IEnumerable<string> Get(int height) // int id)
    // {
    //     return new string[] { "Get(height) => height: " + height };
    // }

    // // GET api/values?height=3
    // public IEnumerable<string> Get(string height)
    // {
    //     return new string[] { "Get(height) => height: " + height };
    // }

    // //// GET api/values?width=3
    // //public IEnumerable<string> Get(string width)
    // //{
    // //    return new string[] { "Get(width) => width: " + width };
    // //}

    // // GET api/values?height=4&width=3
    // public IEnumerable<string> Get(string height, string width)
    // {
    //     return new string[] { "Get(height, width) => height: " + height + ", width: " + width };
    // }