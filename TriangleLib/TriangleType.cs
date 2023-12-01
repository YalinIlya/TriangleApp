using System;

namespace TriangleLib
{
    public class TriangleType : ITriangleType
    {
        public TriangleTypes GetTriangleType(decimal sideA, decimal sideB, decimal sideC)
        {
            if (!(sideA > 0 && sideB > 0 && sideC > 0
                && sideA + sideB > sideC
                && sideA + sideC > sideB
                && sideC + sideB > sideA))
                return TriangleTypes.Error;

            if (sideA == sideB && sideA == sideC)
                return TriangleTypes.Acute;
            else
            {
                decimal[] sidesArr = { sideA, sideB, sideC };
                Array.Sort(sidesArr);
                var catSquareSum = sidesArr[0] * sidesArr[0] + sidesArr[1] * sidesArr[1];
                var gipSquare = sidesArr[2] * sidesArr[2];
                return (TriangleTypes)gipSquare.CompareTo(catSquareSum);
            }
        }
    }
}