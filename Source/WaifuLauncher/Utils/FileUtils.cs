namespace WaifuLauncher.Utils;

internal static class FileUtils
{
    internal static bool IsDirectoryEmpty(string path)
    {
        var items = Directory.EnumerateFileSystemEntries(path);

        using var en = items.GetEnumerator();

        return !en.MoveNext();
    }
}