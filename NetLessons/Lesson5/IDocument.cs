namespace Lesson5
{
    public interface IDocument
    {
        byte[] Data { get; set; }
        string Name { get; set; }
        string ReadData();
        void WriteData(string data);
    }
}
