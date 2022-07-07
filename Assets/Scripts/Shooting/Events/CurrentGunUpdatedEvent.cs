namespace Project
{
    public readonly struct CurrentGunUpdatedEvent
    {
        public readonly int MaxTurnAmmo;
        public readonly int CurrentAmmo;
        public readonly int TotalAmmo;

        public CurrentGunUpdatedEvent(int maxTurnAmmo, int currentAmmo, int totalAmmo)
        {
            MaxTurnAmmo = maxTurnAmmo;
            CurrentAmmo = currentAmmo;
            TotalAmmo = totalAmmo;
        }
    }
}
