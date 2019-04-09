[System.Serializable]
public class QuestGoal 
{
    // goal type
    public GoalType goalType;
    // requried amount
    public int reqAmount;
    // current amount
    public int curAmount;
    // is reached
    public bool IsReached()
    {
        return (curAmount >= reqAmount);
    }
    // enumyKilled
    public void EnemyKilled()
    {
        if (goalType == GoalType.Kill)
        {
            curAmount++;
        }
    }
   // ObjectCollected
   public void ObjectCollected()
    {
        if (goalType == GoalType.Gather)
        {
            curAmount++;
        }
    }
}
public enum GoalType
{
    Kill,
    Gather
}