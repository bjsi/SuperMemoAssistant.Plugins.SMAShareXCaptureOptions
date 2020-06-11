using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMAShareXCaptureOptions
{

    public enum MediaType
    {
        Image,
        Audio,
        Video,
    }

    [Alias("extracts")]
    public class Extract
    {
        public string File { get; set; }
        public MediaType MediaType { get; set; }  
        public string MediaExtension { get; set; }
        public bool IsSupported { get; set; }
        public double Priority { get; set; }
    }
}
