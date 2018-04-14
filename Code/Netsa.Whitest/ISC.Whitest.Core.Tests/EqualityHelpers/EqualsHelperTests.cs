using System;
using FluentAssertions;
using ISC.Whitest.Core.EqualityHelpers;
using Xunit;

namespace ISC.Whitest.Core.Tests.EqualityHelpers
{
    public class EqualsBuilderTests
    {
        #region HelperClasses
        private class Person
        {
            public long Id { get; private set; }
            public string Firstname { get; private set; }
            public string Lastname { get; private set; }
            public string Fullname => $"{Firstname} {Lastname}";
            public DateTime BirthDate { get; private set; }

            public Person(long id, string firstname, string lastname, DateTime birthDate)
            {
                Id = id;
                Firstname = firstname;
                Lastname = lastname;
                BirthDate = birthDate;
            }
        }
        private class Vehicle
        {
            private string _engineSerialNumber;
            public string PlateNo { get; private set; }
            public string Model { get; private set; }

            public Vehicle(string plateNo, string model, string engineSerialNumber)
            {
                PlateNo = plateNo;
                Model = model;
                _engineSerialNumber = engineSerialNumber;
            }
        }
        #endregion

        [Fact]
        public void IsEquals_should_return_true_When_two_objects_are_same()
        {
            //Arrange
            var person1 = new Person(1, "Hadi", "Ahmadi", new DateTime(1991, 1, 7));
            var person2 = new Person(1, "Hadi", "Ahmadi", new DateTime(1991, 1, 7));

            //Act
            var equalityResult = new EqualsBuilder()
                .Append(person1.Id, person2.Id)
                .Append(person1.Firstname, person2.Firstname)
                .Append(person1.Lastname, person2.Lastname)
                .Append(person1.BirthDate, person2.BirthDate)
                .Append(person1.Fullname, person2.Fullname)
                .IsEquals();

            //Assert
            equalityResult.Should().BeTrue();
        }

        [Fact]
        public void ReflectionEquals_should_return_true_When_two_objects_are_same()
        {
            //Arrange
            var person1 = new Person(1, "Hadi", "Ahmadi", new DateTime(1991, 1, 7));
            var person2 = new Person(1, "Hadi", "Ahmadi", new DateTime(1991, 1, 7));

            //Act
            var equalityResult = EqualsBuilder.ReflectionEquals(person1, person2);

            //Assert
            equalityResult.Should().Be(true);
        }

        [Fact]
        public void ReflectionEquals_should_return_false_When_two_objects_are_different()
        {
            //Arrange
            var vehicle1 = new Vehicle("11-D-214","BMW S6", "1212");
            var vehicle2 = new Vehicle("11-D-214","BMW S6", "1313");

            //Act
            var equalityResult = EqualsBuilder.ReflectionEquals(vehicle1, vehicle2);

            //Assert
            equalityResult.Should().BeFalse();
        }

        [Fact]
        public void ToHashCode_should_calculate_same_hashcode_when_objects_are_same()
        {
            //Arrange
            var person1 = new Person(1, "Hadi", "Ahmadi", new DateTime(1991, 1, 7));
            var person2 = new Person(1, "Hadi", "Ahmadi", new DateTime(1991, 1, 7));

            //Act
            var firstPersonHashCode = new HashCodeBuilder()
                .Append(person1.Id)
                .Append(person1.Firstname)
                .Append(person1.Lastname)
                .Append(person1.BirthDate)
                .ToHashCode();

            var secondPersonHashCode = new HashCodeBuilder()
                .Append(person2.Id)
                .Append(person2.Firstname)
                .Append(person2.Lastname)
                .Append(person2.BirthDate)
                .ToHashCode();

            //Assert
            firstPersonHashCode.Should().Be(secondPersonHashCode);
        }

        [Fact]
        public void ReflectionHashCode_should_calculate_same_hash_code_When_objects_are_same()
        {
            //Arrange
            var person1 = new Person(1, "Hadi", "Ahmadi", new DateTime(1991, 1, 7));
            var person2 = new Person(1, "Hadi", "Ahmadi", new DateTime(1991, 1, 7));

            //Act
            var firstPersonHashCode = HashCodeBuilder.ReflectionHashCode(person1);
            var secondPersonHashCode = HashCodeBuilder.ReflectionHashCode(person2);

            //Assert
            firstPersonHashCode.Should().Be(secondPersonHashCode);
        }

        [Fact]
        public void ReflectionHashCode_should_calculate_different_hashcode_when_object_are_different()
        {
            //Arrange
            var vehicle1 = new Vehicle("11-D-214", "BMW S6", "1212");
            var vehicle2 = new Vehicle("11-D-214", "BMW S6", "1313");

            //Act
            var firstPersonHashCode = HashCodeBuilder.ReflectionHashCode(vehicle1);
            var secondPersonHashCode = HashCodeBuilder.ReflectionHashCode(vehicle2);

            //Assert
            firstPersonHashCode.Should().NotBe(secondPersonHashCode);
        }
    }
}
