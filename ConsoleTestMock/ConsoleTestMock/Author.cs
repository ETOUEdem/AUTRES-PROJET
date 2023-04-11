using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleTestMock
{
    class Author : IAuthor
    {
        public virtual int Id { get; set; }
        public virtual string FirstName { get; set; }
   

        public virtual string LastName { get; set; }
    }
}
