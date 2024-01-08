namespace Dynatron.Web.API.Models
{
  public class DataResult
  {

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    /// <value>The value.</value>
    public int Value { get; set; }

    /// <summary>
    /// Gets or sets the error.
    /// </summary>
    /// <value>The error.</value>
    public Error? Error { get; set; }

    /// <summary>
    /// Gets or sets more than one errors.
    /// </summary>
    /// <value>The permissions error.</value>
    public List<Error>? Errors { get; set; }

    /// <summary>
    /// Gets or sets the values.
    /// </summary>
    /// <value>The values.</value>
    public List<object>? Values { get; set; }

    /// <summary>
    /// Gets or sets the single value.
    /// </summary>
    /// <value>The single value.</value>
    public object? SingleValue { get; set; }

  }
}
