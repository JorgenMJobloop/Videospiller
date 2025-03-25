using System;
using System.Collections.Immutable;
using System.IO;
using System.IO.Compression;

public class CompressionModule
{
    public string filePath = @"./start";
    public string zipFilePath = @"./result.zip";
    public string extractFilePath = @"./extract";

    public string originalFileNames = @".webm";
    public string compressedFileNames = $@"./wwwroot/videos/{null}";

    public void ZipFileInFilePath()
    {
        ZipFile.CreateFromDirectory(filePath, zipFilePath);
    }

    public void UnzipFileInFilePath()
    {
        ZipFile.ExtractToDirectory(zipFilePath, extractFilePath);

        var extract = Path.GetFullPath(extractFilePath);
        if (extract.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
        {
            extract += Path.DirectorySeparatorChar;
        }
        using (ZipArchive archive = ZipFile.OpenRead(zipFilePath))
        {
            foreach (ZipArchiveEntry entry in archive.Entries)
            {
                if (entry.FullName.EndsWith(".webm", StringComparison.Ordinal))
                {
                    string destionationPath = Path.GetFullPath(Path.Combine(extract, entry.FullName));
                    if (destionationPath.StartsWith(extract, StringComparison.Ordinal))
                    {
                        entry.ExtractToFile(destionationPath);
                    }
                }
            }
        }
    }
}