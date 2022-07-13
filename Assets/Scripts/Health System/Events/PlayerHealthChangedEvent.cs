namespace Project
{
    public readonly struct PlayerHealthChangedEvent
    {
        public readonly HealthPart ChangedPart;

        public PlayerHealthChangedEvent(HealthPart changedPart)
        {
            ChangedPart = changedPart;
        }
    }
}
