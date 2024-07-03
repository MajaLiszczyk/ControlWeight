﻿namespace ControlWeightAPI.Dtos
{
    public class UpdateMeasureDto
    {
        public int Id { get; set; }
        public double Weight { get; set; }
        public double Waist { get; set; }
        public double Hips { get; set; }
        public double Thigh { get; set; }
        public double Arm { get; set; }
        public double Chest { get; set; }
    }
}