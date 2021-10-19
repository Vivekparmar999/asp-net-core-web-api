using mybooks.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mybooks.Data.ViewModels
{
    public class CustomActionResultVM
    {

        //Return Exception or Data

        public Exception Exception { get; set; }

        //Return all type
        //public object object1 {get; set;}


        //Return Specific Publisher Type
        public Publisher Publisher { get; set; }
    }
}
