﻿/***************************************************************
*
*   AimaTeam开源项目（版权所有：copyright@aimaTeam.com）       
*   尽管它开源,我们真心希望您可以为我们保留的版权信息，谢谢
----------------------------------------------------------------
*   作   者：Hai he
*   日   期：2015/12/8 1:37:34
*   博   客：https://hehai.aimateam.com
*   说   明：
----------------------------------------------------------------
*
*   官方QQ群号：139849106
*   官方  网站：https://www.aimateam.com
****************************************************************/

namespace Aima.Extension
{
    /// <summary>
    /// Object类型常用操作而定义的扩展方法静态类
    /// </summary>
    public static partial class ObjectExtension4CopyPaste
    {
        /// <summary>
        /// 复制一个对象
        /// </summary>
        /// <typeparam name="Tsrc"></typeparam>
        /// <param name="src"></param>
        /// <returns></returns>
        public static Tsrc Copy<Tsrc>(this Tsrc src) where Tsrc : class, new()
        {
            var sp = new object();
            throw new System.NotImplementedException();
            // return default(Tsrc);
        }

        /// <summary>
        /// 复制一个对象
        /// </summary>
        /// <typeparam name="Tsrc"></typeparam>
        /// <param name="src"></param>
        /// <returns></returns>
        public static TTarget CopyTo<Tsrc, TTarget>(this Tsrc src)
            where Tsrc : class, new()
            where TTarget : class, new()
        {
            var sp = new object();
            throw new System.NotImplementedException();
            // return default(Tsrc);
        }

        /// <summary>
        /// 将src对象的值粘贴到pasteTarget对象
        /// </summary>
        /// <typeparam name="Tsrc"></typeparam>
        /// <param name="src"></param>
        /// <returns></returns>
        public static void PasteTo<Tsrc>(this Tsrc src, Tsrc pasteTarget) where Tsrc : class, new()
        {
            throw new System.NotImplementedException();
        }
    }
}