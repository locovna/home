namespace Home
{
    public enum ETaskType
    {
        Move,
        Eat,
        Store
    }
    
    public static class TaskManager
    {
        public static ETaskType currentTask = ETaskType.Eat;
    }
}