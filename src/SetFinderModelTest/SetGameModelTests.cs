using FluentAssertions;
using SetFinderModel;
using System;
using Xunit;

namespace SetFinderModelTest
{
    public class SetGameModelTests
    {
        [Theory]
        [InlineData(Color.Red, Color.Green, Color.Purple)]
        [InlineData(Color.Red, Color.Purple, Color.Green)]
        [InlineData(Color.Purple, Color.Green, Color.Red)]
        public void FindUniqueColor_Test(Color colorOne, Color colorTwo, Color expectedColor)
        {
            // Act
            var actualColor = SetGameModel.FindUniqueColor(colorOne, colorTwo);

            // Assert
            actualColor.Should().Be(expectedColor);
        }

        [Theory]
        [InlineData(Number.One, Number.Two, Number.Three)]
        [InlineData(Number.One, Number.Three, Number.Two)]
        [InlineData(Number.Three, Number.Two, Number.One)]
        public void FindUniqueNumber_Test(Number numberOne, Number numberTwo, Number expectedNumber)
        {
            // Act
            var actualNumber = SetGameModel.FindUniqueNumber(numberOne, numberTwo);

            // Assert
            actualNumber.Should().Be(expectedNumber);
        }

        [Theory]
        [InlineData(Shading.Solid, Shading.Striped, Shading.Open)]
        [InlineData(Shading.Solid, Shading.Open, Shading.Striped)]
        [InlineData(Shading.Striped, Shading.Open, Shading.Solid)]
        public void FindUniqueShading_Test(Shading shadingOne, Shading shadingTwo, Shading expectedShading)
        {
            // Act
            var actualShading = SetGameModel.FindUniqueShading(shadingOne, shadingTwo);

            // Assert
            actualShading.Should().Be(expectedShading);
        }

        [Theory]
        [InlineData(Shape.Diamond, Shape.Squiggle, Shape.Oval)]
        [InlineData(Shape.Diamond, Shape.Oval, Shape.Squiggle)]
        [InlineData(Shape.Oval, Shape.Squiggle, Shape.Diamond)]
        public void FindUniqueShape_Test(Shape shapeOne, Shape shapeTwo, Shape expectedShape)
        {
            // Act
            var actualShape = SetGameModel.FindUniqueShape(shapeOne, shapeTwo);

            // Assert
            actualShape.Should().Be(expectedShape);
        }

        [Theory]
        [InlineData(typeof(Number))]
        [InlineData(typeof(Shape))]
        [InlineData(typeof(Color))]
        [InlineData(typeof(Shading))]
        public void FindCard_Test(Type featureType)
        {
            // Arrange
            var cardOne = CreateCardOne();

            var cardTwo = new Card
            {
                Number = featureType == typeof(Number) ? Number.Two : cardOne.Number,
                Shape = featureType == typeof(Shape) ? Shape.Squiggle : cardOne.Shape,
                Color = featureType == typeof(Color) ? Color.Green : cardOne.Color,
                Shading = featureType == typeof(Shading) ? Shading.Striped : cardOne.Shading,
            };

            var expectedCard = new Card
            {
                Number = featureType == typeof(Number) ? Number.Three : cardOne.Number,
                Shape = featureType == typeof(Shape) ? Shape.Oval : cardOne.Shape,
                Color = featureType == typeof(Color) ? Color.Purple : cardOne.Color,
                Shading = featureType == typeof(Shading) ? Shading.Open : cardOne.Shading,
            };

            // Act
            var actualCard = SetGameModel.FindMatchingCard(cardOne, cardTwo);

            // Assert
            actualCard.Should().BeEquivalentTo(expectedCard);
        }

        [Fact]
        public void FindCard_AllFeaturesAreUnique_Test()
        {
            // Arrange
            var cardOne = new Card
            {
                Number = Number.One,
                Shape = Shape.Diamond,
                Color = Color.Green,
                Shading = Shading.Open,
            };

            var cardTwo = new Card
            {
                Number = Number.Two,
                Shape = Shape.Squiggle,
                Color = Color.Purple,
                Shading = Shading.Striped,
            };

            var expectedCard = new Card
            {
                Number = Number.Three,
                Shape = Shape.Oval,
                Color = Color.Red,
                Shading = Shading.Solid,
            };

            // Act
            var actualCard = SetGameModel.FindMatchingCard(cardOne, cardTwo);

            // Assert
            actualCard.Should().BeEquivalentTo(expectedCard);
        }

        private Card CreateCardOne()
        {
            return new Card
            {
                Number = Number.One,
                Shape = Shape.Diamond,
                Color = Color.Red,
                Shading = Shading.Solid,
            };
        }
    }
}
