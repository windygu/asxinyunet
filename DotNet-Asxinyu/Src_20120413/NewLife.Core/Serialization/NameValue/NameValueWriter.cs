﻿using System;
using System.Collections.Generic;
using System.IO;

namespace NewLife.Serialization
{
    /// <summary>名值写入器。用于Http请求、Http接口响应、Cookie值等读写操作。</summary>
    public class NameValueWriter : TextWriterBase<NameValueSetting>
    {
        #region 属性
        private TextWriter _Writer;
        /// <summary>写入器</summary>
        public TextWriter Writer
        {
            get { return _Writer ?? (_Writer = new StreamWriter(Stream, Settings.Encoding)); }
            set
            {
                _Writer = value;
                if (Settings.Encoding != _Writer.Encoding) Settings.Encoding = _Writer.Encoding;

                StreamWriter sw = _Writer as StreamWriter;
                if (sw != null && sw.BaseStream != Stream) Stream = sw.BaseStream;
            }
        }

        /// <summary>数据流。更改数据流后，重置Writer为空，以使用新的数据流</summary>
        public override Stream Stream
        {
            get { return base.Stream; }
            set
            {
                if (base.Stream != value) _Writer = null;
                base.Stream = value;
            }
        }
        #endregion

        #region 方法
        /// <summary>备份当前环境，用于临时切换数据流等</summary>
        /// <returns>本次备份项集合</returns>
        public override IDictionary<String, Object> Backup()
        {
            var dic = base.Backup();
            dic["Writer"] = Writer;

            return dic;
        }

        /// <summary>恢复最近一次备份</summary>
        /// <returns>本次还原项集合</returns>
        public override IDictionary<String, Object> Restore()
        {
            var dic = base.Restore();
            Writer = dic["Writer"] as TextWriter;

            return dic;
        }
        #endregion
    }
}