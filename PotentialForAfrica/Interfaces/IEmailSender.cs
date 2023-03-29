using PotentialForAfrica.Helpers;

namespace PotentialForAfrica.Interfaces
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
    }
}
