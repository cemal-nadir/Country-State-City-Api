using CNG.Abstractions.Signatures;

namespace Country.Application.Dtos.Main
{
    public class TimezonesDto: IListDto<Guid>
    {
        public Guid Id { get; set; }
        public string? ZoneName { get; set; }
        public int? GmtOffset { get; set; }
        public string? GmtOffsetName { get; set; }
        public string? Abbreviation { get; set; }
        public string? TzName { get; set; }
    }
}
