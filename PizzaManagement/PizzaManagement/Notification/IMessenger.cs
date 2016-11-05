
namespace PizzaManagement.Notification
{
    public interface IMessenger
    {
        /// <summary>
        /// Sends the message.
        /// </summary>
        /// <param name="message">The message.</param>
        void SendMessage(string message);
    }
}
