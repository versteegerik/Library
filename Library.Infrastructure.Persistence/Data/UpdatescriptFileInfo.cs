using System;
using System.IO;

namespace Library.Application.Data
{
    public sealed class UpdatescriptFileInfo
    {
        public FileInfo FileInfo { get; }

        public string Version { get; }

        public string Comment { get; }

        public UpdatescriptFileInfo(FileInfo fileInfo)
        {
            FileInfo = fileInfo;

            var indexOfExtension = fileInfo.Name.IndexOf(fileInfo.Extension, StringComparison.Ordinal);
            var infoFromFileName = fileInfo.Name.Remove(indexOfExtension).Split('_');
            Version = infoFromFileName[1].Substring(1) + "_" + infoFromFileName[2];

            if (infoFromFileName.Length <= 3) { return; }

            for (var i = 3; i < infoFromFileName.Length; i++)
            {
                Comment += infoFromFileName[i] + " ";
            }
        }

        public static UpdatescriptFileInfo GetFrom(FileInfo fileInfo) => new UpdatescriptFileInfo(fileInfo);
    }
}
