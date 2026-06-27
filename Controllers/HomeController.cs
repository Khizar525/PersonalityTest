using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PersonalityTest.Models;

namespace PersonalityTest.Controllers;

/// <summary>
/// Main controller handling personality test operations.
/// </summary>
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    /// <summary>
    /// Initializes a new instance of the HomeController.
    /// </summary>
    /// <param name="logger">Logger instance for logging operations.</param>
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Displays the main personality test page with image options.
    /// </summary>
    /// <returns>View with list of personality images.</returns>
    public IActionResult Index()
    {
        _logger.LogInformation("Personality test page loaded at {Time}", DateTime.UtcNow);

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
            },
            new PersonalityImage
            {
                Id = "stars",
                Name = "Stars",
                ImagePath = "/images/stars.svg",
                Description = "A twinkling night sky filled with stars"
            },
            new PersonalityImage
            {
                Id = "rainbow",
                Name = "Rainbow",
                ImagePath = "/images/rainbow.svg",
                Description = "A vibrant rainbow across the sky"
            }
        };

        return View(images);
    }

    /// <summary>
    /// Analyzes personality based on selected image and displays result.
    /// </summary>
    /// <param name="imageId">The ID of the selected image.</param>
    /// <returns>View with personality analysis result.</returns>
    [HttpPost]
    public IActionResult Analyze(string imageId)
    {
        if (string.IsNullOrEmpty(imageId))
        {
            _logger.LogWarning("Analyze called with null or empty imageId");
            return RedirectToAction(nameof(Index));
        }

        _logger.LogInformation("Analyzing personality for image: {ImageId} at {Time}", imageId, DateTime.UtcNow);

        var result = GetPersonalityResult(imageId);
        return View(result);
    }

    /// <summary>
    /// API endpoint for getting personality result as JSON.
    /// Useful for AJAX calls and third-party integrations.
    /// </summary>
    /// <param name="imageId">The ID of the selected image.</param>
    /// <returns>JSON response with personality result.</returns>
    [HttpPost]
    [Route("api/personality")]
    public IActionResult GetPersonalityApi(string imageId)
    {
        if (string.IsNullOrEmpty(imageId))
        {
            return BadRequest(new { error = "Image ID is required" });
        }

        var result = GetPersonalityResult(imageId);
        return Ok(result);
    }

    /// <summary>
    /// Health check endpoint for monitoring.
    /// </summary>
    /// <returns>Health status response.</returns>
    [HttpGet]
    [Route("api/health")]
    public IActionResult HealthCheck()
    {
        return Ok(new
        {
            status = "healthy",
            timestamp = DateTime.UtcNow,
            version = "1.0.0",
            environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"
        });
    }

    /// <summary>
    /// Returns personality result based on the selected image.
    /// Each image corresponds to a unique personality type.
    /// </summary>
    /// <param name="imageId">The ID of the selected image.</param>
    /// <returns>PersonalityResult object with analysis details.</returns>
    private PersonalityResult GetPersonalityResult(string imageId)
    {
        return imageId?.ToLower() switch
        {
            "mountain" => new PersonalityResult
            {
                ImageName = "Mountain",
                ImagePath = "/images/mountain.svg",
                Title = "The Achiever",
                Description = "You are ambitious, driven, and goal-oriented. Like a mountain, you stand firm in your convictions and work tirelessly to reach the peak of success. Your determination inspires others to aim higher.",
                Traits = "Ambitious, Determined, Resilient, Strong-willed"
            },
            "ocean" => new PersonalityResult
            {
                ImageName = "Ocean",
                ImagePath = "/images/ocean.svg",
                Title = "The Deep Thinker",
                Description = "You are introspective, intuitive, and emotionally deep. Like the ocean, you have hidden depths and a calm exterior that masks profound thoughts. Your wisdom comes from deep reflection.",
                Traits = "Introspective, Intuitive, Calm, Imaginative"
            },
            "forest" => new PersonalityResult
            {
                ImageName = "Forest",
                ImagePath = "/images/forest.svg",
                Title = "The Nurturer",
                Description = "You are caring, grounded, and growth-oriented. Like a forest, you create environments where things flourish and communities thrive. Your nurturing nature helps others grow.",
                Traits = "Caring, Grounded, Patient, Community-driven"
            },
            "desert" => new PersonalityResult
            {
                ImageName = "Desert",
                ImagePath = "/images/desert.svg",
                Title = "The Free Spirit",
                Description = "You are independent, adaptable, and resilient. Like the desert, you thrive in solitude and have a unique, vibrant energy that emerges in the right conditions. Your freedom is your strength.",
                Traits = "Independent, Adaptable, Resilient, Adventurous"
            },
            "stars" => new PersonalityResult
            {
                ImageName = "Stars",
                ImagePath = "/images/stars.svg",
                Title = "The Dreamer",
                Description = "You are imaginative, visionary, and inspired. Like the stars, you shine brightly in the darkness and inspire others with your creativity and sense of wonder. Your dreams light the way.",
                Traits = "Imaginative, Visionary, Creative, Inspiring"
            },
            "rainbow" => new PersonalityResult
            {
                ImageName = "Rainbow",
                ImagePath = "/images/rainbow.svg",
                Title = "The Optimist",
                Description = "You are joyful, colorful, and full of hope. Like a rainbow, you bring color and happiness wherever you go, and you have the unique ability to find beauty after every storm.",
                Traits = "Joyful, Optimistic, Vibrant, Hopeful"
            },
            _ => new PersonalityResult
            {
                ImageName = "Unknown",
                ImagePath = "",
                Title = "Unique Individual",
                Description = "You are truly one of a kind! Your personality doesn't fit into conventional categories, making you a rare and special individual.",
                Traits = "Unique, Curious, Open-minded"
            }
        };
    }

    /// <summary>
    /// Displays the privacy policy page.
    /// </summary>
    /// <returns>Privacy view.</returns>
    public IActionResult Privacy()
    {
        return View();
    }

    /// <summary>
    /// Displays error page when something goes wrong.
    /// </summary>
    /// <returns>Error view with error details.</returns>
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        _logger.LogError("Error occurred: {RequestId}", Activity.Current?.Id ?? HttpContext.TraceIdentifier);
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
