using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;


/* <copyright file=Bootstrapper company="Moravia IT">
   Copyright (c) 2012 All Rights Reserved
   </copyright>
   <author>Guillermo Albarello - guillermo@moravia.com</author>
   <date>6/17/2013 3:11:23 PM</date>
   <summary>general summary please</summary>*/

namespace Moravia.Rulebase.Domain.Config
{
    public static class Bootstrapper
    {
        private static Actor[] _actors;        
        private static int sleepy = 1;
        private static int ruleNumber = 1000;

        public static Actor[] Actors() 
        {
            return _actors;  
        }       
        

        public static void Init()
        {
            _actors = new Actor[RuleGetter()];
            for (int i = 0; i < RuleGetter(); i++)			
            {
                _actors[i] = new Actor();
            }
            
        }

        public static int RuleGetter()
        {
            return ruleNumber;
        }
    }
}
