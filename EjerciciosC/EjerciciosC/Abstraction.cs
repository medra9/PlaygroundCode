using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjerciciosC
{
    class Principal
    {
        //static void Main(string[] args)
        //{
        //    Circulo miCirculo = new Circulo(3);
        //    Triangulo miTriangulo = new Triangulo(1, 1, 1);
        //    Cuadrado miCuadrado = new Cuadrado(2);
        //    miCirculo.Imprime(miCirculo);
        //    miTriangulo.Imprime(miTriangulo);
        //    miCuadrado.Imprime(miCuadrado);
        //    Console.ReadKey();
        //}
    }
    abstract class FiguraGeometrica
    {
        public abstract double Area();
        public string color { get; set; }
        public void Imprime(FiguraGeometrica figura)
        {
            Console.WriteLine(string.Format("El area de la figura es {0} y es de color {1}", figura.Area(), figura.color));
        }
    }
    class Circulo : FiguraGeometrica
    {
        public double radio { get; set; }
        public override double Area()
        {
            return (double)(radio * radio * 3.14);
        }
        public Circulo(double radio)
        {
            this.radio = radio;
            color = "Azul";
        }
    }

    class Triangulo : FiguraGeometrica
    {
        public int ladoA { get; set; }
        public int ladoB { get; set; }
        public int ladoC { get; set; }
        public override double Area()
        {
            double num, mPer;
            mPer = (double)(ladoA + ladoB + ladoC) / 2;
            num = mPer * (mPer - ladoA) * (mPer - ladoB) * (mPer - ladoC);
            return Math.Pow(num, 0.5);
        }

        public Triangulo(int ladoA, int ladoB, int ladoC)
        {
            this.ladoA = ladoA;
            this.ladoB = ladoB;
            this.ladoC = ladoC;
            color = "Amarillo";
        }
    }

    class Cuadrado : FiguraGeometrica
    {
        public int lado { get; set; }

        public override double Area()
        {
            return (lado * lado);
        }

        public Cuadrado(int lado)
        {
            this.lado = lado;
            color = "Morado";
        }
    }
}
