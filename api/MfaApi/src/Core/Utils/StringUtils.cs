namespace MfaApi.Core.Utils;

public static class StringUtils {
    public static TEnum[] ParseAsEnumArray<TEnum>(
        this string str,
        string? delimiter = ","
    ) where TEnum: Enum {
        string[] strArr = str.Split(delimiter);

        return strArr
            .Where(s => Enum.IsDefined(typeof(TEnum), int.Parse(s)))
            .Select(s => (TEnum) Enum.Parse(typeof(TEnum), s))
            .ToArray();
    }
}