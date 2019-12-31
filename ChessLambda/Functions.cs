using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;

using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace ChessLambda
{
    public class Functions
    {
        /// <summary>
        /// Default constructor that Lambda will invoke.
        /// </summary>
        public Functions()
        {
        }

        /// <summary>
        /// A Lambda function that returns back a page worth of blog posts.
        /// </summary>
        /// <param name="request"></param>
        /// <returns>The list of blogs</returns>
        public APIGatewayProxyResponse GetMove(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var fen = request.QueryStringParameters?["fen"];
            if (fen == null)
            {
                fen = request.Body;
            }
            BestMoveFinder bmf = new BestMoveFinder();
            var move = bmf.FindBestMove(fen);

            string origin;
            if (request.Headers.ContainsKey("Origin"))
            {
                origin = request.Headers["Origin"];
            }
            else if (request.Headers.ContainsKey("origin"))
            {
                origin = request.Headers["origin"];
            }
            else
            {
                origin = "https://dhauck.com";
            }
            return ResponseMapper.CreateResponse(origin, move);
        }
    }
}
