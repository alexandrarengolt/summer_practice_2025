using System.Reflection;
namespace task07
{
    public class DisplayNameAttribute : Attribute
    {
        public string DisplayName;
        public DisplayNameAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }

    public class VersionAttribute : Attribute
    {
        public int Major { get; }
        public int Minor { get; }
        public VersionAttribute(int major, int minor)
        {
            Major = major;
            Minor = minor;
        }
    }

    [DisplayName("Пример класса")]
    [Version(1, 0)]

    public class SampleClass
    {
        [DisplayName("Тестовый метод")]
        public void TestMethod() { }

        [DisplayName("Числовое свойство")]
        public int Number{ get; set; }
    }
    public static class ReflectionHelper
    {
        public static void PrintTypeInfo (Type type)
        {
            var classDisplayName = type.GetCustomAttribute<DisplayNameAttribute>();
            if (classDisplayName != null) 
            {
                Console.WriteLine($"Имя класса: {classDisplayName.DisplayName}");
            }

            var verInfo = type.GetCustomAttribute<VersionAttribute>();
            if (verInfo != null)
            {
                Console.WriteLine($"Версия класса: {verInfo.Major}.{verInfo.Minor}");
            }

            var methodsWithDisplayNames = type.GetMethods()
                .Select(method => method.GetCustomAttribute<DisplayNameAttribute>());
    
            foreach (var methodDisplayName in methodsWithDisplayNames) 
            {
                if (methodDisplayName != null)
                 {
                    Console.WriteLine(methodDisplayName.DisplayName);
                }
            }

            var propertiesWithDisplayNames = type.GetProperties()
                .Select(property => property.GetCustomAttribute<DisplayNameAttribute>());
    
            foreach (var prDisplayName in propertiesWithDisplayNames) 
            {
                if (prDisplayName != null)
                {
                    Console.WriteLine(prDisplayName.DisplayName);
                }
            }
        }
    }
}