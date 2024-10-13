using Microsoft.EntityFrameworkCore;

namespace Molong.Domain.Model;

/// <summary>
/// 分类
/// </summary>
[Table("Category")]
[Comment("分类")]
public partial class Category : Entity
{
    /// <summary>
    /// 名称
    /// </summary>
    [Comment("名称")]
    [StringLength(200)]
    public string Name { get; set; } = null!;
    /// <summary>
    /// 排序号
    /// </summary>
    [Comment("排序号")]
    public int SortNo { get; set; }
    /// <summary>
    /// 文章集合
    /// </summary>
    public ICollection<Article>? Articles { get; set; }
}