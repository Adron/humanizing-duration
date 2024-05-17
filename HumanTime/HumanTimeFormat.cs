namespace HumanTime;

public static class 
    HumanTimeFormat
{
    private static readonly string[] TimeUnits = { "year", "day", "hour", "minute", "second" };
    private static readonly int[] TimeUnitValues = { 365 * 24 * 60 * 60, 24 * 60 * 60, 60 * 60, 60, 1 };

    public static string formatDuration(int seconds)
    {
        if (seconds == 0)
            return "now";

        var parts = new List<string>();

        for (int i = 0; i < TimeUnitValues.Length; i++)
        {
            int count = seconds / TimeUnitValues[i];
            if (count > 0)
            {
                parts.Add(FormatPart(count, TimeUnits[i]));
                seconds %= TimeUnitValues[i];
            }
        }

        return CombineParts(parts);
    }

    private static string FormatPart(int count, string unit)
    {
        return $"{count} {unit}{(count > 1 ? "s" : "")}";
    }

    private static string CombineParts(List<string> parts)
    {
        return parts.Count > 1
            ? string.Join(", ", parts.Take(parts.Count - 1)) + " and " + parts.Last()
            : parts.FirstOrDefault();
    }
}