﻿using Dorado.Components.Alerts;
using Dorado.Data.Core;
using System;
using System.Web.Mvc;

namespace Dorado.Validators
{
    public abstract class BaseValidator : IValidator
    {
        public ModelStateDictionary ModelState { get; set; }
        public Int32 CurrentAccountId { get; set; }
        public AlertsContainer Alerts { get; set; }
        protected IUnitOfWork UnitOfWork { get; }

        protected BaseValidator(IUnitOfWork unitOfWork)
        {
            ModelState = new ModelStateDictionary();
            Alerts = new AlertsContainer();
            UnitOfWork = unitOfWork;
        }

        public void Dispose()
        {
            UnitOfWork.Dispose();
        }
    }
}