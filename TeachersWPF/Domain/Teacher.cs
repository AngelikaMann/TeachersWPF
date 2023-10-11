namespace TeachersWPF.Domain
{
    internal class Teacher
    {

        public Teacher()
        {
        }

        public Teacher(string v, DistanceLearningService distanceLearningService, Institute institute)
        {
            FullName = v;
            Service = distanceLearningService;
            Institute = institute;
        }

        public string FullName { get; set; }
        public Institute Institute { get; set; }
        public DistanceLearningService Service { get; set; }
    }
}
