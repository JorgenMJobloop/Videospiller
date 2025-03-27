public class Videos
{
    public int ID { get; set; }
    public string? Title { get; set; }
    public List<string>? Description { get; set; }
    public string? VideoURL { get; set; }
    /// <summary>
    /// Frontend for the DTO, not applied in any POST requests directly
    /// </summary>
    public int NumberOfLikes { get; set; }
    /// <summary>
    /// Inherits Process
    /// </summary>
    private FFMpegModule? MetaData;
    /// <summary>
    /// Inherits the Users model, optional in the controller. Is used only when loginState is true.
    /// </summary>
    public List<Users>? users { get; set; }
}