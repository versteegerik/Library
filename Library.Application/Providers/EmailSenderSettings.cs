using Microsoft.Extensions.Configuration;

namespace Library.Application.Providers
{
    public class EmailSenderSettings
    {
        public string PrimaryDomain { get; set; }

        public int PrimaryPort { get; set; }

        //public string SecondayDomain { get; set; }

        //public int SecondaryPort { get; set; }

        public string DisplayName { get; set; }

        public string UsernameEmail { get; set; }

        public string UsernamePassword { get; set; }

        public string FromEmail { get; set; }

        public EmailSenderSettings(IConfigurationSection configurationSection)
        {
            PrimaryDomain = configurationSection.GetValue<string>(nameof(PrimaryDomain));
            PrimaryPort = configurationSection.GetValue<int>(nameof(PrimaryPort));
            //SecondayDomain = configurationSection.GetValue<string>(nameof(SecondayDomain));
            //SecondaryPort = configurationSection.GetValue<int>(nameof(SecondaryPort));
            DisplayName = configurationSection.GetValue<string>(nameof(DisplayName));
            UsernameEmail = configurationSection.GetValue<string>(nameof(UsernameEmail));
            UsernamePassword = configurationSection.GetValue<string>(nameof(UsernamePassword));
            FromEmail = configurationSection.GetValue<string>(nameof(FromEmail));
        }
    }
}
