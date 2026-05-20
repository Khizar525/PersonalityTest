namespace PersonalityTest.Models;

public class PersonalityImage
{
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public string ImagePath { get; set; } = "";
    public string Description { get; set; } = "";
}

public class PersonalityResult
{
    public string ImageName { get; set; } = "";
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string Traits { get; set; } = "";
    public string ImagePath { get; set; } = "";
}
