namespace AutoDeskAPI.Model
{
    public class FileMetaDataModel
    {
        public string FileName { get; internal set; }
        public string FileExtension { get; internal set; }
        public long SizeofFile { get; internal set; }
        public DateTime CreationTime { get; internal set; }
    }
}
