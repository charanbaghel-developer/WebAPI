using TestAPI.Model;


namespace TestAPI.Interface
{
    public interface IMembers
    {
        List<Members> GetAllMember();
        Members GetMember(int id);
        int SaveDetails(Members obj);
        int SaveEnqueryDetails(Enquery obj);
    }
}
