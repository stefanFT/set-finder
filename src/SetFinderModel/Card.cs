namespace SetFinderModel
{
    public class Card
    {
        public Shape Shape { get; init; }

        public Color Color { get; init; }

        public Shading Shading { get; init; }

        public Number Number { get; init; }

        public override bool Equals(object? obj)
        {
            if (obj is not Card otherCard)
            {
                return false;
            }

            return otherCard is Card &&
                Shape == otherCard.Shape &&
                Color == otherCard.Color &&
                Number == otherCard.Number &&
                Shading == otherCard.Shading;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Shape, Color, Number, Shading);
        }
    }

    public enum Shape : byte
    {
        Diamond = 1,
        Squiggle = 2,
        Oval = 4,
    }

    public enum Color : byte
    {
        Red = 1,
        Green = 2,
        Purple = 4,
    }

    public enum Shading : byte
    {
        Solid = 1,
        Striped = 2,
        Open = 4,
    }

    public enum Number : byte
    {
        One = 1,
        Two = 2,
        Three = 4,
    }
}