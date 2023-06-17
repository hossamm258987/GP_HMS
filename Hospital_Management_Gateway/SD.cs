namespace Hospital_Management_Gateway
{
    public static class SD
    {
        public static string Hospital_ServiceBase { get; set; }
        public static string Clinic_ServiceBase { get; set; }
        public static string Appointment_ServiceBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
    }
}
