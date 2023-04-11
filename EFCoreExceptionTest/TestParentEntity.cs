using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreExceptionTest;

internal class TestParentEntity
{
    [Key]
    public int Id { get; set; }

    [InverseProperty(nameof(TestChildEntity.Parent))]
    public ICollection<TestChildEntity> Children { get; set; }
}
