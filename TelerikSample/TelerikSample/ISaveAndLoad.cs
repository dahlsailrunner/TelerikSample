using System.IO;

namespace TelerikSample
{
    public interface ISaveAndLoad
    {
        void Save(string filename, MemoryStream stream);
    }
}
