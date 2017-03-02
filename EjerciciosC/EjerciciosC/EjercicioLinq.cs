using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosC
{
    /*
     * La idea es encontrar aquellos elementos que estan en ambas listas
     * */
    class EjercicioLinq
    {
        static void Main(string[] args)
        {
            List<Msj> MsjList = new List<Msj>()
            {
                new Msj("Jorge",1),
                new Msj("Areli",2),
                new Msj("Victor",3)
            };
            List<Msj> SentList = new List<Msj>()
            {
                new Msj("Jorge",1),
                new Msj("Areli",2)
            };
            //Usando expresiones lambda
            var r_lambda = MsjList.Where(x => SentList.Any(y => y.Id == x.Id));
            //Usando expresiones query
            var r_query = (from m in MsjList
                           where !SentList.Any(y => y.Id == m.Id)
                           select m);
            foreach (var item in r_lambda)
            {
                Console.WriteLine(item.Body);
            }
            foreach (var item in r_query)
            {
                Console.WriteLine(item.Body);
            }
            Console.ReadKey();
        }

        
    }

    class Msj
    {
        public string Body { get; set; }
        public int Id { get; set; }
        public Msj(string body, int id)
        {
            this.Body= body;
            this.Id = id;
        }
    }
}
