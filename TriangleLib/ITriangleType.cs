namespace TriangleLib
{
    public interface ITriangleType
    {
        TriangleTypes GetTriangleType(decimal sideA, decimal sideB, decimal sideC);
    }
}