using System;
using System.ComponentModel.DataAnnotations;
using WebUI.Constants;

namespace WebUI.Attributes
{
    public class VisitedDateControlAttribute : ValidationAttribute
    {
        private readonly string _intendedDatePropName;

        public VisitedDateControlAttribute(string intendedDatePropName)
        {
            _intendedDatePropName = intendedDatePropName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var isVisited = value as bool?;

            var propInfo = validationContext.ObjectType.GetProperty(_intendedDatePropName);

            if (propInfo == null)
                throw new ArgumentException("Property not found");

            var intendedDate = (DateTime?)propInfo.GetValue(validationContext.ObjectInstance);

            var today = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            if (intendedDate.HasValue && intendedDate > today && isVisited.HasValue && isVisited.Value)
            {
                return new ValidationResult(ValidationMessages.DateCannotBeFeature);
            }

            return ValidationResult.Success;
        }

    }
}
