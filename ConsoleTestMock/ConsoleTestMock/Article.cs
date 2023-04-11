using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestMock
{
   public class Article
    {
        public virtual DateTime GetPublicationDate(int articleId)
        {
            return
                 DateTime.Now;
        }
    }
}
