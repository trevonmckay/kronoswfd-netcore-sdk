namespace Kronos.WFD
{
    public class PayCodeValueProfile
    {
        public bool Active { get; set; }

        public string Description { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public int Version { get; set; }
    }

    public class PayCodeValueProfileElement
    {
        public string Id { get; set; }

        public bool FirstHalfDayAmount { get; set; }

        public int FixedDurationMinimumQuantity { get; set; }

        public bool FullDayAmount { get; set; }

        public bool HalfDayAmount { get; set; }

        public bool HoursAmount { get; set; }

        public bool SecondHalfDayAmount { get; set; }

        public EntityReference PayCode { get; set; }
    }
}
