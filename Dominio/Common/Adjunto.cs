using System;
using System.IO;
using Dominio.IdentificableObject;
using Dominio.Seguridad;

namespace Dominio.Common
{
    public class Adjunto:Auditoria,IIdentifiableObjectModel
    {
        public int Id { get; set; }
        public string ContentType { get; set; }
        public string Extencion { get; set; }
        public DateTime FechaSubido { get; set; }
        public string NombreArchivo { get; set; }
        public string Observaciones { get; set; }
        public string Path { get; set; }
        public string BlobUrl { get; set; }
        public long SizeBytes { get; set; }
       
        public byte[] GetAdjuntoBytes()
        {
           
                string filePath = System.IO.Path.Combine(Path, NombreArchivo); // _pathAdjuntos + "\\" + adjunto.Path + "\\" + adjunto.Id.ToString();

                if (File.Exists(filePath))
                {
                    using (var file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        byte[] buff = new byte[file.Length];
                        file.Read(buff, 0, (int)file.Length);

                        return buff;
                    }
                }
                else
                    return null;
            
        }

    }
}
