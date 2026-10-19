
namespace HabitsDev.Api.Entities;


// simple example for confusion of frequency and target :
// - Frequency = the rhythm/schedule of the habit
// - Target = the goal amount for one session 
public class Habit
{
    public string Id { get; set; }
    public string Name {get; set;} = string.Empty;
    public string? Desciption {get;set;}
    public HabitType Type {get;set;}
    public Frequency Frequency {get; set;}
    public Target Target {get;set;}
    public HabitStatus Status {get; set;}
    public bool IsArchived {get; set;}
    public DateOnly? EndDate {get; set;}
    public Milestone? Milestone {get; set;}
    public DateTime CreatedAtUtc {get; set;}
    public DateTime? UpdatedAtUtc {get; set;}
    public DateTime LastCompletedAtUtc {get; set;}
}

public enum HabitType
{

    None = 0,
    
    //binary mean no target need it is not measurable just do it or not 
    Binary = 1,
    Measurable = 2
}

// requency answer : how often / how many times do i do the habit
public sealed class Frequency
{
    public FrequencyType Type {get; set;}
    public int TimesPerPeriod {get; set;}
}

public enum FrequencyType
{
    None = 0 , Daily = 1, Weekly = 2 , Monthly = 3
}

// target answer : how much do I do each time? 
public class Target
{
    // example : 5 times per week or 30 minutes per day (the 5 or 30 is the value and times minutes is the unit)
    public int Value {get; set;}
    public string? Unit {get;set;}
}

public enum HabitStatus
{
    None = 0 , Ongoing = 1 , Completed = 2
}

public class Milestone
{
    public int Value {get; set;}
    public int Current {get; set;}
}