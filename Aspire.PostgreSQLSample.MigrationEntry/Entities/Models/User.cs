﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable enable
using System;
using System.Collections.Generic;

namespace Aspire.PostgreSQLSample.MigrationEntry.Entities;

public partial class User
{
    /// <summary>
    /// 識別碼
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// 用戶名
    /// </summary>
    public string Username { get; set; } = null!;

    /// <summary>
    /// 密碼
    /// </summary>
    public string Password { get; set; } = null!;

    /// <summary>
    /// 狀態
    /// </summary>
    public int State { get; set; }

    /// <summary>
    /// 創建時間
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// 更新時間
    /// </summary>
    public DateTime UpdateAt { get; set; }
}