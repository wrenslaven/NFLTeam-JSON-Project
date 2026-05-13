using System.Text.Json;

string filePath = "../../../sports-teams-nfl.json"; // need to navigate out of bin directory to reach JSON file

if (File.Exists(filePath))
{
    string jsonTeams = File.ReadAllText(filePath);
    NFLData? deserializedTeams = JsonSerializer.Deserialize<NFLData>(jsonTeams);
    if (deserializedTeams != null && deserializedTeams.teams != null)
    {
        foreach (Team team in deserializedTeams.teams)
        {
            Console.WriteLine($"{team.name} ({team.abbreviation}): Founded in {team.founded} and playing in the {team.conference} {team.division} in {team.stadium} in {team.city}, {team.state}.");
        }
    }
    else
    {
        Console.WriteLine("Could not deserialize JSON.");
    }
}
else
{
    Console.WriteLine("File not found.");
}

public class NFLData
{
    public List<Team>? teams { get; set; }
}

public class Team
{
    public string? name { get; set; }
    public string? abbreviation { get; set; }
    public string? city { get; set; }
    public string? state { get; set; }
    public string? conference { get; set; }
    public string? division { get; set; }
    public int? founded { get; set; }
    public string? stadium { get; set; }
    public string? primary_color { get; set; }
}