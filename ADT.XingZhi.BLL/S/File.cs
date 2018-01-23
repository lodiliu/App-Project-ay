using System.Data;
using ADT.XingZhi.IDAL.S;
using ADT.XingZhi.DALFactory;
using ADT.XingZhi.DALFactory.S;

namespace ADT.XingZhi.BLL.S
{
    public class File
    {
        private readonly IFile dal = null;
        public File()
        {
            dal = DataAccess.CreateFile();
        }
        #region  Method

        /// <summary>
        /// 保存一条数据
        /// </summary>
        public int Add(ADT.XingZhi.Models.S.File model)
        {
            return dal.Add(model);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteById(string id)
        {
            return dal.DeleteById(id);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ADT.XingZhi.Models.S.File GetModelById(string id)
        {
            return dal.GetModelById(id);
        }
        /// <summary>
        /// 根据附件编号组获取对应所有的附件信息
        /// </summary>
        /// <param name="ids">附件编号组</param>
        /// <returns></returns>
        public DataTable GetListByAttachmentIds(string ids)
        {
            return dal.GetListByAttachmentIds(ids);
        }
        #endregion
    }
}
