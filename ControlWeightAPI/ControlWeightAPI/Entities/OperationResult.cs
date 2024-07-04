﻿namespace ControlWeightAPI.Entities
{
    public class OperationResult
    {
        public bool IsSuccess {  get; set; }
        public List<String> Errors {  get; set; }
        public String UserMessage {  get; set; }

        public OperationResult()
        {
            Errors = new List<String>();

        }
    }
}
