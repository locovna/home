namespace Home
{
    public enum ETaskType
    {
        Move,
        Use,
        Store
    }
    
    public static class TaskManager
    {
        public static ETaskType currentTask = ETaskType.Use;
    }
}