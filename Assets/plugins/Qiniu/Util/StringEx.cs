using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Qiniu.Util
{
    /// <summary>
    /// String辅助函数
    /// </summary>
	public static class StringEx
	{
        /// <summary>
        /// 对字符串进行Url编码 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
		public static string ToUrlEncode (string value)
		{
//			return System.Web.HttpUtility.UrlEncode (value);
            return WWW.EscapeURL(value);
		}
	}
}
