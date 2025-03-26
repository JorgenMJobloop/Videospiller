public class Videos
{
    public int ID { get; set; }
    public string? Title { get; set; }
    public List<string>? Description { get; set; }
    public string? VideoURL { get; set; }
    public int NumberOfLikes { get; set; }
    private FFMpegModule? MetaData;
}