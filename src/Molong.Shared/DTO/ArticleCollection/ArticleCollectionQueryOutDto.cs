﻿namespace Molong.Shared.DTO.ArticleCollection;

/// <summary>
/// 文章收藏
/// </summary>
public class ArticleCollectionQueryOutDto
{
    /// <summary>
    /// 标识
    /// </summary>
    public Guid Id { get; set; }
    /// <summary>
    /// 文章标识
    /// </summary>
    public Guid ArticleId { get; set; }
    /// <summary>
    /// 用户标识
    /// </summary>
    public Guid UserId { get; set; }
    /// <summary>
    /// 创建时间
    /// </summary>
    public System.DateTimeOffset CreateTime { get; set; }
    /// <summary>
    /// 最后更新时间
    /// </summary>
    public System.DateTimeOffset LastModifyTime { get; set; }
}

