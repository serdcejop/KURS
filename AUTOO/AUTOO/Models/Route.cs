namespace AUTOO.Models
{
    public class Route
    {
        public int Id { get; set; }
        public string RouteNumber { get; set; }
        public string StartPoint { get; set; }
        public string EndPoint { get; set; }
        public double Length { get; set; }
        public string Description { get; set; }
    }
}