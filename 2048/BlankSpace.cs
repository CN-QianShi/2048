using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    /// <summary>
    /// 此结构记录空白位置的索引，在随机位置生成数据时使用
    /// </summary>
    struct BlankSpace
    {
        public int Index1 { get; set; }
        public int Index2 { get; set; }

        public BlankSpace(int index1, int index2) : this()
        {
            Index1 = index1;
            Index2 = index2;
        }
    }
}
