using System.Text.Json.Serialization;

namespace Dynatron.Web.API.Models
{
  public class Error
  {
    public int ErrorCode { get; set; } = 200;

    /// <summary>
    /// Gets or sets the message.
    /// </summary>
    /// <value>The message.</value>

    public string Message { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether this instance is contains error.
    /// </summary>
    /// <value><c>true</c> if this instance is error; otherwise, <c>false</c>.</value>

    public bool IsError { get; set; }

    /// <summary>
    /// Gets or sets the error list.
    /// </summary>
    /// <value>The error list.</value>
    public IEnumerable<string> ErrorList { get; set; } = new List<string>();

  }
}
