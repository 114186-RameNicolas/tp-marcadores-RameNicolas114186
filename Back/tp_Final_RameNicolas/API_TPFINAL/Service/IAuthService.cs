namespace API_TPFINAL.Service
{
    public interface IAuthService
    {
        Task<string> GetAuthToken();
    }
}
