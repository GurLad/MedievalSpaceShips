
/// <summary>
/// Class <c>ExtensionMethods</c> includes one method to convert a resource type to a string, 
/// with Eels being a special conversion.
/// </summary>
///
public static class ExtensionMethods
{
    public static string ToFormattedString(this ResourceType type)
    {
        return type == ResourceType.ElectricEels ? "Eels" : type.ToString();
    }
}
