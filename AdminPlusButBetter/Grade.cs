namespace AdminPlusButBetter
{
    internal class Grade
    {
        public int value;
        public string reason;
        public int day;
        public int month;
        public int year;
        public string fullDate;
        public int id;
        public Grade(int aValue, string aReason, int aDay, int aMonth, int aYear, int aId)
        {
            value = aValue;
            reason = aReason;
            day = aDay;
            month = aMonth;
            year = aYear;
            fullDate = String.Concat(day, "/", month, "/", year);
            id = aId;
        }
    }
}

