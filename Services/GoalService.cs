public class GoalService
{
    private readonly List<Goal> _goals = new();

    public IEnumerable<Goal> GetGoals() => _goals;

    public void AddGoal(Goal goal)
    {
        goal.Id = _goals.Count + 1;
        _goals.Add(goal);
    }
}
