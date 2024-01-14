namespace Molong.Shared.DTO.Comment;

/// <summary>
/// 评论
/// </summary>
public class CommentBatchDeleteInDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public IList<Guid> Ids { get; set; } = new List<Guid>();
}

