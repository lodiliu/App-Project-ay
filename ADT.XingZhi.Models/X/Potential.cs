using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT.XingZhi.Models.X
{
    public class Potential
    {
        /// <summary>
        /// 1-明星ID
        /// </summary>
        public string _PersonID { get; set; }
        /// <summary>
        /// 2-名称
        /// </summary>
        public string _PersonName { get; set; }
        /// <summary>
        /// 3-作品名称
        /// </summary>
        public string _WorkName { get; set; }
        /// <summary>
        /// 4-作品类型
        /// </summary>
        public string _WorkType { get; set; }
        /// <summary>
        /// 5-导演
        /// </summary>
        public string _dy { get; set; }
        /// <summary>
        /// 6-主演
        /// </summary>
        public string _zy { get; set; }
        /// <summary>
        /// 7-作品介绍
        /// </summary>
        public string _WorkInfo { get; set; }
        /// <summary>
        /// 8-预计上映时间
        /// </summary>
        public string _Release { get; set; }
        /// <summary>
        /// 9-作品图片
        /// </summary>
        public string _ImgPath { get; set; }
        /// <summary>
        /// 10-创建时间
        /// </summary>
        public string _CreatedTime { get; set; }
    }
}
