using System;
using System.Collections.Generic;

namespace Vavatech.Sortation.Models
{
    public abstract class Base
    {

    }

    public abstract class BaseEntity : Base
    {
        public int Id { get; set; }
    }

    public class Box : BaseEntity
    {
        public string BarCode { get; set; }
        public char Prefix => BarCode[0];
        public Dimension Dimension { get; set; }
        public float Weight { get; set; }
        public bool IsDamaged { get; set; }

        public override string ToString()
        {
            return $"{BarCode} {Dimension} {Weight:N2} {IsDamaged}";
        }
    }



    public class Dimension
    {
        public Dimension(int width, int height, int length)
        {
            Width = width;
            Height = height;
            Length = length;
        }

        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }

        public override string ToString() => $"W: {Width} H: {Height} L: {Length}";
    }

    public class SortSchema : BaseEntity
    {
        public SortSchema(Chute chute, Route route)
        {
            Chute = chute;
            Route = route;
        }

        public Chute Chute { get; set; }
        public Route Route { get; set; }
    }

    public class Chute : BaseEntity
    {
        public Chute(string number)
        {
            Number = number;
        }

        public string Number { get; set; }

        public List<Box> Boxes { get; set; }
    }

    public class Route : BaseEntity
    {
        public Route(char prefix, string name)
        {
            Prefix = prefix;
            Name = name;
        }

        public char Prefix { get; set; }
        public string Name { get; set; }
    }
}
