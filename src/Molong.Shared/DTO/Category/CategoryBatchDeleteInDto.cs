namespace Molong.Shared.DTO.Category;

/// <summary>
/// 分类
/// </summary>
public class CategoryBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}

