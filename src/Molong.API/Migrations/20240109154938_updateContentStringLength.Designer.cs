﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Molong.Infrastructure;

#nullable disable

namespace Molong.API.Migrations
{
    [DbContext(typeof(MolongDbContext))]
    [Migration("20240109154938_updateContentStringLength")]
    partial class updateContentStringLength
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Molong.Domain.Model.Article", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("分类标识");

                    b.Property<int>("Collections")
                        .HasColumnType("int")
                        .HasComment("收藏数");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("内容");

                    b.Property<string>("CreateFullName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("创建人");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("创建人标识");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<int>("Likes")
                        .HasColumnType("int")
                        .HasComment("点赞数");

                    b.Property<DateTime?>("PublishDate")
                        .HasColumnType("datetime2")
                        .HasComment("发布时间");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("标题");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Article", t =>
                        {
                            t.HasComment("文章");
                        });
                });

            modelBuilder.Entity("Molong.Domain.Model.ArticleCollection", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<Guid>("ArticleId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("文章标识");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("用户标识");

                    b.HasKey("Id");

                    b.ToTable("ArticleCollection", t =>
                        {
                            t.HasComment("文章收藏");
                        });
                });

            modelBuilder.Entity("Molong.Domain.Model.ArticleTag", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<Guid>("ArticleId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("文章标识");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<Guid>("TagId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标签标识");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("TagId");

                    b.ToTable("ArticleTag", t =>
                        {
                            t.HasComment("文章标签");
                        });
                });

            modelBuilder.Entity("Molong.Domain.Model.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("名称");

                    b.Property<int>("SortNo")
                        .HasColumnType("int")
                        .HasComment("排序号");

                    b.HasKey("Id");

                    b.ToTable("Category", t =>
                        {
                            t.HasComment("分类");
                        });
                });

            modelBuilder.Entity("Molong.Domain.Model.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<Guid>("ArticleId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("文章标识");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasComment("内容");

                    b.Property<string>("CreateFullName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasComment("创建人");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<Guid?>("CreateUserId")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("创建人标识");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<DateTime?>("PublishDate")
                        .HasColumnType("datetime2")
                        .HasComment("发布时间");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.ToTable("Comment", t =>
                        {
                            t.HasComment("评论");
                        });
                });

            modelBuilder.Entity("Molong.Domain.Model.Tag", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier")
                        .HasComment("标识");

                    b.Property<DateTimeOffset>("CreateTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("创建时间");

                    b.Property<DateTimeOffset>("LastModifyTime")
                        .HasColumnType("datetimeoffset")
                        .HasComment("最后更新时间");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasComment("名称");

                    b.HasKey("Id");

                    b.ToTable("Tag", t =>
                        {
                            t.HasComment("标签");
                        });
                });

            modelBuilder.Entity("Molong.Domain.Model.Article", b =>
                {
                    b.HasOne("Molong.Domain.Model.Category", "Category")
                        .WithMany("Articles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Molong.Domain.Model.ArticleTag", b =>
                {
                    b.HasOne("Molong.Domain.Model.Article", "Article")
                        .WithMany("ArticleTags")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Molong.Domain.Model.Tag", "Tag")
                        .WithMany("ArticleTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Tag");
                });

            modelBuilder.Entity("Molong.Domain.Model.Comment", b =>
                {
                    b.HasOne("Molong.Domain.Model.Article", "Article")
                        .WithMany("Comments")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");
                });

            modelBuilder.Entity("Molong.Domain.Model.Article", b =>
                {
                    b.Navigation("ArticleTags");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Molong.Domain.Model.Category", b =>
                {
                    b.Navigation("Articles");
                });

            modelBuilder.Entity("Molong.Domain.Model.Tag", b =>
                {
                    b.Navigation("ArticleTags");
                });
#pragma warning restore 612, 618
        }
    }
}
