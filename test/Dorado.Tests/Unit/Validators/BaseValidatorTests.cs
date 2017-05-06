﻿using Dorado.Data.Core;
using Dorado.Validators;
using NSubstitute;
using System;
using Xunit;

namespace Dorado.Tests.Unit.Services
{
    public class BaseValidatorTests : IDisposable
    {
        private BaseValidator validator;
        private IUnitOfWork unitOfWork;

        public BaseValidatorTests()
        {
            unitOfWork = Substitute.For<IUnitOfWork>();
            validator = Substitute.ForPartsOf<BaseValidator>(unitOfWork);
        }

        public void Dispose()
        {
            validator.Dispose();
        }

        #region BaseValidator(IUnitOfWork unitOfWork)

        [Fact]
        public void BaseValidator_CreatesEmptyModelState()
        {
            Assert.Empty(validator.ModelState);
        }

        [Fact]
        public void BaseValidator_CreatesEmptyAlerts()
        {
            Assert.Empty(validator.Alerts);
        }

        #endregion BaseValidator(IUnitOfWork unitOfWork)

        #region Dispose()

        [Fact]
        public void Dispose_UnitOfWork()
        {
            validator.Dispose();

            unitOfWork.Received().Dispose();
        }

        [Fact]
        public void Dispose_MultipleTimes()
        {
            validator.Dispose();
            validator.Dispose();
        }

        #endregion Dispose()
    }
}