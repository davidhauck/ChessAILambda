using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ChessLambda
{
    public static class ResponseMapper
    {
        public static APIGatewayProxyResponse CreateResponse(string origin, dynamic body)
        {
            string originResponse = "https://www.dhauck.com";
            if (origin.Contains("dhauck.com"))
            {
                originResponse = origin;
            }
            else if (origin.Contains("chess-ui-codemash.s3-website-us-east-1.amazonaws.com"))
            {
                originResponse = origin;
            }
            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK,
                Body = JsonConvert.SerializeObject(body),
                Headers = new Dictionary<string, string> { { "Content-Type", "application/json" }, {"Access-Control-Allow-Origin", originResponse } }
            };
            return response;
        }
    }
}
