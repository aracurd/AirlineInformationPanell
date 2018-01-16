namespace AirlineInformationPanell.Enums
{
    public enum PlaineStatusEnum : byte
    {
        Unknown = 1,
        CheckIn,
        Closed,
        Arrived,
        Departed,
        Canceled,
        Expected,
        Delayed,
        InFlight
    }
}