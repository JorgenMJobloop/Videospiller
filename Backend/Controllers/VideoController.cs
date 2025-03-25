using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/videos")]
public class VideoController : ControllerBase
{

    public List<Videos> videos = new List<Videos>() {
        new Videos {ID = 1, Title = "", Description = [], VideoURL = ""},
        new Videos {ID = 2, Title = "", Description = [], VideoURL = ""},
        new Videos {ID = 3, Title = "", Description = [], VideoURL = ""},
        new Videos {ID = 4, Title = "", Description = [], VideoURL = ""}
    };

    [HttpGet]
    public IEnumerable<Videos> Get()
    {
        return videos;
    }
}
