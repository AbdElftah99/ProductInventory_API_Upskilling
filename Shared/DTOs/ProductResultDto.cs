namespace Shared.DTOs
{
    public record ProductResultDto
    {
        public int      Id          { get; init; }
        public string   Name        { get; init; }
        public string   Description { get; init; }
        public decimal  Price       { get; init; }
    }
}
