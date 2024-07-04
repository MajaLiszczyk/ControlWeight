namespace ControlWeightAPI.Entities
{
    public class Measure
    {
        public int Id { get; set; }
        public DateTime MeasureDate { get; set; }
        public double Weight { get; set; }
        public double Waist { get; set; }
        public double Hips { get; set; }
        public double Thigh { get; set; }
        public double Arm { get; set; }
        public double Chest { get; set; }
    }
}
