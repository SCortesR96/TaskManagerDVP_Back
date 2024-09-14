using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Domain.Utils.DTO
{
    public class UniqueValidator : ValidationAttribute
    {
        private readonly PropertyInfo _columnProperty;

        public UniqueValidator(PropertyInfo columnProperty)
        {
            _columnProperty = columnProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var entityType = validationContext.ObjectType;
            var entity = validationContext.ObjectInstance;

            //using (var dbContext = new ApplicationDbContext()) // Reemplaza 'YourDbContext' con tu contexto de datos
            //{
            //    var query = dbContext.Set(entityType).Where(x =>
            //        _columnProperty.GetValue(x) == value);

            //    var existingItem = query.FirstOrDefault();

            //    if (existingItem != null)
            //        return new ValidationResult($"A {validationContext.DisplayName} already exists.");
            //}

            return ValidationResult.Success;
        }
    }
}