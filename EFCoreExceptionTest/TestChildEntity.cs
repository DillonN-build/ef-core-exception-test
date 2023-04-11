using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreExceptionTest;

internal class TestChildEntity
{
    [Key]
    public int Id { get; set; }

    public int TestParentId { get; set; }

    [ForeignKey(nameof(TestParentId))]
    public TestParentEntity? Parent { get; set; }
}
