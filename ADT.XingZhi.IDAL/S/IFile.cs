using System.Data;

namespace ADT.XingZhi.IDAL.S
{
    public interface IFile
    {
        int Add(ADT.XingZhi.Models.S.File model);
        ADT.XingZhi.Models.S.File GetModelById(string id);
        int DeleteById(string id);
        DataTable GetListByAttachmentIds(string ids);
    }
}
