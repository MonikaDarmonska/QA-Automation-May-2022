

using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Text.Json;



var client = new RestClient("https://api.github.com");
client.Authenticator = new HttpBasicAuthenticator("MonikaDarmonska", "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");

string url = "/repos/MonikaDarmonska/Postman/issues";

var request = new RestRequest(url);

request.AddBody(new { title = "New Issue from RestSharp" });


var response = await client.ExecuteAsync(request, Method.Post);

//var repos = JsonSerializer.Deserialize<List<Repo>>(response.Content);

//var issues = JsonSerializer.Deserialize<List<Issue>>(response.Content);

//foreach (var issue in issues)
//{
//    Console.WriteLine("ISSUE NUMBERS: " + issue.number);
//    Console.WriteLine("ISSUE ID: " + issue.id);
//    Console.WriteLine("ISSUE ID: " + issue.html_url);
//    Console.WriteLine("***********");
//}

Console.WriteLine("STATUS CODE " + response.StatusCode);
Console.WriteLine("STATUS CODE " + response.Content);















/*
 var client = new RestClient("https://api.github.com");

string url = "/repos/MonikaDarmonska/Postman/issues";

var request = new RestRequest(url);


var response = await client.ExecuteAsync(request);

//var repos = JsonSerializer.Deserialize<List<Repo>>(response.Content);

var issues = JsonSerializer.Deserialize<List<Issue>>(response.Content);

foreach (var issue in issues)
{
    Console.WriteLine("ISSUE NUMBERS: " + issue.number);
    Console.WriteLine("ISSUE ID: " + issue.id);
    Console.WriteLine("ISSUE ID: " + issue.html_url);
    Console.WriteLine("***********");
}
 */



/*
var client = new RestClient("https://api.github.com"); //first URL

var request = new RestRequest("/repos/MonikaDarmonska/Postman/issues");

var response = await client.ExecuteAsync(request);

Console.WriteLine("STATUS CODE: " + response.StatusCode);
Console.WriteLine("BODY: " + response.Content);




//Another option

var client = new RestClient("https://api.github.com"); 

var request = new RestRequest("/users/MonikaDarmonska/repos");
//request.AddUrlSegment("user", "MonikaDarmonska");
//request.AddUrlSegment("repos", "Postman");


var response = await client.ExecuteAsync(request);

var repos = JsonSerializer.Deserialize<List<Repo>>(response.Content);

foreach (var repo in repos)
{
    Console.WriteLine("REPO FULL NAME: " + repo.full_name);
}

/*
 * Output:
REPO FULL NAME: MonikaDarmonska/Collections
REPO FULL NAME: MonikaDarmonska/JavaFundamentals
REPO FULL NAME: MonikaDarmonska/Nunit-Summator-Solution
REPO FULL NAME: MonikaDarmonska/postman
REPO FULL NAME: MonikaDarmonska/QA-Automation-May-2022
 */








