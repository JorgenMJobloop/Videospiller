using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/videos")]
public class VideoController : ControllerBase
{

    public List<Videos> videos = new List<Videos>() {
        new Videos {ID = 1, Title = "Writing Safe SQL Queries in .NET", Description = ["A video by Nick Chapsas on how to safely use SQL Queries in .NET"], VideoURL = "http://localhost:5067/videos/queries.webm"},
        new Videos {ID = 2, Title = "", Description = [], VideoURL = ""},
        new Videos {ID = 3, Title = "", Description = [], VideoURL = ""},
        new Videos {ID = 4, Title = "", Description = [], VideoURL = ""},
        new Videos {ID = 5, Title = "", Description = [], VideoURL = ""},
        new Videos {ID = 6, Title = "", Description = [], VideoURL = ""},
        new Videos {ID = 7, Title = "", Description = [], VideoURL = ""},
        new Videos {ID = 8, Title = "", Description = [], VideoURL = ""},
        new Videos {ID = 9, Title = "", Description = [], VideoURL = ""},
        new Videos {ID = 10, Title = "", Description = [], VideoURL = ""}
    };



    [HttpGet]
    public IEnumerable<Videos> Get()
    {
        return videos;
    }

    /// <summary>
    /// Using a Data-transfer-object to limit the access scope of the POST endpoint as we generally only want the user to access the static assets on the site using GET
    /// </summary>
    /// <param name="id">video ID</param>
    /// <param name="videoLikesDTO">DTO</param>
    /// <returns></returns>
    [HttpPost("{id}/like")]
    public IActionResult NumberOfLikes(int id, [FromBody] VideoLikesDTO videoLikesDTO)
    {
        var video = videos.FirstOrDefault(v => v.ID == id);
        if (video == null)
        {
            return NotFound("Video not found!");
        }
        video.NumberOfLikes = videoLikesDTO.NumberOfLikes;
        return Ok(new { video.ID, video.NumberOfLikes });
    }
}
