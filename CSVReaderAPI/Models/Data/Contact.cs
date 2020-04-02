namespace CSVReaderAPI.Models.Data
{
    public class Contact
    {
        /*public Contact(string[] headers, string[] rowValues)
        {
            for (int i = 0; i < headers.Length; i++)
            {
                this.GetType().GetProperty(headers[i]).SetValue(this, rowValues[i], null);
            }
        }*/
        public int Id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string job_title { get; set; }
        public string emailaddress1 { get; set; }
        public string department { get; set; }
        public string contact_type { get; set; }
        public string company_name { get; set; }
        public string business_phone { get; set; }
        public string address1_street1 { get; set; }
        public string address1_street2 { get; set; }
        public string address1_city { get; set; }
        public string address1_postalcode { get; set; }
        public string address1_country { get; set; }
    }
}