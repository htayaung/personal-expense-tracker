using System.ComponentModel.DataAnnotations;

namespace PersonalExpenseTracker.Models.ViewModels
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(5), MaxLength(100)]
        public string Name { get; set; }

        public static CategoryViewModel FromEntity(Category entity)
        {
            return new CategoryViewModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        public static IEnumerable<CategoryViewModel> FromEntities(IEnumerable<Category> entities)
        {
            return entities.Select(entity => FromEntity(entity));
        }

        public Category ToEntity()
        {
            return new Category
            {
                Id = Id,
                Name = Name
            };
        }

        public void CopyTo(CategoryViewModel target)
        {
            target.Id = Id;
            target.Name = Name;
        }
    }
}
