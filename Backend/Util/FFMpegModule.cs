using System.Diagnostics;

public class FFMpegModule
{
    private Process? ffmpegProcess;

    public void GetMetaData(string? fileName)
    {
        ffmpegProcess = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "ffprobe",
                Arguments = $"-print_format json -show_streams -show_format \"{fileName}\".webm -hide_banner",
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
        ffmpegProcess.Start();
    }

    public void GetFileInfo(string? filePath)
    {
        try
        {
            string[] directories = Directory.GetFiles(@"./wwwroot/videos", ".webm");
            foreach (string dir in directories)
            {
                GetMetaData(dir.Split(".webm").ToString());
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($"The process failed: {0}", e.Message);
        }
    }
}