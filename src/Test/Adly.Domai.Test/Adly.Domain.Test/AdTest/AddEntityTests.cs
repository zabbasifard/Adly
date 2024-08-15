using Adly.Domain.Entities.Ad;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adly.Domain.Test.AdTest
{
    public class AddEntityTests
    {
        [Fact]
        public void Creating_Ads_With_Null_User_Should_Throw_Exception()
        {
            //Arrange
            var description = "Test description";
            var name = "Ad name";
            Guid? userId = null;
            Guid? categoryId = Guid.NewGuid();

            //Act
            Action act = () => AdEntity.Create(name, description, userId, categoryId);

            //Assert
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Creating_Ads_With_Null_Category_Should_Thow_Exception()
        {
            //Arrange
            var description = "Test description";
            var name = "Ad name";
            Guid? userId = Guid.NewGuid();
            Guid? categoryId = null;

            //Act
            Action act = () => AdEntity.Create(name, description, userId, categoryId);

            //Assert
            act.Should().Throw<InvalidOperationException>();
        }

        [Fact]
        public void Creating_Ads_With_Empty_User_Should_Throw_Exception()
        {
            //Arrange
            var description = "Test description";
            var name = "Ad name";
            Guid? userId = Guid.Empty;
            Guid? categoryId = Guid.NewGuid();

            //Act
            Action act = () => AdEntity.Create(name, description, userId, categoryId);

            //Assert
            act.Should().Throw<InvalidOperationException>();

        }

        [Fact]
        public void Creating_Ads_With_Empty_Category_Should_Throw_Exception()
        {
            //Arrange
            var description = "Test description";
            var name = "Ad name";
            Guid? userId = Guid.NewGuid();
            Guid? categoryId = Guid.Empty;

            //Act
            Action act = () => AdEntity.Create(name, description, userId, categoryId);

            //Assert
            act.Should().Throw<InvalidOperationException>();

        }

        [Fact]
        public void Creatng_ads_With_SameId_Must_Be_Equal()
        {
            //Arrange
            var description = "Test description";
            var name = "Ad name";
            Guid? userId = Guid.NewGuid();
            Guid? categoryId = Guid.NewGuid();
            Guid? id = Guid.NewGuid();

            //Act
            var ad1 = AdEntity.Create(id, name, description, userId, categoryId);
            var ad2 = AdEntity.Create(id, name, description, userId, categoryId);

            ad1.Equals(ad2).Should().BeTrue();

        }



    }
}
