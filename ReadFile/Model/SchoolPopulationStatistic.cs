namespace ReadFile.Model
{
    /// <summary>
    /// This model class represents common properties for grade wise population, in a school , city or province
    /// </summary>
    public class SchoolPopulationStatistic
    {
        public string Province { get; set; }
        public string City { get; set; }
        public string SchoolName { get; set; }
        public string Grade { get; set; }
        public int Population { get; set; }

    }
}
