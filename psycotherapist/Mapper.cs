using Model;
using psycotherapist.Dto;

namespace psycotherapist
{
    public static class Mapper
    {
        public static PsycotherapistDto ToDto(this Psycotherapist psycotherapist)
        {
            return new PsycotherapistDto
            {
                Id = psycotherapist.Id,
                Name = psycotherapist.Name,
                Address = psycotherapist.Address,
                Password = psycotherapist.Password,
                //meetings = psycotherapist.Calendar.Select(d => d.ToDto()).ToList(),
            };
        }
        public static MeetingDto ToDto(this Meeting meeting)
        {
            return new MeetingDto
            {
                Id = meeting.Id,
                Name = meeting.Name,
                Description = meeting.Description,
                FrequencyTime = meeting.FrequencyTime,
                FirstMeeting = meeting.FirstMeeting,
                PsycotherapistId = meeting.PsycotherapistId,
            };
        }

    }
}
