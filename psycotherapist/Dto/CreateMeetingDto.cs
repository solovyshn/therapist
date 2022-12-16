namespace psycotherapist.Dto
{
    public class CreateMeetingDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime FirstMeeting { get; set; }
        public int FrequencyTime { get; set; }
        public int PsycotherapistId { get; set; }
    }
}
