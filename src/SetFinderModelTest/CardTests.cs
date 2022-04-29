using FluentAssertions;
using SetFinderModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SetFinderModelTest
{
    public class CardTests
    {
        [Fact]
        public void GetHashCode_ShouldReturnAUniqueHashCodeForEveryCard_Test()
        {
            // Arrange
            var hashCodes = new HashSet<int>();

            foreach (var number in Enum.GetValues(typeof(Number)).Cast<Number>())
            {
                foreach (var shape in Enum.GetValues(typeof(Shape)).Cast<Shape>())
                {
                    foreach (var color in Enum.GetValues(typeof(Color)).Cast<Color>())
                    {
                        foreach (var shading in Enum.GetValues(typeof(Shading)).Cast<Shading>())
                        {
                            var card = new Card
                            {
                                Number = number,
                                Shape = shape,
                                Color = color,
                                Shading = shading,
                            };

                            // Act
                            var hashCode = card.GetHashCode();
                            hashCodes.Add(hashCode);
                        }
                    }
                }
            }

            var expectedNumberOfCards = 81; // 3 different options for each of the 4 features, i.e 3^4 = 81.

            // Assert
            hashCodes.Should().HaveCount(expectedNumberOfCards);
        }
    }
}
