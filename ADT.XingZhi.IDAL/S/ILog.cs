
namespace ADT.XingZhi.IDAL.S
{
    public interface ILog
    {
        #region  成员方法
        int Add(Models.S.Log model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int DeleteById(int id);
        /// <summary>
        /// 批量删除（以英文","隔开)
        /// </summary>
        /// <param name="ids">编号组</param>
        int BatchDelete(string ids);
        ADT.XingZhi.Models.S.Log GetModelById(int id);
        #endregion  成员方法
    }
}
