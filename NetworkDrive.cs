namespace EXAMPLE_NS
{
    public class DriverInfo
    {
        public string Drive { get; set; }
        public string User { get; set; }
        public string Password { get; set; }

        public DriverInfo()
        {
            Drive = string.Empty;
            User = string.Empty;
            Password = string.Empty;
        }
    }

    public class NetDrive
    {
        private string netDrive;
        private string usr;
        private string pwd;

        public NetDrive(DriverInfo info)
        {
            netDrive = info.Drive;
            usr = info.User;
            pwd = info.Password;
        }

        public void Connect()
        {
            System.Diagnostics.ProcessStartInfo processInfo = new System.Diagnostics.ProcessStartInfo();
            processInfo.FileName = @"C:\WINDOWS\system32\net";
            processInfo.Arguments = string.Format("use \\\\{0} /USER:{1} {2}", netDrive, usr, pwd);
            System.Diagnostics.Process.Start(processInfo);
        }

        public void Disconnect()
        {
            System.Diagnostics.ProcessStartInfo processInfo = new System.Diagnostics.ProcessStartInfo();
            processInfo.FileName = @"C:\WINDOWS\system32\net";
            processInfo.Arguments = string.Format("use /delete \\\\{0}", netDrive);
            System.Diagnostics.Process.Start(processInfo);
        }

        public void MoveFiles(DirectoryInfo source, DirectoryInfo destination)
        {
            foreach (FileInfo childFile in source.GetFiles())
            {
                childFile.MoveTo(string.Format("{0}{1}", destination.ToString(), childFile.Name));
            }
        }

        public void DeleteFiles(DirectoryInfo source)
        {
            foreach (FileInfo childFile in source.GetFiles())
            {
                childFile.Delete();
            }
        }
    }
}
