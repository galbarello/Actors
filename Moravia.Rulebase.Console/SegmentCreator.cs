using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moravia.Rulebase.Domain;
using RestSharp;


/* <copyright file=SegmentCreator company="Moravia IT">
   Copyright (c) 2012 All Rights Reserved
   </copyright>
   <author>Guillermo Albarello - guillermo@moravia.com</author>
   <date>6/17/2013 3:45:30 PM</date>
   <summary>general summary please</summary>*/

namespace Moravia.Rulebase.ConsoleTest
{
    public static class SegmentCreator
    {
        public static IEnumerable<dynamic> GetSegments(string source, string target, int number = 1)
        {
            var host = string.Format("http://dev-rulebase:8888/generator/{0}/{1}/{2}", source, target, number);
            var client = new RestClient(host);
            var request = new RestRequest();
            // execute the request
            var response = client.Execute<Segment>(request);
            var content = response.Content; //  raw content as string
            return null;
        }
    }
}
