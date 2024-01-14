namespace Molong.Shared.DTO.Tag;

/// <summary>
/// 标签
/// </summary>
public class TagBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}

