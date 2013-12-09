using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacrotyMethod
{
    public class Document
    {
        public StringBuilder Data { get; set; }

        public Document()
        {
            Data = new StringBuilder();
        }

        public void WriteEnd(string message)
        {
            Data.Append(message);
        }

        public void ClearAll()
        {
            Data.Clear();
        }

        public void Newline()
        {
            Data.Append(Environment.NewLine);
        }
    }


    public abstract class FileStorage
    {
        public virtual string Name 
        {
            get; 
            set; 
        }

        public virtual void Save(Document document)
        {
             System.IO.File.WriteAllText(Name, document.Data.ToString());
        }
    }

    public abstract class DocumentManager
    {
        public abstract FileStorage CreateStorage(string name);

        public bool Save(Document document, string name)
        {
            FileStorage storage = this.CreateStorage(name);
            storage.Save(document);
            return true;
        }
    }

    public class TxtDocumentManager : DocumentManager
    {
        private class TxtDocStorage : FileStorage 
        {
            public TxtDocStorage(string name)
            {
                _name = name + ".txt";
            }

            private string _name;

            public override string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                }
            }
        }

        public override FileStorage CreateStorage(string name) { return new TxtDocStorage(name); }
    }

    public class HtmlDocumentManager : DocumentManager
    {
        private class HtmlDocStorage : FileStorage 
        {
            public HtmlDocStorage(string name)
            {
                _name = name + ".html";
            }
            
            private string _name;

            public override string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    _name = value;
                }
            }
        }

        public override FileStorage CreateStorage(string name) 
        { 
            return new HtmlDocStorage(name); 
        }
    }
}
