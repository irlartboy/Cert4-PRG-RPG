[System.Serializable]

public class Quest
{
    // state of quest
    public QuestState state = QuestState.New;
    // name
    public string name;
    // description
    public string description;
    // exp reward
    public int expReward;
    // gold reward
    public int goldReward;
    // goal
    public QuestGoal goal;
    //is it complete?

    public void Complete()
    {
        state = QuestState.Completed;
    }

}
public enum QuestState
{
    New,
    Accepted,
    Failed, 
    Completed, 
    Claimed
}