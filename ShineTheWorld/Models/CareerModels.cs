using System.ComponentModel.DataAnnotations;

namespace ShineTheWorld.Models;

public class JobApplication
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Full name is required")]
    [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
    public string FullName { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Phone number is required")]
    [Phone(ErrorMessage = "Please enter a valid phone number")]
    public string Phone { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Position is required")]
    public string Position { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Experience is required")]
    [Range(0, 50, ErrorMessage = "Experience must be between 0 and 50 years")]
    public int Experience { get; set; }
    
    [Required(ErrorMessage = "Cover letter is required")]
    [StringLength(1000, ErrorMessage = "Cover letter cannot exceed 1000 characters")]
    public string CoverLetter { get; set; } = string.Empty;
    
    public string? ResumeFileName { get; set; }
    
    public DateTime AppliedDate { get; set; } = DateTime.UtcNow;
    
    public ApplicationStatus Status { get; set; } = ApplicationStatus.Submitted;
}

public enum ApplicationStatus
{
    Submitted,
    UnderReview,
    Shortlisted,
    Rejected,
    Hired
}

public class JobPosition
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty; // Full-time, Part-time, Contract
    public string Description { get; set; } = string.Empty;
    public List<string> Requirements { get; set; } = [];
    public string SalaryRange { get; set; } = string.Empty;
    public DateTime PostedDate { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
}

public class CareerViewModel
{
    public List<JobPosition> OpenPositions { get; set; } = [];
    public JobApplication Application { get; set; } = new();
}