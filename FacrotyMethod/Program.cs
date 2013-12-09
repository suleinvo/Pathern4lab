using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacrotyMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var document = new Document();
            document.WriteEnd("SampleText");
            //Save as txt
            //DocumentManager docManager = new TxtDocumentManager();
           // docManager.Save(document, "sample");
            //Save as html
            var docManager = new HtmlDocumentManager();
            docManager.Save(document, "sample");
        }
    }
}
