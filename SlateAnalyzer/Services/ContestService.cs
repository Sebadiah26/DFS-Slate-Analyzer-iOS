using System.Net.Http;

using System.Net.Http.Json;
using DFSSlateAnalyzerCore;
using DFSSlateAnalyzerCore.Models;
//using Microsoft.IdentityModel.Tokens;
//using Windows.Media.Protection.PlayReady;
//using static System.Net.WebRequestMethods;
//using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SlateAnalyzer.Services;

public class ContestService
{
    HttpClient httpClient;
    //ContestController contestController;    
    public ContestService()
    {
        this.httpClient = new HttpClient();
       // this.contestController = contestController;
    }

    List<EntryModel> entryList;
    ContestModel contestModel = new ContestModel();

    public async Task<ContestModel> GetContest()
    {
        if (contestModel.Entries.Count > 0)
            return contestModel;
       
        // Online
        string baseURL = "https://www.craigkielinski.com/api/";
        contestModel.ContestID = 0;
        string path = baseURL + "contest/getcontest/" + contestModel.ContestID + "/" + "02-23-23" + "/" + "blah";

        var response = await httpClient.GetAsync(path);

        //var response2 = await response.ReadContentAs<ContestModel>();

        //public async Task<CatalogModel> GetCatalog(string id)
        //{
        //    var response = await _client.GetAsync($"/Catalog/{id}");
        //    return await response.ReadContentAs<CatalogModel>();
        //}

        //public async Task<Build> Get(string buildId)
        //{
        //    HttpResponseMessage response = await _httpClient.GetAsync($"{buildId}?api-version=5.1");
        //    return await response.Content.ReadAsAsync<Build>();
        //}

        //public async Task<IResult<List<UserResponse>>> GetAllAsync()
        //{
        //    var response = await _httpClient.GetAsync(Routes.UserEndpoints.GetAll);
        //    return await response.ToResult<List<UserResponse>>();
        //}

        //public async Task<Stream> GetCatPictureAsync()
        //{
        //    var resp = await _http.GetAsync("https://cataas.com/cat");
        //    return await resp.Content.ReadAsStreamAsync();
        //}

        //public async Task RevokeSessionCookieAsync()
        //{
        //    var response = await BrowserClient.GetAsync(Url("__signout"));
        //    response.StatusCode.Should().Be(HttpStatusCode.NoContent);
        //}

        // Offline
        //using var stream = await FileSystem.OpenAppPackageFileAsync("monkeydata.json");
        //using var reader = new StreamReader(stream);
        //var contents = await reader.ReadToEndAsync();
        //monkeyList = JsonSerializer.Deserialize(contents, MonkeyContext.Default.ListMonkey);

        return (await response.EnsureSuccessStatusCode().Content.ReadAsAsync<ContestModel>()); 
    }
}
//        //[HttpGet(Name = "GetContest")]
//        //public async Task<Contest> GetContest(int SlateID = 0)
//        //{
//        //    // var contest = new Contest();

//        //    var contest = await _slateRepository.LoadContest(SlateID);

//        //    return contest;
//        //}