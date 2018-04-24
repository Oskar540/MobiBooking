namespace MobiBooking.DTO
{
    public enum TimeOption { timeSet1, timeSet2, timeSet3 }

    public enum BookStatus { available, unavailable }

    public class RoomDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeOption EtimeOption { get; set; }
        public string Localization { get; set; }
        public bool IsActive { get; set; }
        public int Capacity { get; set; }
        public bool IsReserved { get; set; }
        public BookStatus EbookStatus { get; set; }
    }
}