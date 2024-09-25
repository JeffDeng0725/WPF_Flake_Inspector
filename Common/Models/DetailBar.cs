using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo1.Common.Models
{
    internal class DetailBar :BindableBase
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        private string nameSpace;
        public string NameSpace
        {
            get { return nameSpace; }
            set { nameSpace = value; }
        }
        private Boolean isLiked;
        public Boolean IsLiked
        {
            get { return isLiked; }
            set { isLiked = value; }
        }
    }
}
