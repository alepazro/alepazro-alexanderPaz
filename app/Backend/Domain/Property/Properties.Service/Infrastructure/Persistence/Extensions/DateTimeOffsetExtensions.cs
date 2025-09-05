namespace Properties.Service.Infrastructure.Persistence.Extensions
{
    public static class DateTimeOffsetExtensions
    {
        public static int GetCurrentAge(this DateTimeOffset dateTimeOffset)
        {
            var dateToCalculateTo = DateTime.UtcNow;           

            int age = dateToCalculateTo.Year - dateTimeOffset.Year;

            if (dateToCalculateTo < dateTimeOffset.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }

}
