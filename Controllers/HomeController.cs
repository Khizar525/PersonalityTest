using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PersonalityTest.Models;

namespace PersonalityTest.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var images = new List<PersonalityImage>
        {
            new PersonalityImage
            {
                Id = "mountain",
                Name = "Mountain",
                ImagePath = "/images/mountain.svg",
                Description = "A calm, majestic mountain landscape"
            },
            new PersonalityImage
            {
                Id = "ocean",
                Name = "Ocean",
                ImagePath = "/images/ocean.svg",
                Description = "Vast, tranquil ocean waters"
            },
            new PersonalityImage
            {
                Id = "forest",
                Name = "Forest",
                ImagePath = "/images/forest.svg",
                Description = "A lush, green forest"
            },
            new PersonalityImage
            {
                Id = "desert",
                Name = "Desert",
                ImagePath = "/images/desert.svg",
                Description = "A warm, expansive desert"
            }
        };
        return View(images);
    }

    [HttpPost]
    public IActionResult Analyze(string imageId)
    {
        var result = GetPersonalityResult(imageId);
        return View(result);
    }

    private PersonalityResult GetPersonalityResult(string imageId)
    {
        return imageId?.ToLower() switch
        {
            "mountain" => new PersonalityResult
            {
                ImageName = "Mountain",
                ImagePath = "/images/mountain.svg",
                Title = "The Achiever",
                Description = "You are ambitious, driven, and goal-oriented. Like a mountain, you stand firm in your convictions and work tirelessly to reach the peak of success.",
                Traits = "Ambitious, Determined, Resilient, Strong-willed"
            },
            "ocean" => new PersonalityResult
            {
                ImageName = "Ocean",
                ImagePath = "/images/ocean.svg",
                Title = "The Deep Thinker",
                Description = "You are introspective, intuitive, and emotionally deep. Like the ocean, you have hidden depths and a calm exterior that masks profound thoughts.",
                Traits = "Introspective, Intuitive, Calm, Imaginative"
            },
            "forest" => new PersonalityResult
            {
                ImageName = "Forest",
                ImagePath = "/images/forest.svg",
                Title = "The Nurturer",
                Description = "You are caring, grounded, and growth-oriented. Like a forest, you create environments where things flourish and communities thrive.",
                Traits = "Caring, Grounded, Patient, Community-driven"
            },
            "desert" => new PersonalityResult
            {
                ImageName = "Desert",
                ImagePath = "/images/desert.svg",
                Title = "The Free Spirit",
                Description = "You are independent, adaptable, and resilient. Like the desert, you thrive in solitude and have a unique, vibrant energy that emerges in the right conditions.",
                Traits = "Independent, Adaptable, Resilient, Adventurous"
            },
            _ => new PersonalityResult
            {
                ImageName = "Unknown",
                ImagePath = "",
                Title = "Unique Individual",
                Description = "You are truly one of a kind!",
                Traits = "Unique, Curious, Open-minded"
            }
        };
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
