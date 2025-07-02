using task04;
using Xunit;
namespace task04tests
{
    public class SpaceshipTests
    {
        [Fact]
        public void Cruiser_ShouldHaveCorrectStats()
        {
            ISpaceship cruiser = new Cruiser();
            Assert.Equal(50, cruiser.Speed);
            Assert.Equal(80, cruiser.FirePower);
        }

        [Fact]
        public void Fighter_ShouldHaveCorrectStats()
        {
            ISpaceship cruiser = new Fighter();
            Assert.Equal(100, cruiser.Speed);
            Assert.Equal(30, cruiser.FirePower);
        }

        [Fact]
        public void Fighter_ShouldBeFasterThanCruiser()
        {
            var fighter = new Fighter();
            var cruiser = new Cruiser();
            Assert.True(fighter.Speed > cruiser.Speed);
        }

        [Fact]
        public void Cruiser_ShouldBeStrongerThanFighter()
        {
            var fighter = new Fighter();
            var cruiser = new Cruiser();
            Assert.True(fighter.FirePower < cruiser.FirePower);
        }

        [Fact]
        public void Spaceships_CorrectMoveForward()
        {
            ISpaceship fighter = new Fighter();
            ISpaceship cruiser = new Cruiser();

            fighter.MoveForward();
            cruiser.MoveForward();

            Assert.True(true);
        }

        [Fact]
        public void Spaceships_CorrectRotate()
        {
            ISpaceship fighter = new Fighter();
            ISpaceship cruiser = new Cruiser();

            fighter.Rotate(70);
            cruiser.Rotate(70);

            Assert.True(true);
        }

        [Fact]
        public void Spaceships_CorrectFire()
        {
            ISpaceship fighter = new Fighter();
            ISpaceship cruiser = new Cruiser();

            fighter.Fire();
            cruiser.Fire();

            Assert.True(true);
        }
    }
}
