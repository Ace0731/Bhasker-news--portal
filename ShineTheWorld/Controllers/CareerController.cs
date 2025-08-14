using Microsoft.AspNetCore.Mvc;
using ShineTheWorld.Models;

namespace ShineTheWorld.Controllers;

public class CareerController : Controller
{
    // Mock data for job positions
    private static readonly List<JobPosition> _jobPositions = new()
    {
        new JobPosition
        {
            Id = 1,
            Title = "Senior Journalist",
            Department = "Editorial",
            Location = "New Delhi",
            Type = "Full-time",
            Description = "We are looking for an experienced journalist to join our editorial team. The ideal candidate will have strong writing skills, news judgment, and the ability to work under tight deadlines.",
            Requirements = new List<string>
            {
                "Bachelor's degree in Journalism, Mass Communication, or related field",
                "5+ years of experience in news reporting",
                "Excellent written and verbal communication skills",
                "Strong research and fact-checking abilities",
                "Experience with digital publishing platforms"
            },
            SalaryRange = "₹8-12 LPA",
            PostedDate = DateTime.UtcNow.AddDays(-5)
        },
        new JobPosition
        {
            Id = 2,
            Title = "Digital Marketing Specialist",
            Department = "Marketing",
            Location = "Mumbai",
            Type = "Full-time",
            Description = "Join our marketing team to drive digital growth and engagement. You'll be responsible for social media strategy, content marketing, and online advertising campaigns.",
            Requirements = new List<string>
            {
                "Bachelor's degree in Marketing, Communications, or related field",
                "3+ years of digital marketing experience",
                "Proficiency in Google Analytics, Facebook Ads, Google Ads",
                "Strong understanding of SEO and content marketing",
                "Creative thinking and analytical skills"
            },
            SalaryRange = "₹6-10 LPA",
            PostedDate = DateTime.UtcNow.AddDays(-3)
        },
        new JobPosition
        {
            Id = 3,
            Title = "Video Editor",
            Department = "Production",
            Location = "Bangalore",
            Type = "Full-time",
            Description = "Create compelling video content for our digital platforms. You'll work on news segments, documentaries, and social media content.",
            Requirements = new List<string>
            {
                "Proficiency in Adobe Premiere Pro, After Effects, Final Cut Pro",
                "2+ years of video editing experience",
                "Understanding of video formats and compression",
                "Creative storytelling abilities",
                "Ability to work under tight deadlines"
            },
            SalaryRange = "₹5-8 LPA",
            PostedDate = DateTime.UtcNow.AddDays(-7)
        },
        new JobPosition
        {
            Id = 4,
            Title = "Data Analyst",
            Department = "Analytics",
            Location = "Remote",
            Type = "Full-time",
            Description = "Analyze reader engagement, website traffic, and content performance to drive data-driven decisions for our editorial and business strategies.",
            Requirements = new List<string>
            {
                "Bachelor's degree in Statistics, Mathematics, or related field",
                "Proficiency in SQL, Python, or R",
                "Experience with data visualization tools (Tableau, Power BI)",
                "Strong analytical and problem-solving skills",
                "Experience with web analytics tools"
            },
            SalaryRange = "₹7-11 LPA",
            PostedDate = DateTime.UtcNow.AddDays(-2)
        }
    };

    private static readonly List<JobApplication> _applications = new();

    public IActionResult Index()
    {
        var viewModel = new CareerViewModel
        {
            OpenPositions = _jobPositions.Where(p => p.IsActive).OrderByDescending(p => p.PostedDate).ToList()
        };
        
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Apply(int? positionId)
    {
        var position = positionId.HasValue ? _jobPositions.FirstOrDefault(p => p.Id == positionId.Value) : null;
        
        var viewModel = new CareerViewModel
        {
            OpenPositions = _jobPositions.Where(p => p.IsActive).ToList(),
            Application = new JobApplication
            {
                Position = position?.Title ?? ""
            }
        };
        
        ViewBag.SelectedPosition = position;
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Apply(CareerViewModel model, IFormFile? resume)
    {
        if (ModelState.IsValid)
        {
            // Handle resume upload
            if (resume != null && resume.Length > 0)
            {
                var allowedExtensions = new[] { ".pdf", ".doc", ".docx" };
                var extension = Path.GetExtension(resume.FileName).ToLowerInvariant();
                
                if (!allowedExtensions.Contains(extension))
                {
                    ModelState.AddModelError("Resume", "Please upload a PDF, DOC, or DOCX file.");
                }
                else if (resume.Length > 5 * 1024 * 1024) // 5MB limit
                {
                    ModelState.AddModelError("Resume", "File size cannot exceed 5MB.");
                }
                else
                {
                    // In a real application, you would save the file to a secure location
                    model.Application.ResumeFileName = resume.FileName;
                }
            }

            if (ModelState.IsValid)
            {
                // Generate a new ID
                model.Application.Id = _applications.Count + 1;
                model.Application.AppliedDate = DateTime.UtcNow;
                
                // Add to mock storage
                _applications.Add(model.Application);
                
                TempData["SuccessMessage"] = "Your application has been submitted successfully! We'll get back to you within 5-7 business days.";
                return RedirectToAction("ApplicationSuccess", new { id = model.Application.Id });
            }
        }

        // If we got this far, something failed, redisplay form
        model.OpenPositions = _jobPositions.Where(p => p.IsActive).ToList();
        return View(model);
    }

    public IActionResult ApplicationSuccess(int id)
    {
        var application = _applications.FirstOrDefault(a => a.Id == id);
        if (application == null)
        {
            return NotFound();
        }
        
        return View(application);
    }

    public IActionResult Position(int id)
    {
        var position = _jobPositions.FirstOrDefault(p => p.Id == id);
        if (position == null)
        {
            return NotFound();
        }
        
        return View(position);
    }
}