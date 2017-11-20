using System;
using ISC.Whitest.Core.EqualityHelpers;
using Xunit;

namespace ISC.Whitest.Core.Tests
{
    public class EqualsBuilderTests
    {
        #region Model
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
        public void When_two_objects_have_same_properties_should_return_true()
        {
            var person1 = new Person(1, "Hadi", "Ahmadi", new DateTime(1991, 1, 7));
            var person2 = new Person(1, "Hadi", "Ahmadi", new DateTime(1991, 1, 7));

            var areEqual = new EqualsBuilder()
                .Append(person1.Id, person2.Id)
                .Append(person1.Firstname, person2.Firstname)
                .Append(person1.Lastname, person2.Lastname)
                .Append(person1.BirthDate, person2.BirthDate)
                .Append(person1.Fullname, person2.Fullname)
                .IsEquals();

            Assert.True(areEqual);
        }

        [Fact]
        public void When_two_objects_have_same_properties_should_return_true_by_reflection()
        {
            var person1 = new Person(1, "Hadi", "Ahmadi", new DateTime(1991, 1, 7));
            var person2 = new Person(1, "Hadi", "Ahmadi", new DateTime(1991, 1, 7));

            var areEqual = EqualsBuilder.ReflectionEquals(person1, person2);

            Assert.True(areEqual);
        }

        [Fact]
        public void When_two_objects_have_different_properties_or_fields_should_return_false_by_reflection()
        {
            var vehicle1 = new Vehicle("11-D-214","BMW S6", "1212");
            var vehicle2 = new Vehicle("11-D-214","BMW S6", "1313");

            var areEqual = EqualsBuilder.ReflectionEquals(vehicle1, vehicle2);

            Assert.False(areEqual);
        }

        [Fact]
        public void When_objects_are_same_should_calculate_same_hashcode()
        {
            var person1 = new Person(1, "Hadi", "Ahmadi", new DateTime(1991, 1, 7));
            var person2 = new Person(1, "Hadi", "Ahmadi", new DateTime(1991, 1, 7));

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

            Assert.Equal(firstPersonHashCode, secondPersonHashCode);
        }

        [Fact]
        public void When_objects_have_same_properties_should_calculate_same_hashcode_by_reflection()
        {
            var person1 = new Person(1, "Hadi", "Ahmadi", new DateTime(1991, 1, 7));
            var person2 = new Person(1, "Hadi", "Ahmadi", new DateTime(1991, 1, 7));

            var firstPersonHashCode = HashCodeBuilder.ReflectionHashCode(person1);
            var secondPersonHashCode = HashCodeBuilder.ReflectionHashCode(person2);

            Assert.Equal(firstPersonHashCode, secondPersonHashCode);
        }

        [Fact]
        public void When_object_have_different_properties_or_fields_should_calculate_different_hashcode_by_reflection()
        {
            var vehicle1 = new Vehicle("11-D-214", "BMW S6", "1212");
            var vehicle2 = new Vehicle("11-D-214", "BMW S6", "1313");

            var firstPersonHashCode = HashCodeBuilder.ReflectionHashCode(vehicle1);
            var secondPersonHashCode = HashCodeBuilder.ReflectionHashCode(vehicle2);

            Assert.NotEqual(firstPersonHashCode, secondPersonHashCode);
        }
    }
}
