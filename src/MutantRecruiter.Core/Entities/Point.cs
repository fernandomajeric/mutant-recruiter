using System;
using System.Diagnostics.CodeAnalysis;

namespace MutantRecruiter.Core.Entities
{
    /// <summary>
    /// Clase que representa una punto de coordenada matriz del ADN
    /// </summary>
    public class Point : IEquatable<Point>
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals([AllowNull] Point other)
        {
            if (other is null) return false;
            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            if (obj is Point other)
                return Equals(other);

            throw new ArgumentException($"{nameof(obj)} must be of type Point");
        }

        public override int GetHashCode() => HashCode.Combine(X, Y);

        public override string ToString() => $"X: {X}, Y: {Y}";

        public static bool operator ==(Point pt1, Point pt2) => pt1.X == pt2.X && pt1.Y == pt2.Y;

        public static bool operator !=(Point pt1, Point pt2) => pt1.X != pt2.X || pt1.Y != pt2.Y;
    }
}
