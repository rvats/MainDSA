namespace BackTrackingSubsetSumDemo
{
    internal class Config
    {
        public int MaxSolutions { get; set; }
        public bool ShowProgress { get; set; }
        public bool ShowStatus { get; set; }
        public bool DisplaySolutions { get; set; }
        public bool DetectCodeError { get; set; }
        public Config() { MaxSolutions = 1; }
    }
}
