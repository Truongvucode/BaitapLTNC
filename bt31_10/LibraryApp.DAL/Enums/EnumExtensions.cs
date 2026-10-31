using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace LibraryApp.DAL.Enums
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            if (fieldInfo == null) return enumValue.ToString();

            var attribute = fieldInfo.GetCustomAttribute<DisplayAttribute>();
            return attribute?.Name ?? enumValue.ToString();
        }

        public static string ToVietnamese(this CopyStatus status)
        {
            return status switch
            {
                CopyStatus.Available => "Sẵn sàng",
                CopyStatus.Borrowed => "Đang mượn",
                CopyStatus.Lost => "Mất",
                CopyStatus.Maintenance => "Bảo trì",
                _ => status.ToString()
            };
        }

        public static CopyStatus ParseCopyStatus(string vietnameseText)
        {
            return vietnameseText?.Trim() switch
            {
                "Sẵn sàng" => CopyStatus.Available,
                "Đang mượn" => CopyStatus.Borrowed,
                "Mất" => CopyStatus.Lost,
                "Bảo trì" => CopyStatus.Maintenance,
                _ => Enum.TryParse<CopyStatus>(vietnameseText, true, out var result) ? result : CopyStatus.Available
            };
        }

        public static string ToVietnamese(this PhysicalCondition condition)
        {
            return condition switch
            {
                PhysicalCondition.New => "Mới",
                PhysicalCondition.Good => "Tốt",
                PhysicalCondition.Worn => "Cũ",
                PhysicalCondition.Damaged => "Hỏng",
                _ => condition.ToString()
            };
        }

        public static PhysicalCondition ParsePhysicalCondition(string vietnameseText)
        {
            return vietnameseText?.Trim() switch
            {
                "Mới" => PhysicalCondition.New,
                "Tốt" => PhysicalCondition.Good,
                "Cũ" => PhysicalCondition.Worn,
                "Hỏng" => PhysicalCondition.Damaged,
                _ => Enum.TryParse<PhysicalCondition>(vietnameseText, true, out var result) ? result : PhysicalCondition.Good
            };
        }
    }
}
