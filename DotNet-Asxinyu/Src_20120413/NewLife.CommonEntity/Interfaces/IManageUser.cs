﻿using System;
using System.Collections.Generic;

namespace NewLife.CommonEntity
{
    /// <summary>用户接口</summary>
    public interface IManageUser
    {
        /// <summary>编号</summary>
        Object ID { get; }

        /// <summary>账号</summary>
        String Account { get; }

        /// <summary>密码</summary>
        String Password { get; }

        /// <summary>属性集合</summary>
        IDictionary<String, Object> Properties { get; }
    }
}