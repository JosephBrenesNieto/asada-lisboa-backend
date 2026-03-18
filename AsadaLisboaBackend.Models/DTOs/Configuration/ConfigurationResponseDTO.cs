using System.Linq.Expressions;

namespace AsadaLisboaBackend.Models.DTOs.Configuration
{
    public class ConfigurationResponseDTO
    {
        public Guid Id { get; set; }
        public string SettingType { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
        public byte Order { get; set; }
    }

    public static partial class ConfigurationExtensions
    {
        public static Expression<Func<Models.VisualSetting, ConfigurationResponseDTO>> MapConfigurationResponseDTO()
        {
            return visualSetting => new ConfigurationResponseDTO
            {
                Id = visualSetting.Id,
                Order = visualSetting.Order,
                Value = visualSetting.Value,
                SettingType = visualSetting.SettingType,
            };
        }

        public static ConfigurationResponseDTO ToConfigurationResponseDTO(this Models.VisualSetting visualSettings)
        {
            return new ConfigurationResponseDTO()
            {
                Id = visualSettings.Id,
                Order = visualSettings.Order,
                Value = visualSettings.Value,
                SettingType = visualSettings.SettingType,
            };
        }
    }
}
