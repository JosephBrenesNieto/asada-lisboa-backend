namespace AsadaLisboaBackend.Models
{
    public class VisualSetting
    {
        public Guid Id { get; set; }
        public string SettingType { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public byte Order { get; set; }
    }
}
