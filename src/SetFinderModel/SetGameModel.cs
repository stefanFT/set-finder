
namespace SetFinderModel
{
    public static class SetGameModel
    {
        public static Card FindMatchingCard(Card cardOne, Card cardTwo)
        {
            var color = cardOne.Color == cardTwo.Color
                ? cardOne.Color
                : FindUniqueColor(cardOne.Color, cardTwo.Color);

            var number = cardOne.Number == cardTwo.Number
                ? cardOne.Number
                : FindUniqueNumber(cardOne.Number, cardTwo.Number);

            var shading = cardOne.Shading == cardTwo.Shading
                ? cardOne.Shading
                : FindUniqueShading(cardOne.Shading, cardTwo.Shading);

            var shape = cardOne.Shape == cardTwo.Shape
                ? cardOne.Shape
                : FindUniqueShape(cardOne.Shape, cardTwo.Shape);

            return new Card
            {
                Color = color,
                Number = number,
                Shading = shading,
                Shape = shape,
            };
        }

        public static Color FindUniqueColor(Color colorOne, Color colorTwo)
        {
            return FindUnique(colorOne, colorTwo);
        }

        public static Number FindUniqueNumber(Number numberOne, Number numberTwo)
        {
            return FindUnique(numberOne, numberTwo);
        }

        public static Shading FindUniqueShading(Shading shadingOne, Shading shadingTwo)
        {
            return FindUnique(shadingOne, shadingTwo);
        }

        public static Shape FindUniqueShape(Shape shapeOne, Shape shapeTwo)
        {
            return FindUnique(shapeOne, shapeTwo);
        }

        private static TEnum FindUnique<TEnum>(TEnum optionOne, TEnum optionTwo) where TEnum : Enum
        {
            var optionOneByte = Convert.ToByte(optionOne);
            var optionTwoByte = Convert.ToByte(optionTwo);

            if (optionOneByte == optionTwoByte)
            {
                throw new ArgumentException("The options must be different!");
            }

            var uniqueOptionByte = (byte)((~optionOneByte & ~optionTwoByte) & 7);

            return (TEnum)(ValueType)uniqueOptionByte;
        }
    }
}
