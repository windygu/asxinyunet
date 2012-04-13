﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace NewLife.Linq
{
    /// <summary>表示具有公共键的对象的集合。</summary>
    /// <typeparam name="TKey">
    ///   <see cref="T:NewLife.Linq.IGrouping`2" /> 的键的类型。</typeparam>
    /// <typeparam name="TElement">
    ///   <see cref="T:NewLife.Linq.IGrouping`2" /> 的值的类型。</typeparam>
    /// <filterpriority>2</filterpriority>
    public interface IGrouping<TKey, TElement> : IEnumerable<TElement>, IEnumerable
    {
        /// <summary>获取 <see cref="T:NewLife.Linq.IGrouping`2" /> 的键。</summary>
        /// <returns>
        ///   <see cref="T:NewLife.Linq.IGrouping`2" /> 的键。</returns>
        TKey Key
        {
            get;
        }
    }
}