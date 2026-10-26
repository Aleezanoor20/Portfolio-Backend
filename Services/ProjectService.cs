using Microsoft.EntityFrameworkCore;

public class ProjectService
{
    private readonly PortfolioDbContext _context;

    public ProjectService(PortfolioDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProjectDto>> GetAllAsync()
    {
        var projects = await _context.Projects.ToListAsync();

        var projectDtos = new List<ProjectDto>();

        foreach (var project in projects)
        {
            var projectDto = new ProjectDto
            {
                Id = project.Id,
                Titel = project.Titel,
                Beschrijving = project.Beschrijving,
                Categorie = project.Categorie,
                GitHubUrl = project.GitHubUrl,
                Datum = project.Datum
            };

            projectDtos.Add(projectDto);
        }

        return projectDtos;
    }


public async Task<ProjectDto?> GetByIdAsync(int id)
{
    var project = await _context.Projects.FindAsync(id);

    if (project == null)
    {
        return null;
    }

    var projectDto = new ProjectDto
    {
        Id = project.Id,
        Titel = project.Titel,
        Beschrijving = project.Beschrijving,
        Categorie = project.Categorie,
        GitHubUrl = project.GitHubUrl,
        Datum = project.Datum
    };

    return projectDto;
}

public async Task<ProjectDto> CreateAsync(CreateProjectDto dto)
{
    var project = new Project
    {
        Titel = dto.Titel,
        Beschrijving = dto.Beschrijving,
        Categorie = dto.Categorie,
        GitHubUrl = dto.GitHubUrl,
        Datum = dto.Datum
    };

    _context.Projects.Add(project);
    await _context.SaveChangesAsync();

    var projectDto = new ProjectDto
    {
        Id = project.Id,
        Titel = project.Titel,
        Beschrijving = project.Beschrijving,
        Categorie = project.Categorie,
        GitHubUrl = project.GitHubUrl,
        Datum = project.Datum
    };

    return projectDto;
}
public async Task<ProjectDto?> UpdateAsync(int id, UpdateProjectDto dto)
{
    var project = await _context.Projects.FindAsync(id);

    if (project == null)
    {
        return null;
    }

    project.Titel = dto.Titel;
    project.Beschrijving = dto.Beschrijving;
    project.Categorie = dto.Categorie;
    project.GitHubUrl = dto.GitHubUrl;
    project.Datum = dto.Datum;

    await _context.SaveChangesAsync();

    var projectDto = new ProjectDto
    {
        Id = project.Id,
        Titel = project.Titel,
        Beschrijving = project.Beschrijving,
        Categorie = project.Categorie,
        GitHubUrl = project.GitHubUrl,
        Datum = project.Datum
    };

    return projectDto;
}


public async Task<bool> DeleteAsync(int id)
{
    var project = await _context.Projects.FindAsync(id);

    if (project == null)
    {
        return false;
    }

    _context.Projects.Remove(project);
    await _context.SaveChangesAsync();

    return true;
}
}