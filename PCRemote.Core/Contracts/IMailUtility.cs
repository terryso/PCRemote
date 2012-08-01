using PCRemote.Core.Entities;

namespace PCRemote.Core.Contracts
{
    public interface IMailUtility
    {
        EmailAccount Account { get; }
        void Send(string to, string title, string body, params string[] files);
    }
}