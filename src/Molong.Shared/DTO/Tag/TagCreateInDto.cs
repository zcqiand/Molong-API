namespace Molong.Shared.DTO.Tag;

/// <summary>
/// 标签
/// </summary>
public class TagCreateInDto : DtoBase
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; } = null!;
}
