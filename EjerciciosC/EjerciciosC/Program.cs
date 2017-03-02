using System;
using System.Collections.Generic;
using System.Linq;

namespace Reflection
{
    public class Persona
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public int edad { get; set; }

        //static void Main(string[] args)
        //{
        //    Persona unaPersona = new Persona();
        //    var result = unaPersona.GetPropertiesNameOfClass(new Persona());
        //    foreach (var item in result)
        //    {
        //        Console.WriteLine(item);
        //    }
        //    Console.ReadKey();
        //}

        public List<string> GetPropertiesNameOfClass(object pObject)
        {        
            List<string> result = null;
            if (!object.ReferenceEquals(pObject, null))
            {
                result = (from p in pObject.GetType().GetProperties()
                          select p.Name).ToList();
            }
            return result;
        }
    }
    
}