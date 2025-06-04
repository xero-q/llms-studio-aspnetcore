using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LLMStudio.Data.Models;

[Table("models")]
public class Model
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }
    
    [Required]
    [Column("name")]
    public string Name { get; set; }
    
    [Required]
    [Column("identifier")]
    public string Identifier { get; set; }

    private double _temperature = 0.7;

    [Required]
    [Column("temperature")]
    public double Temperature
    {
        get => _temperature;
        set
        {
            if (value < 0 || value > 1)
                throw new ArgumentOutOfRangeException(nameof(Temperature), "Temperature must be between 0 and 1.");
            _temperature = value;
        }
    }
    
    [Column("environment_variable")]
    public string EnvironmentVariable { get; set; }
    
    [Required]
    [Column("model_type_id")]
    public int ModelTypeId { get; set; }

    [ForeignKey("ModelTypeId")]
    public ModelType Provider { get; set; } = null!;
    
    public List<Thread> Threads { get; set; } = new();
}