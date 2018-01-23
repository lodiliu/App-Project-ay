
namespace ADT.XingZhi.IDAL.S
{
    public interface ILoginTimes
    {
        int Add(ADT.XingZhi.Models.S.LoginTimes model);
        int Update(ADT.XingZhi.Models.S.LoginTimes model);
        int Delete(string userName, bool isAdmin);
        ADT.XingZhi.Models.S.LoginTimes GetModel(string userName, bool isAdmin);
    }
}
