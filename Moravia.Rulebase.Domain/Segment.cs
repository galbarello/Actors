

/* <copyright file=Segment company="Moravia IT">
   Copyright (c) 2012 All Rights Reserved
   </copyright>
   <author>Guillermo Albarello - guillermo@moravia.com</author>
   <date>6/17/2013 3:22:10 PM</date>
   <summary>general summary please</summary>*/

namespace Moravia.Rulebase.Domain
{
    public class Segment
    {
        public string Source;
        public  string Target;
        public string MoreInfo;
        public  string Description;
        public string Placeholders;

        public Segment(string source, string target,string moreInfo,string description,string placeholders)
        {
            Source = source;
            Target = target;
            MoreInfo = moreInfo;
            Description = description;
            Placeholders = placeholders;
        }

        public Segment()
        {
            // TODO: Complete member initialization
        }
    }
}
